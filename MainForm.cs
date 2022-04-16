using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Microsoft.Reporting.WinForms;
using System.IO;
using LiveCharts;
using LiveCharts.Wpf;

namespace Kursovaya_AirBookingSystem
{
    public partial class MainForm : Form
    {
        private string _userFirstName;
        private string _userLastName;
        private string _userId;
        private PurchaseHistoryPanelCreator _historyCreator;
        public bool _isLogged;

        public MainForm()
        {
            InitializeComponent();
            GetLoginScreen();
        }

        private void GetPersonalAreaScreen()
        {
            MTBPhoneNumber.Clear();
            MTBRegPhone.Clear();
            TBFName.Clear();
            TBLName.Clear();
            PLogReg.Visible = false;
            PLogReg.Enabled = false;
            LUserFullName.Text = _userFirstName + " " + _userLastName;
            PPersonalArea.Visible = true;
            PPersonalArea.Enabled = true;
            PPersonalArea.BringToFront();
            LoadPurchaseHistory();
            LoadTravelsCountByDestionationsBarChart();
            LoadPurchasesByTimeLineChart();
        }

        private void GetLoginScreen()
        {
            PLogReg.Visible = true;
            PLogReg.Enabled = true;
            PPersonalArea.Visible = false;
            PPersonalArea.Enabled = false;
            LUserFullName.Text = "";
            
            if (_historyCreator != null) _historyCreator.Clear();
        }

        private void LoadPurchaseHistory()
        {
            PurchaseHistoryPanel.Visible = false;
            _historyCreator = new PurchaseHistoryPanelCreator(this.PurchaseHistoryPanel, this.reportViewer1);
            string MyConString = Constants.DataBaseConnection;
            MySqlConnection connection = new MySqlConnection(MyConString);
            MySqlCommand SelectCommand = new MySqlCommand(String.Format(
                "SELECT * FROM view_operations WHERE ID_CL = '{0}'", Convert.ToInt32(_userId)), connection);
            MySqlDataReader myReader;

            connection.Open();
            myReader = SelectCommand.ExecuteReader();

            while(myReader.Read())
            {
                _historyCreator.AddButton(
                    Convert.ToString(myReader["IDoperation"]),
                    Convert.ToString(myReader["oDateTime"]),
                    Convert.ToString(myReader["seatTakerFirstName"]) + " " + 
                    Convert.ToString(myReader["seatTakerLastName"]),
                    Convert.ToString(myReader["departureP"]) + ", " +
                    Convert.ToString(myReader["depAirport"]) + " - " +
                    Convert.ToString(myReader["destinationP"]) + ", " +
                    Convert.ToString(myReader["desAirport"]),
                     Convert.ToString(myReader["fDepartureTime"]),
                     Convert.ToString(myReader["fArrivalTime"]),
                     Convert.ToString(myReader["ID_ticket"]));
            }

            connection.Close();
            _historyCreator.Reverse();
            PurchaseHistoryPanel.Visible = true;
        }

        private void LoadTravelsCountByDestionationsBarChart()
        {
            string MyConString = Constants.DataBaseConnection;
            MySqlConnection connection = new MySqlConnection(MyConString);
            string command = String.Format(
                "SELECT destinationP AS Destination, COUNT(ID_cl) AS Total " +
                "FROM view_destinations_by_idcl " +
                "WHERE ID_cl = '{0}' " +
                "GROUP BY destinationP " +
                "ORDER BY Total DESC", Convert.ToInt32(_userId));
            DataSet dataSet = new DataSet();
            DataTable table = new DataTable();
            MySqlDataAdapter dataAdapter;

            connection.Open();

            dataAdapter = new MySqlDataAdapter(command, connection);
            dataAdapter.Fill(dataSet);
            table = dataSet.Tables[0];

            connection.Close();

            SeriesCollection series = new SeriesCollection();
            ChartValues<int> travelsCounts = new ChartValues<int>();
            List<string> destinations = new List<string>();

            foreach(DataRow row in table.Rows)
            {
                travelsCounts.Add(Convert.ToInt32(row["Total"]));
                destinations.Add(Convert.ToString(row["Destination"]));
            }

            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisX.Add(new Axis()
            {
                Title = "Пункты назначения",
                Labels = destinations,
                Separator = new Separator() { Step = 1, IsEnabled = false}
            });

            cartesianChart1.AxisY.Clear();
            cartesianChart1.AxisY.Add(new Axis()
            {
                Title = "Количество прибытий"
            });

            ColumnSeries line = new ColumnSeries();
            line.Values = travelsCounts;
            line.Title = "";

            series.Add(line);
            cartesianChart1.Series = series;
            cartesianChart1.Zoom = ZoomingOptions.X;
        }

        private void LoadPurchasesByTimeLineChart()
        {            
            string MyConString = Constants.DataBaseConnection;
            MySqlConnection connection = new MySqlConnection(MyConString);
            string command = String.Format(
                "SELECT " +
                "CAST(oDateTime AS date) AS oSaleDate, " +
                "SUM(opPrice) AS oDayPrice " +
                "FROM operations " +
                "WHERE ID_cl = '{0}' " +
                "GROUP BY oSaleDate", Convert.ToInt32(_userId));
            DataSet dataSet = new DataSet();
            DataTable table = new DataTable();
            MySqlDataAdapter dataAdapter;

            connection.Open();

            dataAdapter = new MySqlDataAdapter(command, connection);
            dataAdapter.Fill(dataSet);
            table = dataSet.Tables[0];

            connection.Close();

            SeriesCollection series = new SeriesCollection();
            ChartValues<int> prices = new ChartValues<int>();
            List<string> times = new List<string>();
            
            foreach (DataRow row in table.Rows)
            {
                prices.Add(Convert.ToInt32(row["oDayPrice"]));
                times.Add(Convert.ToDateTime(row["oSaleDate"]).ToShortDateString());
            }

            cartesianChart2.AxisX.Clear();
            cartesianChart2.AxisX.Add(new Axis()
            {
                Title = "Даты",
                Labels = times,
                Separator = new Separator() { Step = 1, IsEnabled = false}
            });

            cartesianChart2.AxisY.Clear();
            cartesianChart2.AxisY.Add(new Axis()
            {
                Title = "Затраты"
            });

            LineSeries line = new LineSeries();
            line.Values = prices;
            line.Title = "";

            series.Add(line);
            cartesianChart2.Series = series;
            cartesianChart2.Zoom = ZoomingOptions.X;
        }

        private void FillComboBoxes()
        {
            string MyConString = Constants.DataBaseConnection;
            MySqlConnection connection = new MySqlConnection(MyConString);
            MySqlCommand SelectCommand = new MySqlCommand("SELECT departureP FROM routes GROUP BY departureP", connection);
            MySqlDataReader myReader;

            connection.Open();

            myReader = SelectCommand.ExecuteReader();
            while(myReader.Read()) DeparturesComboBox.Items.Add(Convert.ToString(myReader["departureP"]));
            myReader.Close();

            SelectCommand = new MySqlCommand("SELECT destinationP FROM routes GROUP BY destinationP", connection);
            myReader = SelectCommand.ExecuteReader();
            while (myReader.Read()) DestinationsComboBox.Items.Add(Convert.ToString(myReader["destinationP"]));

            myReader.Close();
            connection.Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            FillComboBoxes();
            this.DeparturesComboBox.SelectedIndex = -1;
            this.DestinationsComboBox.SelectedIndex = -1;
            this.reportViewer1.RefreshReport();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (MTBPhoneNumber.MaskCompleted)
            {
                bool isInSystem = false;
                string fname = "", sname = "";
                string MyConString = Constants.DataBaseConnection;
                string phone = MTBPhoneNumber.Text.
                    Replace("+", "").Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "").Remove(0, 1);
                MySqlConnection connection = new MySqlConnection(MyConString);
                MySqlCommand SelectCommand = new MySqlCommand(
                    "SELECT * FROM clients_list WHERE clPhone = '" + phone + "'", connection);
                MySqlDataReader myReader;

                connection.Open();
                myReader = SelectCommand.ExecuteReader();
                while (myReader.Read())
                {
                    isInSystem = true;
                    _userId = myReader["ID_CL"].ToString();
                    fname = myReader["clFName"].ToString();
                    sname = myReader["clSName"].ToString();
                }

                if (isInSystem)
                {
                    _userFirstName = fname;
                    _userLastName = sname;
                    connection.Close();
                    _isLogged = true;
                    GetPersonalAreaScreen();
                }
                else
                {
                    MessageBox.Show("Номер не зарегистрирован");
                    _userId = "0";
                }

                connection.Close();
            }
            else MessageBox.Show("Введите номер телефона");
        }

        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            if (!MTBRegPhone.MaskCompleted)
            {
                MessageBox.Show("Введите номер телефона");
                return;
            }
            if (TBFName.Text == "")
            {
                MessageBox.Show("Введите имя");
                return;
            }
            if (TBLName.Text == "")
            {
                MessageBox.Show("Введите фамилию");
                return;
            }

            bool isInSystem = false;
            string fname = "", sname = "";
            string myConString = Constants.DataBaseConnection;
            string phone = MTBRegPhone.Text.
                Replace("+", "").Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "").Remove(0, 1);
            MySqlConnection connection = new MySqlConnection(myConString);
            MySqlCommand selectCommand = new MySqlCommand(
                "SELECT * FROM clients_list WHERE clPhone = '" + phone + "'", connection);
            MySqlDataReader myReader;

            connection.Open();
            myReader = selectCommand.ExecuteReader();

            while (myReader.Read())
            {
                isInSystem = true;
                fname = myReader["clFName"].ToString();
                sname = myReader["clSName"].ToString();
            }

            myReader.Close();

            if (isInSystem) MessageBox.Show("Номер уже зарегистрирован");
            else
            {
                _isLogged = true;
                _userFirstName = TBFName.Text;
                _userLastName = TBLName.Text;
                MySqlCommand insertCommand = new MySqlCommand(
                    String.Format("INSERT INTO clients_list (clFName, clSName, clPhone) VALUES ('{0}', '{1}', '{2}')",
                    TBFName.Text, TBLName.Text, phone), connection);
                insertCommand.ExecuteNonQuery();

                MySqlCommand SelectCommand = new MySqlCommand(
                "SELECT * FROM clients_list " +
                "WHERE ID_CL = (SELECT max(ID_CL) FROM clients_list)", connection);
                myReader = SelectCommand.ExecuteReader();
                myReader.Read();
                _userId = Convert.ToString(myReader["ID_CL"]);
                myReader.Close();

                connection.Close();
                GetPersonalAreaScreen();
            }

            connection.Close();
        }

        private void ExitPersonalAreaButton_Click(object sender, EventArgs e)
        {
            _isLogged = false;
            GetLoginScreen();
        }

        private void SearchTicketsButton_Click(object sender, EventArgs e)
        {
            if (DeparturesComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите пункт вылета");
                return;
            }
            if(DestinationsComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите пункт назначения");
                return;
            }
            if (DestinationsComboBox.SelectedItem == DeparturesComboBox.SelectedItem)
            {
                MessageBox.Show("Выберите разные города");
                return;
            }

            object[] searchInfo = new object[] 
            {
                DeparturesComboBox.Text, 
                DestinationsComboBox.Text,
                DepartureTimeDateTimePicker.Value, 
                (int)AdultsCountNumericUpDown.Value, 
                (int)ChildrenCountNumericUpDown.Value,
                (int)BabiesCountNumericUpDown.Value,
                _isLogged,
                _userId
            };
            SearchResultForm tf = new SearchResultForm(searchInfo);
            
            this.Hide();
            tf.ShowDialog();
            this.Show();
        }

        private void BabiesCountNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (BabiesCountNumericUpDown.Value > AdultsCountNumericUpDown.Value) BabiesCountNumericUpDown.Value--;
        }

        private void UpdateInfoPictureBox_Click(object sender, EventArgs e)
        {
            if (_historyCreator != null) _historyCreator.Clear();
            LoadPurchaseHistory();
            LoadTravelsCountByDestionationsBarChart();
            LoadPurchasesByTimeLineChart();
        }
    }

    public class PurchaseHistoryPanelCreator
    {
        private Panel _historyPanel;
        private ReportViewer _rv;
        
        public List<Panel> Items { get; set; }

        public PurchaseHistoryPanelCreator(Panel historyPanel, ReportViewer rv)
        {
            Items = new List<Panel>();
            _historyPanel = historyPanel;
            _rv = rv;
        }

        public void AddButton(string orderNum, string opTime, string seatTaker, string path,
            string depTime, string desTime, string ticketNum)
        {
            Items.Add(new Panel());
            int W, H,
                distantBetweenButtons = 1,
                X, Y;

            _historyPanel.Controls.Add(Items.Last());

            X = 1;

            if (Items.Count == 1) Y = 1;
            else Y = Items[Items.Count - 2].Size.Height +
                    Items[Items.Count - 2].Location.Y + distantBetweenButtons;

            W = _historyPanel.Width - X * 2 - 2;
            H = 180;

            Label L_Order = new Label();
            int L_OrderX = 5, L_OrderPY = 5;
            Items.Last().Controls.Add(L_Order);
            L_Order.Location = new Point(L_OrderX, L_OrderPY);
            L_Order.Text = "Заказ № ";
            L_Order.Font = new Font("Oswald Light", 15f);
            L_Order.AutoSize = true;

            Label L_OrderNum = new Label();
            int L_OrderNumX = L_OrderX + 80, L_OrderNumPY = L_OrderPY;
            Items.Last().Controls.Add(L_OrderNum);
            L_OrderNum.Location = new Point(L_OrderNumX, L_OrderNumPY);
            L_OrderNum.Text = orderNum;
            L_OrderNum.Font = new Font("Oswald Light", 15f);
            L_OrderNum.AutoSize = true;
            L_OrderNum.Name = "L_OrderNum";

            Label L_Ticket = new Label();
            int L_TicketX = L_OrderX + 160, L_TicketY = L_OrderPY;
            Items.Last().Controls.Add(L_Ticket);
            L_Ticket.Location = new Point(L_TicketX, L_TicketY);
            L_Ticket.Text = "Билет № ";
            L_Ticket.Font = new Font("Oswald Light", 15f);
            L_Ticket.AutoSize = true;

            Label L_TicketNum = new Label();
            int L_TicketNumX = L_TicketX + 80, L_TicketNumY = L_TicketY;
            Items.Last().Controls.Add(L_TicketNum);
            L_TicketNum.Location = new Point(L_TicketNumX, L_TicketNumY);
            L_TicketNum.Text = ticketNum;
            L_TicketNum.Font = new Font("Oswald Light", 15f);
            L_TicketNum.AutoSize = true;

            Label L_OrderTime = new Label();
            int L_OrderTimeX = L_TicketX + 180, L_OrderTimeY = L_OrderPY;
            Items.Last().Controls.Add(L_OrderTime);
            L_OrderTime.Location = new Point(L_OrderTimeX, L_OrderTimeY);
            L_OrderTime.Text = "Дата и время заказа: ";
            L_OrderTime.Font = new Font("Oswald Light", 15f);
            L_OrderTime.AutoSize = true;

            Label L_OrderTimeVal = new Label();
            int L_OrderTimeValX = L_OrderTimeX + 180, L_OrderTimeValY = L_OrderTimeY;
            Items.Last().Controls.Add(L_OrderTimeVal);
            L_OrderTimeVal.Location = new Point(L_OrderTimeValX, L_OrderTimeValY);
            L_OrderTimeVal.Text = opTime;
            L_OrderTimeVal.Font = new Font("Oswald Light", 15f);
            L_OrderTimeVal.AutoSize = true;

            Label L_Passenger = new Label();
            int L_PassengerX = L_OrderX, L_PassengerY = L_OrderPY + 40;
            Items.Last().Controls.Add(L_Passenger);
            L_Passenger.Location = new Point(L_PassengerX, L_PassengerY);
            L_Passenger.Text = "Пассажир: ";
            L_Passenger.Font = new Font("Oswald Light", 13f);
            L_Passenger.AutoSize = true;

            Label L_PassengerName = new Label();
            int L_PassengerNameX = L_PassengerX + 90, L_PassengerNameY = L_PassengerY;
            Items.Last().Controls.Add(L_PassengerName);
            L_PassengerName.Location = new Point(L_PassengerNameX, L_PassengerNameY);
            L_PassengerName.Text = seatTaker;
            L_PassengerName.Font = new Font("Oswald Light", 13f);
            L_PassengerName.AutoSize = true;

            Label L_Route = new Label();
            int L_RouteX = L_OrderX, L_RouteY = L_PassengerY + 30;
            Items.Last().Controls.Add(L_Route);
            L_Route.Location = new Point(L_RouteX, L_RouteY);
            L_Route.Text = "Маршрут: ";
            L_Route.Font = new Font("Oswald Light", 13f);
            L_Route.AutoSize = true;

            Label L_RouteFull = new Label();
            int L_RouteFullX = L_OrderX + 90, L_RouteFullY = L_RouteY;
            Items.Last().Controls.Add(L_RouteFull);
            L_RouteFull.Location = new Point(L_RouteFullX, L_RouteFullY);
            L_RouteFull.Text = path;
            L_RouteFull.Font = new Font("Oswald Light", 13f);
            L_RouteFull.AutoSize = true;

            Label L_depTime = new Label();
            int L_depTimeX = L_OrderX, L_depTimeY = L_RouteY + 30;
            Items.Last().Controls.Add(L_depTime);
            L_depTime.Location = new Point(L_depTimeX, L_depTimeY);
            L_depTime.Text = "Вылет: ";
            L_depTime.Font = new Font("Oswald Light", 13f);
            L_depTime.AutoSize = true;

            Label L_depTimeVal = new Label();
            int L_depTimeValX = L_OrderX + 90, L_depTimeValY = L_RouteY + 30;
            Items.Last().Controls.Add(L_depTimeVal);
            L_depTimeVal.Location = new Point(L_depTimeValX, L_depTimeValY);
            L_depTimeVal.Text = depTime;
            L_depTimeVal.Font = new Font("Oswald Light", 13f);
            L_depTimeVal.AutoSize = true;

            Label L_desTime = new Label();
            int L_desTimeX = L_OrderX, L_desTimeY = L_depTimeY + 30;
            Items.Last().Controls.Add(L_desTime);
            L_desTime.Location = new Point(L_desTimeX, L_desTimeY);
            L_desTime.Text = "Прибытие: ";
            L_desTime.Font = new Font("Oswald Light", 13f);
            L_desTime.AutoSize = true;

            Label L_desTimeVal = new Label();
            int L_desTimeValX = L_OrderX + 90, L_desTimeValY = L_desTimeY;
            Items.Last().Controls.Add(L_desTimeVal);
            L_desTimeVal.Location = new Point(L_desTimeValX, L_desTimeValY);
            L_desTimeVal.Text = desTime;
            L_desTimeVal.Font = new Font("Oswald Light", 13f);
            L_desTimeVal.AutoSize = true;

            Button B_SaveTicketInPdf = new Button();
            int B_SaveTicketInPdfX = L_RouteX + 530, B_SaveTicketInPdfY = H/3;
            Items.Last().Controls.Add(B_SaveTicketInPdf);
            B_SaveTicketInPdf.Location = new Point(B_SaveTicketInPdfX, B_SaveTicketInPdfY);
            B_SaveTicketInPdf.Text = "Сохранить в PDF";
            B_SaveTicketInPdf.Font = new Font("Oswald Light", 15f);
            B_SaveTicketInPdf.AutoSize = true;
            B_SaveTicketInPdf.Cursor = Cursors.Hand;
            B_SaveTicketInPdf.FlatStyle = FlatStyle.Flat;
            B_SaveTicketInPdf.BackColor = SystemColors.MenuHighlight;
            B_SaveTicketInPdf.ForeColor = Color.White;
            B_SaveTicketInPdf.Click += SaveTicketInPDFButton_Click;

            Items.Last().BackColor = Color.White;
            Items.Last().Location = new Point(X, Y);
            Items.Last().AutoSize = false;
            Items.Last().Size = new Size(W, H);
            Items.Last().Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            Items.Last().ForeColor = Color.Black;
            Items.Last().Visible = true;
            Items.Last().Font = new Font("Segoe UI", 10f, FontStyle.Regular);
            Items.Last().BorderStyle = BorderStyle.FixedSingle;
        }

        public void Reverse()
        {
            Point temp;

            for (int start = 0, end = this.Items.Count - 1; start <= end; start++, end--)
            {
                temp = this.Items[start].Location;
                this.Items[start].Location = this.Items[end].Location;
                this.Items[end].Location = temp;
            }
        }

        public void Clear()
        {
            for (int i = 0; i < Items.Count; i++)
            {
                Items[i].Dispose();
            }
            Items.Clear();
        }

        private void SaveTicketInPDFButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            FileStream newFile;
            Panel buttonParent = (sender as Button).Parent as Panel;
            string ticketId = (buttonParent.Controls["L_OrderNum"] as Label).Text;

            _rv.RefreshReport();
            _rv.LocalReport.ReportPath = Constants.TicketReportPath;

            if (folder.ShowDialog() == DialogResult.OK)
            {
                string MyConString = Constants.DataBaseConnection;
                MySqlConnection connection = new MySqlConnection(MyConString);
                MySqlCommand SelectCommand;
                MySqlDataReader myReader;

                connection.Open();

                SelectCommand = new MySqlCommand(String.Format(
                    "SELECT * FROM view_full_tickes_info " +
                    "WHERE IDoperation = '{0}'", Convert.ToInt32(ticketId)), connection);
                myReader = SelectCommand.ExecuteReader();
                myReader.Read();

                double adultPrice = Convert.ToDouble(myReader["fPrice"]);
                double childPrice = 
                    Convert.ToDouble(myReader["fPrice"]) -
                    ((Convert.ToDouble(myReader["fPrice"]) *
                    Convert.ToDouble(myReader["childrenDiscount"])) / 100);

                double babyPrice = 
                    Convert.ToDouble(myReader["fPrice"]) -
                    ((Convert.ToDouble(myReader["fPrice"]) *
                    Convert.ToDouble(myReader["babiesDiscount"]))) / 100;

                double economyPrice = Convert.ToDouble(myReader["economy"]);
                double premierePrice = Convert.ToDouble(myReader["business"]);
                double flightPrice = 0.0;
                double seatPrice = 0.0;

                switch(Convert.ToString(myReader["ticketType"]))
                {
                    case "Взрослый": { flightPrice = adultPrice; break; }
                    case "Ребенок": { flightPrice = childPrice; break; }
                    case "Младенец": { flightPrice = babyPrice; break; }
                }

                switch (Convert.ToString(myReader["seatType"]))
                {
                    case "Premier": { seatPrice = premierePrice; break; }
                    case "Economy": { seatPrice = economyPrice; break; }
                    case "-": { seatPrice = 0.0; break; }
                }

                _rv.Refresh();
                _rv.LocalReport.SetParameters(
                    new ReportParameter("ticketID", Convert.ToString(myReader["ID_ticket"])));

                _rv.LocalReport.SetParameters(
                    new ReportParameter("orderID", Convert.ToString(myReader["IDoperation"])));

                _rv.LocalReport.SetParameters(
                    new ReportParameter("soldDate", Convert.ToString(myReader["oDateTime"])));

                _rv.LocalReport.SetParameters(
                    new ReportParameter("name", Convert.ToString(myReader["seatTakerFirstName"]) + " " +
                    Convert.ToString(myReader["seatTakerLastName"])));

                _rv.LocalReport.SetParameters(
                    new ReportParameter("passport", Convert.ToString(myReader["passportSeries"]) +
                    Convert.ToString(myReader["passportNumber"])));

                _rv.LocalReport.SetParameters(
                    new ReportParameter("birthCertificate", Convert.ToString(myReader["birthCertificate"])));

                _rv.LocalReport.SetParameters(
                    new ReportParameter("departure", Convert.ToString(myReader["departureP"]) + ", " +
                    Convert.ToString(myReader["depAirport"])));

                _rv.LocalReport.SetParameters(
                    new ReportParameter("depTime", Convert.ToString(myReader["fDepartureTime"])));

                _rv.LocalReport.SetParameters(
                    new ReportParameter("destination", Convert.ToString(myReader["destinationP"]) + ", " +
                    Convert.ToString(myReader["desAirport"])));

                _rv.LocalReport.SetParameters(
                    new ReportParameter("desTime", Convert.ToString(myReader["fArrivalTime"])));

                _rv.LocalReport.SetParameters(
                    new ReportParameter("Carrier", Convert.ToString(myReader["carrName"])));

                _rv.LocalReport.SetParameters(
                    new ReportParameter("airplaneModel", Convert.ToString(myReader["model"])));

                _rv.LocalReport.SetParameters(
                    new ReportParameter("tailNum", Convert.ToString(myReader["tailNum"])));

                _rv.LocalReport.SetParameters(
                    new ReportParameter("seatClass", Convert.ToString(myReader["seatType"])));

                _rv.LocalReport.SetParameters(
                    new ReportParameter("seatNum", Convert.ToString(myReader["seatNum"])));

                _rv.LocalReport.SetParameters(
                    new ReportParameter("baggage", Convert.ToString(myReader["baggageNum"])));

                _rv.LocalReport.SetParameters(
                    new ReportParameter("flightPrice", Convert.ToString(flightPrice) + " руб."));

                _rv.LocalReport.SetParameters(
                    new ReportParameter("seatPrice", Convert.ToString(seatPrice) + " руб."));

                _rv.LocalReport.SetParameters(
                    new ReportParameter("baggagePrice", Convert.ToString(myReader["baggagePrice"]).Split(',')[0] + " руб."));

                _rv.LocalReport.SetParameters(
                    new ReportParameter("fullPrice", Convert.ToString(myReader["opPrice"]) + " руб."));
                _rv.Refresh();

                byte[] byteViewerPDF = _rv.LocalReport.Render("PDF");
                newFile = new FileStream(
                    folder.SelectedPath + "\\ticket" + myReader["ID_ticket"] + ".pdf", FileMode.Create);

                newFile.Write(byteViewerPDF, 0, byteViewerPDF.Length);
                newFile.Close();

                connection.Close();
            }
        }
    }

    public static class Constants
    {
        public const string DataBaseConnection = "SERVER=;DATABASE=;UID=;PASSWORD=;";
        public const string TicketReportPath = @"..\Kursovaya_AirBookingSystem\Ticket.rdlc";
    }
}
