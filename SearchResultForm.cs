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

namespace Kursovaya_AirBookingSystem
{
    public partial class SearchResultForm : Form
    {
        private SearchResultPanelCreator _creator;
        private readonly string _departure;
        private readonly string _destination;
        private readonly DateTime _dateTime;
        public readonly int _adultsCount;
        public readonly int _childrenCount;
        public readonly int _babiesCount;
        public readonly bool _isLogged;
        public readonly string _userId;
        public readonly List<object[]> _flightsInfo;

        public SearchResultForm()
        {
            InitializeComponent();
        }

        public SearchResultForm(object[] searchInfo)
        {
            //0 - dep, 1 - des, 2 - datetime, 3 - adults, 4 - children, 5 - babies, 6 - isLogged
            //7 - userID
            InitializeComponent();
            _departure = Convert.ToString(searchInfo[0]);
            _destination = Convert.ToString(searchInfo[1]);
            _dateTime = (DateTime)searchInfo[2];
            _adultsCount = (int)searchInfo[3];
            _childrenCount = (int)searchInfo[4];
            _babiesCount = (int)searchInfo[5];
            _isLogged = (bool)searchInfo[6];
            _userId = Convert.ToString(searchInfo[7]);
            _flightsInfo = new List<object[]>();
            GenerateSearchResult();
        }

        private void GenerateSearchResult()
        {
            _flightsInfo.Clear();
            _creator = new SearchResultPanelCreator(this);
            string MyConString = Constants.DataBaseConnection;
            MySqlConnection connection = new MySqlConnection(MyConString);
            MySqlCommand SelectCommand = new MySqlCommand(String.Format(
                "SELECT * " +
                "FROM view_flights " +
                "WHERE fDepartureTime >= '{0}' AND fDepartureTime <= '{1}' " +
                "AND departureP = '{2}' " +
                "AND destinationP = '{3}'" +
                "AND seatNum >= (soldSeats + {4})",
                _dateTime.Date.ToString("u"), GetEndOfTheDay(_dateTime), 
                _departure, _destination, _adultsCount + _childrenCount), connection);
            MySqlDataReader myReader;
            int i = 0;

            connection.Open();
            myReader = SelectCommand.ExecuteReader();

            while (myReader.Read())
            {
                double childPercent = Convert.ToDouble(myReader["fPrice"]) -
                ((Convert.ToDouble(myReader["fPrice"]) *
                Convert.ToDouble(myReader["childrenDiscount"])) / 100);
                
                double babyPercent = Convert.ToDouble(myReader["fPrice"]) -
                    ((Convert.ToDouble(myReader["fPrice"]) *
                    Convert.ToDouble(myReader["babiesDiscount"]))) / 100;
                
                double flightPrice = Convert.ToDouble(
                    myReader["fPrice"]) * (double)_adultsCount +
                    (double)_childrenCount * childPercent +
                    (double)_babiesCount * babyPercent;

                _creator.AddButton(myReader["departureP"].ToString(), myReader["destinationP"].ToString(),
                    myReader["fDepartureTime"].ToString(), myReader["fArrivalTime"].ToString(), 
                    myReader["carrName"].ToString(), flightPrice.ToString(), i);
                
                if (!CB_CompanyFilter.Items.Contains(myReader["carrName"]))
                    CB_CompanyFilter.Items.Add(myReader["carrName"]);

                _flightsInfo.Add(new object[17] 
                { 
                    myReader["ID_f"], myReader["fDepartureTime"], 
                    myReader["fArrivalTime"], myReader["fPrice"],
                    myReader["departureP"], myReader["destinationP"],
                    myReader["ID_ap"], myReader["seatNum"],
                    myReader["soldSeats"], myReader["carrName"],
                    myReader["economy"], myReader["comfort"],
                    myReader["business"], myReader["first"],
                    myReader["baggagePrice"], myReader["childrenDiscount"], 
                    myReader["babiesDiscount"]
                });

                i++;
            }

            connection.Close();
        }

        private void GetMultiFilter()
        {
            foreach (Panel item in _creator.Items)
                (item.Controls["PB_filter"] as PictureBox).Visible = true;

            if (TB_PriceStart.Text != "" && TB_PriceEnd.Text != "") FilterByCost();
            if (CB_CompanyFilter.SelectedIndex != -1) FilterByCarrier();
            if (CB_DepartionTime.SelectedIndex != -1) FilterByDepartTime();
            if (CB_destinationTime.SelectedIndex != -1) FilterByDestinationTime();
        }

        private void FilterByCost()
        {
            for (int i = 0; i < _creator.Items.Count; i++)
            {
                Label p = (_creator.Items[i].Controls["L_flightPrice"] as Label);

                if (Convert.ToInt32(p.Text.Remove(p.Text.Length - 1, 1)) < int.Parse(TB_PriceStart.Text) ||
                    Convert.ToInt32(p.Text.Remove(p.Text.Length - 1, 1)) > int.Parse(TB_PriceEnd.Text))
                {
                    (_creator.Items[i].Controls["PB_filter"] as PictureBox).Visible = false;
                }
            }
        }

        private void FilterByCarrier()
        {
            for (int i = 0; i < _creator.Items.Count; i++)
                if (Convert.ToString(_flightsInfo[i][9]) != CB_CompanyFilter.Text)
                    (_creator.Items[i].Controls["PB_filter"] as PictureBox).Visible = false;
        }

        private void FilterByDepartTime()
        {
            DateTime first = new DateTime(_dateTime.Date.Ticks);
            DateTime second = new DateTime(_dateTime.Date.Ticks);
            DateTime dt;
            TimeSpan ts;
            int day, month, year, hours, minutes, seconds;
            string dateTime;

            switch (CB_DepartionTime.Text)
            {
                case "Утро":
                    ts = new TimeSpan(6, 0, 0);
                    first = first.Date + ts;
                    ts = new TimeSpan(12, 0, 0);
                    second = second.Date + ts;
                    break;
                case "День":
                    ts = new TimeSpan(12, 0, 0);
                    first = first.Date + ts;
                    ts = new TimeSpan(18, 0, 0);
                    second = second.Date + ts;
                    break;
                case "Вечер":
                    ts = new TimeSpan(18, 0, 0);
                    first = first.Date + ts;
                    ts = new TimeSpan(24, 0, 0);
                    second = second.Date + ts;
                    break;
                case "Ночь":
                    ts = new TimeSpan(6, 0, 0);
                    second = second.Date + ts;
                    break;
            }

            for (int i = 0; i < _creator.Items.Count; i++)
            {
                dateTime = Convert.ToString(_flightsInfo[i][1]);
                day = Convert.ToInt32(dateTime.Split(' ')[0].Split('.')[0]);
                month = Convert.ToInt32(dateTime.Split(' ')[0].Split('.')[1]);
                year = Convert.ToInt32(dateTime.Split(' ')[0].Split('.')[2]);
                hours = Convert.ToInt32(dateTime.Split(' ')[1].Split(':')[0]);
                minutes = Convert.ToInt32(dateTime.Split(' ')[1].Split(':')[1]);
                seconds = Convert.ToInt32(dateTime.Split(' ')[1].Split(':')[2]);
                dt = new DateTime(year, month, day, hours, minutes, seconds);

                if (dt.Ticks < first.Ticks || dt.Ticks > second.Ticks)
                    (_creator.Items[i].Controls["PB_filter"] as PictureBox).Visible = false;
            }
        }

        private void FilterByDestinationTime()
        {
            int day, month, year, hours, minutes, seconds;
            string dateTime;
            DateTime first, second, dt;
            TimeSpan fts = new TimeSpan(); 
            TimeSpan sts = new TimeSpan();

            switch (CB_destinationTime.Text)
            {
                case "Утро":
                    fts = new TimeSpan(6, 0, 0);
                    sts = new TimeSpan(12, 0, 0);
                    break;
                case "День":
                    fts = new TimeSpan(12, 0, 0);
                    sts = new TimeSpan(18, 0, 0);
                    break;
                case "Вечер":
                    fts = new TimeSpan(18, 0, 0);
                    sts = new TimeSpan(24, 0, 0);
                    break;
                case "Ночь":
                    fts = new TimeSpan(0, 0, 0);
                    sts = new TimeSpan(6, 0, 0);
                    break;
            }

            for (int i = 0; i < _creator.Items.Count; i++)
            {
                dateTime = Convert.ToString(_flightsInfo[i][2]);
                day = Convert.ToInt32(dateTime.Split(' ')[0].Split('.')[0]);
                month = Convert.ToInt32(dateTime.Split(' ')[0].Split('.')[1]);
                year = Convert.ToInt32(dateTime.Split(' ')[0].Split('.')[2]);
                hours = Convert.ToInt32(dateTime.Split(' ')[1].Split(':')[0]);
                minutes = Convert.ToInt32(dateTime.Split(' ')[1].Split(':')[1]);
                seconds = Convert.ToInt32(dateTime.Split(' ')[1].Split(':')[2]);
                dt = new DateTime(year, month, day, hours, minutes, seconds);
                first = new DateTime(year, month, day, 0, 0, 0);
                second = new DateTime(year, month, day, 0, 0, 0);

                first = first.Date + fts;
                second = second.Date + sts;

                if (dt.Ticks < first.Ticks || dt.Ticks > second.Ticks)
                    (_creator.Items[i].Controls["PB_filter"] as PictureBox).Visible = false;
            }
        }

        private string GetEndOfTheDay(DateTime dt)
        {
            TimeSpan ts = new TimeSpan(23, 59, 59);
            return (dt.Date + ts).ToString("u");
        }
        
        public int GetChoosenPanelIndex()
        {
            int index = 0;

            for (int i = 0; i < _creator.Items.Count; i++)
            {
                if (_creator.Items[i].Enabled == false)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        private void BackToMainFormButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChooseSeatButton_Click(object sender, EventArgs e)
        {
            if (_isLogged)
            {
                RegistrationForm rf = new RegistrationForm(
                    _flightsInfo[GetChoosenPanelIndex()], _adultsCount,
                _childrenCount, _babiesCount, _userId);

                rf.FormClosed += SearchResultForm_FormClosed;
                this.Hide();
                rf.ShowDialog();
                
            }
            else MessageBox.Show("Необходимо войти в систему!");
        }

        private void PriceStartTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 || tb.Text.Length == 0 && e.KeyChar == '0')
                e.Handled = true;
        }

        private void PriceEndTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 || tb.Text.Length == 0 && e.KeyChar == '0')
                e.Handled = true;
        }

        private void PriceStartTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb.Text == "0" && tb.Text.Length == 1) tb.Text = "";
            if (TB_PriceStart.Text != "" && TB_PriceEnd.Text != "")
                GetMultiFilter();
        }

        private void PriceEndTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb.Text == "0" && tb.Text.Length == 1) tb.Text = "";
            if (TB_PriceStart.Text != "" && TB_PriceEnd.Text != "")
                GetMultiFilter();
        }

        private void CompanyFilterComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            GetMultiFilter();
        }

        private void DepartionTimeComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            GetMultiFilter();
        }

        private void DestinationTimeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetMultiFilter();
        }

        private void CancelFilterButton_Click(object sender, EventArgs e)
        {
            TB_PriceStart.Text = "";
            TB_PriceEnd.Text = "";
            CB_CompanyFilter.SelectedIndex = -1;
            CB_DepartionTime.SelectedIndex = -1;
            CB_destinationTime.SelectedIndex = -1;
            foreach (Panel item in _creator.Items)
                (item.Controls["PB_filter"] as PictureBox).Visible = false;
        }

        public void SearchResultForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }

    public class SearchResultPanelCreator
    {
        private Panel _searchResultPanel;
        private SearchResultForm _senderForm;

        public List<Panel> Items { get; set; }

        public bool IsThereChoosenButtons { get; set; }

        public SearchResultPanelCreator(SearchResultForm senderForm)
        {
            Items = new List<Panel>();
            _searchResultPanel = senderForm.SearchResultPanel;
            _senderForm = senderForm;
        }

        public void AddButton(string depP, string desP, string depT, string desT, 
            string carrier, string fPrice, int i)
        {
            Items.Add(new Panel());
            int W, H,
                distantBetweenButtons = 1,
                X, Y;

            _searchResultPanel.Controls.Add(Items.Last());

            X = 1;

            if (Items.Count == 1) Y = 1;
            else Y = Items[Items.Count - 2].Size.Height + 
                    Items[Items.Count - 2].Location.Y + distantBetweenButtons;

            W = _searchResultPanel.Width - X * 2 - 2;
            H = 80;

            Label flightDepP = new Label();
            int L_flightDepPX = 60, L_flightDepPY = 5;
            Items.Last().Controls.Add(flightDepP);
            flightDepP.Location = new Point(L_flightDepPX, L_flightDepPY);
            flightDepP.Text = depP;
            flightDepP.Font = new Font("Oswald Light", 20f);
            flightDepP.AutoSize = true;

            Label flightDepT = new Label();
            int L_flightDepTX = L_flightDepPX, L_flightDepTY = L_flightDepPY + 40;
            Items.Last().Controls.Add(flightDepT);
            flightDepT.Location = new Point(L_flightDepTX, L_flightDepTY);
            flightDepT.Text = depT;
            flightDepT.Font = new Font("Oswald Light", 10f);
            flightDepT.AutoSize = true;

            Label arrow = new Label();
            int L_arrowX = L_flightDepPX + 15 * flightDepP.Text.Length,
                L_arrowY = L_flightDepPY;
            Items.Last().Controls.Add(arrow);
            arrow.Location = new Point(L_arrowX, L_arrowY);
            arrow.Text = "→";
            arrow.Font = new Font("Oswald Black;", 30f, FontStyle.Bold);
            arrow.AutoSize = true;

            Label flightDesP = new Label();
            int L_flightDesPX = L_arrowX + 80, L_flightDesPY = L_arrowY;
            Items.Last().Controls.Add(flightDesP);
            flightDesP.Location = new Point(L_flightDesPX, L_flightDesPY);
            flightDesP.Text = desP;
            flightDesP.Font = new Font("Oswald Light", 20f);
            flightDesP.AutoSize = true;

            Label flightDesT = new Label();
            int L_flightDesTX = L_flightDesPX, L_flightDesTY = L_flightDesPY + 40;
            Items.Last().Controls.Add(flightDesT);
            flightDesT.Location = new Point(L_flightDesTX, L_flightDesTY);
            flightDesT.Text = desT;
            flightDesT.Font = new Font("Oswald Light", 10f);
            flightDesT.AutoSize = true;

            Label L_carrier = new Label();
            int L_carrierX = 490,
                L_carrierY = L_flightDesPY;
            Items.Last().Controls.Add(L_carrier);
            L_carrier.Location = new Point(L_carrierX, L_carrierY);
            L_carrier.Text = carrier;
            L_carrier.Font = new Font("Oswald Light", 20f, FontStyle.Underline);
            L_carrier.AutoSize = true;

            Label flightPrice = new Label();
            int flightPriceX = 660,
                flightPriceY = L_carrierY + 10;
            Items.Last().Controls.Add(flightPrice);
            flightPrice.Location = new Point(flightPriceX, flightPriceY);
            flightPrice.Text = fPrice.Split(',')[0] + "₽";
            flightPrice.Font = new Font("Oswald Light", 15f, FontStyle.Underline);
            flightPrice.AutoSize = true;

            PictureBox filterPB = new PictureBox();
            int filterPBX = 15, filterPBY = 20;
            int filterPBH = 30, filterPBW = 30;
            Items.Last().Controls.Add(filterPB);
            filterPB.Location = new Point(filterPBX, filterPBY);
            filterPB.Image = Properties.Resources.greenCircle2;
            filterPB.Size = new Size(filterPBH, filterPBW);
            filterPB.Visible = false;

            Button B_ChooseSeats = new Button();
            int B_ChooseSeatsX = flightPriceX + 120,
                B_ChooseSeatsY = flightPriceY + 5;
            Items.Last().Controls.Add(B_ChooseSeats);
            B_ChooseSeats.Location = new Point(B_ChooseSeatsX, B_ChooseSeatsY);
            B_ChooseSeats.Text = "Купить билет";
            B_ChooseSeats.Font = new Font("Oswald", 10f);
            B_ChooseSeats.AutoSize = true;
            B_ChooseSeats.BackColor = SystemColors.MenuHighlight;
            B_ChooseSeats.ForeColor = Color.White;
            B_ChooseSeats.FlatStyle = FlatStyle.Flat;
            B_ChooseSeats.Cursor = Cursors.Hand;
            B_ChooseSeats.Click += BuyTicketButton_Click;

            Items.Last().Name = "BPanel" + i.ToString();
            flightDepP.Name = "L_depP";
            flightDepT.Name = "L_depT";
            flightDesP.Name = "L_desP";
            flightDesT.Name = "L_desT";
            flightPrice.Name = "L_flightPrice";
            filterPB.Name = "PB_filter";
            L_carrier.Name = "L_carrier";

            Items.Last().BackColor = Color.White;
            Items.Last().Location = new Point(X, Y);
            Items.Last().AutoSize = false;
            Items.Last().Size = new Size(W, H);
            Items.Last().Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            Items.Last().ForeColor = Color.Black;
            Items.Last().Visible = true;
            Items.Last().Font = new Font("Segoe UI", 10f, FontStyle.Regular);
            Items.Last().BorderStyle = BorderStyle.FixedSingle;
            //Items.Last().Cursor = Cursors.Hand;
            //Items.Last().Click += new EventHandler(Button_Click);
            //Items.Last().MouseEnter += new EventHandler(Panel_MouceEnter);
            //Items.Last().MouseLeave += new EventHandler(Panel_MouceLeave);
        }

        public void Clear()
        {
            for (int i = 0; i < Items.Count; i++)
            {
                Items[i].Dispose();
                Items.RemoveAt(i);
            }    
        }

        private void BuyTicketButton_Click(object sender, EventArgs e)
        {
            if (IsThereChoosenButtons)
                foreach (Panel item in Items) if (item.Enabled == false) item.Enabled = true;
            IsThereChoosenButtons = true;
            //((sender as Button).Parent as Panel).Enabled = false;

            if (_senderForm._isLogged)
            {
                RegistrationForm rf = new RegistrationForm(
                    _senderForm._flightsInfo[_senderForm.GetChoosenPanelIndex()], _senderForm._adultsCount,
                _senderForm._childrenCount, _senderForm._babiesCount, _senderForm._userId);

                rf.FormClosed += _senderForm.SearchResultForm_FormClosed;
                _senderForm.Hide();
                rf.ShowDialog();

            }
            else MessageBox.Show("Необходимо войти в систему!");
        }

        //private void Panel_MouceEnter(object sender, EventArgs e)
        //{
        //    Panel p = sender as Panel;
        //    p.BackColor = Color.WhiteSmoke;
        //}

        //private void Panel_MouceLeave(object sender, EventArgs e)
        //{
        //    Panel p = sender as Panel;
        //    p.BackColor = Color.White;
        //}
    }
}
