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
    public partial class Airbus_A320 : Form
    {
        private readonly List<SeatPictureBox> _seatsPictureBoxes;
        private readonly object[] _flightInfo;
        private string[][] _passengersInfo;
        private int _seatsChooseLimit;
        private int _adultsCount;
        private int _childrenCount;
        private int _babiesCount;
        private int _premiereSeatsChoosen;
        private int _economySeatsChoosen;
        private string _userId;
        private List<string> _ticketsIds;
        private bool _isDataInputDone;
        
        public Airbus_A320()
        {
            InitializeComponent();
        }

        public Airbus_A320(object[] flightInfo, string[][] passengersInfo, string userId)
        {
            InitializeComponent();

            _isDataInputDone = true;
            _seatsPictureBoxes = new List<SeatPictureBox>();
            _flightInfo = flightInfo;
            _passengersInfo = passengersInfo;
            _adultsCount = GetAdultsCount();
            _childrenCount = GetChildrenCount();
            _babiesCount = GetBabiesCount();
            _seatsChooseLimit = _adultsCount + _childrenCount;
            PremierePriceLabel.Text = Convert.ToString(flightInfo[13]);
            EconomyPriceLabel.Text = Convert.ToString(flightInfo[11]);
            BaggagePriceLabel.Text = Convert.ToString(flightInfo[6]);
            FlightPriceLabel.Text = Convert.ToString(_flightInfo[3]);
            ChildDiscountLabel.Text = Convert.ToString(_flightInfo[15]) + "%";
            BabyDiscountLabel.Text = Convert.ToString(_flightInfo[16]) + "%";
            SeatsCountNumLabel.Text = _seatsChooseLimit.ToString();
            BaggageCountNumericUpDown.Minimum = 1;
            BaggageCountNumericUpDown.Maximum = _seatsChooseLimit;
            _premiereSeatsChoosen = 0;
            _economySeatsChoosen = 0;
            _userId = userId;

            GetPremiereSeats();
            GetEconomySeats();
            GetSeatsConditions();
            LoadResultPanelInfo();
        }

        private void LoadResultPanelInfo()
        {
            PremiereCountLabel.Text = _premiereSeatsChoosen.ToString();
            EconomyCoutLabel.Text = _economySeatsChoosen.ToString();

            double childPercent = Convert.ToDouble(_flightInfo[3]) - 
                ((Convert.ToDouble(_flightInfo[3]) * 
                Convert.ToDouble(_flightInfo[15])) / 100);

            double babyPercent = Convert.ToDouble(_flightInfo[3]) - 
                ((Convert.ToDouble(_flightInfo[3]) *
                Convert.ToDouble(_flightInfo[16]))) / 100;

            FlightExpressionLabel.Text = Convert.ToString(_flightInfo[3])
                + " * " + _adultsCount.ToString() + " + " +
                childPercent + " * " + _childrenCount.ToString() + " + " +
                babyPercent + " * " + _babiesCount.ToString() + " = ";

            FlightSumLabel.Text = (Convert.ToDouble(
                _flightInfo[3]) * (double)_adultsCount + 
                (double)_childrenCount * childPercent + 
                (double)_babiesCount * babyPercent).ToString();

            PremiereExpressionLabel.Text = Convert.ToString(_flightInfo[12])
                + " * " + PremiereCountLabel.Text + " = ";

            PremiereSumLabel.Text = (Convert.ToDouble(
                _flightInfo[12]) * Convert.ToDouble(PremiereCountLabel.Text)).ToString();

            EconomyExpressionLabel.Text = Convert.ToString(_flightInfo[10])
                + " * " + EconomyCoutLabel.Text + " = ";

            EconomySumLabel.Text = (Convert.ToDouble(
                _flightInfo[10]) * Convert.ToDouble(EconomyCoutLabel.Text)).ToString();

            if (BaggageComboBox.Checked)
            {
                ResultNumLabel.Text = (Convert.ToDouble(PremiereSumLabel.Text) +
                Convert.ToDouble(EconomySumLabel.Text) +
                Convert.ToDouble(FlightSumLabel.Text) +
                Convert.ToDouble(BaggageCountNumericUpDown.Value) * 
                Convert.ToDouble(_flightInfo[14])).ToString();
            }
            else
            {
                ResultNumLabel.Text = (Convert.ToDouble(PremiereSumLabel.Text) +
                Convert.ToDouble(EconomySumLabel.Text) +
                Convert.ToDouble(FlightSumLabel.Text)).ToString();
            }
        }

        private void GetEconomySeats()
        {
            int startX = 134, startY = 588;
            int neighborY = 30;
            int X = startX, Y = startY;
            int row;

            for (int i = 0; i < 3; i++)
            {
                row = 6 + i;
                AddEconomyRow(X, Y, row);
                Y += neighborY;
                X = startX;
            }

            startX = 134; startY = 689;
            X = startX; Y = startY;
            row = 9;
            AddEconomyRow(X, Y, row);

            startX = 134; startY = 728;
            X = startX; Y = startY;

            for (int i = 0; i < 16; i++)
            {
                row = 10 + i;
                AddEconomyRow(X, Y, row);
                Y += neighborY;
                X = startX;
            }
        }

        private void AddEconomyRow(int X, int Y, int row)
        {
            int neighborX = 20, sNeighborX = 21;
            int distantNeiborX = 50;
            int W = 20, H = 23;
            int seatNum;

            seatNum = row * 6 - 5;
            AddEconomySeat(X, Y, W, H, row, seatNum);
            X += neighborX;
            seatNum = row * 6 - 4;
            AddEconomySeat(X, Y, W, H, row, seatNum);
            X += sNeighborX;
            seatNum = row * 6 - 3;
            AddEconomySeat(X, Y, W, H, row, seatNum);
            X += distantNeiborX;
            seatNum = row * 6 - 2;
            AddEconomySeat(X, Y, W, H, row, seatNum);
            X += neighborX;
            seatNum = row * 6 - 1;
            AddEconomySeat(X, Y, W, H, row, seatNum);
            X += sNeighborX;
            seatNum = row * 6;
            AddEconomySeat(X, Y, W, H, row, seatNum);
        }

        private void AddEconomySeat(int X, int Y, int W, int H, int row, int seatNum)
        {
            _seatsPictureBoxes.Add(new SeatPictureBox());
            PlaneSeatsPictureBox.Controls.Add(_seatsPictureBoxes.Last());
            _seatsPictureBoxes.Last().Location = new Point(X, Y);
            _seatsPictureBoxes.Last().Size = new Size(W, H);
            _seatsPictureBoxes.Last().Available = true;
            _seatsPictureBoxes.Last().IsChoosen = false;
            _seatsPictureBoxes.Last().Row = row;
            _seatsPictureBoxes.Last().Number = seatNum;
            _seatsPictureBoxes.Last().SeatClass = "Economy";
            _seatsPictureBoxes.Last().Image = Properties.Resources.airbus_320_EconomyUntakenSeat;
            _seatsPictureBoxes.Last().Visible = true;
            _seatsPictureBoxes.Last().Enabled = true;
            _seatsPictureBoxes.Last().Click += EconomySeatPictureBox_Click;
        }

        private void GetPremiereSeats()
        {
            int startX = 136, startY = 333;
            int neighborX = 29, neighborY = 47;
            int distantNeiborX = 66;
            int W = 25, H = 38;
            int X = startX, Y = startY;
            int row, seatNum;

            for (int i = 0; i < 5; i++)
            {
                row = i + 1;
                seatNum = row * 4 - 3;
                AddPremiereSeat(X, Y, W, H, row, seatNum);
                X += neighborX;
                seatNum = row * 4 - 2;
                AddPremiereSeat(X, Y, W, H, row, seatNum);
                X += distantNeiborX;
                seatNum = row * 4 - 1;
                AddPremiereSeat(X, Y, W, H, row, seatNum);
                X += neighborX;
                seatNum = row * 4;
                AddPremiereSeat(X, Y, W, H, row, seatNum);
                Y += neighborY;
                X = startX;
            }
        }

        private void AddPremiereSeat(int X, int Y, int W, int H, int row, int seatNum)
        {
            _seatsPictureBoxes.Add(new SeatPictureBox());
            PlaneSeatsPictureBox.Controls.Add(_seatsPictureBoxes.Last());
            _seatsPictureBoxes.Last().Location = new Point(X, Y);
            _seatsPictureBoxes.Last().Size = new Size(W, H);
            _seatsPictureBoxes.Last().Available = true;
            _seatsPictureBoxes.Last().IsChoosen = false;
            _seatsPictureBoxes.Last().Row = row;
            _seatsPictureBoxes.Last().Number = seatNum;
            _seatsPictureBoxes.Last().SeatClass = "Premier";
            _seatsPictureBoxes.Last().Image = Properties.Resources.airbus_320_PremierUntakenSeat;
            _seatsPictureBoxes.Last().Visible = true;
            _seatsPictureBoxes.Last().Enabled = true;
            _seatsPictureBoxes.Last().Click += PremiereSeatPictureBox_Click;
        }

        private void GetSeatsConditions()
        {
            string MyConString = Constants.DataBaseConnection;
            MySqlConnection connection = new MySqlConnection(MyConString);
            MySqlCommand SelectCommand = new MySqlCommand(String.Format(
                "SELECT * FROM view_operations " +
                "WHERE ID_f = {0}", _flightInfo[0]), connection);
            MySqlDataReader myReader;
            connection.Open();
            myReader = SelectCommand.ExecuteReader();

            List<int> takenSeats = new List<int>();

            while(myReader.Read())
            {
                takenSeats.Add(Convert.ToInt32(myReader["seatNum"]));
            }

            foreach (SeatPictureBox item in _seatsPictureBoxes)
            {
                myReader.Read();

                for (int i = 0; i < takenSeats.Count; i++)
                {
                    if (item.Number == takenSeats[i] && item.SeatClass == "Premier")
                    {
                        item.Image = Properties.Resources.airbus_320_PremierTakenSeat;
                        item.Available = false;
                        break;
                    }
                    if (item.Number == takenSeats[i] && item.SeatClass == "Economy")
                    {
                        item.Image = Properties.Resources.airbus_320_EconomyTakenSeat;
                        item.Available = false;
                        break;
                    }
                }
            }

            connection.Close();
        }

        private int GetAdultsCount()
        {
            int count = 0;

            for (int i = 0; i < _passengersInfo.Length; i++)
                if (_passengersInfo[i][7] == "Взрослый")
                    count++;

            return count;
        }

        private int GetChildrenCount()
        {
            int count = 0;

            for (int i = 0; i < _passengersInfo.Length; i++)
                if (_passengersInfo[i][7] == "Ребенок")
                    count++;

            return count;
        }

        private int GetBabiesCount()
        {
            int count = 0;

            for (int i = 0; i < _passengersInfo.Length; i++)
                if (_passengersInfo[i][7] == "Младенец")
                    count++;

            return count;
        }

        private List<string> GetChoosenSeats()
        {
            List<string> seats = new List<string>();
            int founded = 0;

            for (int i = 0; founded < _adultsCount + _childrenCount; i++)
            {
                if (_seatsPictureBoxes[i].IsChoosen)
                {
                    founded++;
                    seats.Add(_seatsPictureBoxes[i].Number.ToString());
                }
            }

            return seats;
        }

        private List<string> GetChoosenSeatsTypes()
        {
            List<string> seats = new List<string>();
            int founded = 0;

            for (int i = 0; founded < _adultsCount + _childrenCount; i++)
            {
                if (_seatsPictureBoxes[i].IsChoosen)
                {
                    founded++;
                    seats.Add(_seatsPictureBoxes[i].SeatClass);
                }
            }

            return seats;
        }

        private string GetLastTicketId()
        {
            string id = "";
            string MyConString = Constants.DataBaseConnection;
            MySqlConnection connection = new MySqlConnection(MyConString);
            MySqlCommand SelectCommand = new MySqlCommand(
                "SELECT * FROM tickets " +
                "WHERE ID_ticket = (SELECT max(ID_ticket) FROM tickets)", connection);
            MySqlDataReader myReader;

            connection.Open();
            myReader = SelectCommand.ExecuteReader();
            myReader.Read();
            id = myReader["ID_ticket"].ToString();
            connection.Close();

            return id;
        }

        private void InputInfoInBase()
        {
            _isDataInputDone = false;
            string myConString = Constants.DataBaseConnection;
            MySqlConnection connection = new MySqlConnection(myConString);
            List<string> seatsNums = GetChoosenSeats();
            List<string> seatsTypes = GetChoosenSeatsTypes();
            _ticketsIds = new List<string>();
            int baggageCount = Convert.ToInt32(BaggageCountNumericUpDown.Value);
            int seatNumIndex = 0;
            connection.Open();
            
            for (int i = 0; i < _passengersInfo.Length; i++)
            {
                int baggageNum = 0;
                string seatNum = "";
                string seatType = "";
                double baggagePrice = 0.0;

                if (_passengersInfo[i][7] != "Младенец")
                {
                    seatType = seatsTypes[i];
                    seatNum = seatsNums[seatNumIndex];
                    seatNumIndex++;
                    if (baggageCount != 0)
                    {
                        baggagePrice = Convert.ToDouble(_flightInfo[14]);
                        baggageNum = 1;
                        baggageCount--;
                    }
                    else
                    {
                        baggageNum = 0;
                        baggagePrice = 0.0;
                    }
                }
                else
                {
                    seatType = "-";
                    seatNum = "0";
                    baggageNum = 0;
                }

                if (_passengersInfo[i][2] == "" && _passengersInfo[i][3] == "")
                {
                    _passengersInfo[i][2] = "-";
                    _passengersInfo[i][3] = "-";
                }    

                MySqlCommand inputInfoInTicketsTable = new MySqlCommand(
                        String.Format("INSERT INTO tickets " +
                        "(ID_f, seatTakerFirstName, seatTakerLastName," +
                        " passportSeries, passportNumber, birthCertificate, seatNum, " +
                        "ticketType, baggageNum, seatType) " +
                        "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}')",
                        _flightInfo[0], _passengersInfo[i][0], _passengersInfo[i][1],
                        _passengersInfo[i][2], _passengersInfo[i][3],
                        _passengersInfo[i][4] + "-" + _passengersInfo[i][5] + " " + _passengersInfo[i][6],
                        Convert.ToInt32(seatNum), _passengersInfo[i][7], baggageNum,
                        seatType), connection);
                inputInfoInTicketsTable.ExecuteNonQuery();
                _ticketsIds.Add(GetLastTicketId());

                double adultPrice = Convert.ToDouble(_flightInfo[3]);
                double childPrice = Convert.ToDouble(_flightInfo[3]) -
                    ((Convert.ToDouble(_flightInfo[3]) *
                    Convert.ToDouble(_flightInfo[15])) / 100);
                double babyPrice = Convert.ToDouble(_flightInfo[3]) -
                    ((Convert.ToDouble(_flightInfo[3]) *
                    Convert.ToDouble(_flightInfo[16])) / 100);
                double economyPrice = Convert.ToDouble(_flightInfo[10]);
                double premierePrice = Convert.ToDouble(_flightInfo[12]);
                double opPrice = 0.0;

                if (_passengersInfo[i][7] == "Взрослый" && seatType == "Economy")
                    opPrice = adultPrice + economyPrice;
                if (_passengersInfo[i][7] == "Взрослый" && seatType == "Premier")
                    opPrice = adultPrice + premierePrice;
                if (_passengersInfo[i][7] == "Ребенок" && seatType == "Economy")
                    opPrice = childPrice + economyPrice;
                if (_passengersInfo[i][7] == "Ребенок" && seatType == "Premier")
                    opPrice = childPrice + premierePrice;
                if (_passengersInfo[i][7] == "Младенец" && seatType == "Economy")
                    opPrice = babyPrice;
                if (_passengersInfo[i][7] == "Младенец" && seatType == "Premier")
                    opPrice = babyPrice;

                opPrice += baggagePrice;

                MySqlCommand inputInfoInOperationsTable = new MySqlCommand(
                        String.Format("INSERT INTO operations " +
                        "(ID_cl, oDateTime, ID_t, opPrice) " +
                        "VALUES ('{0}', '{1}', '{2}', '{3}')",
                        Convert.ToInt32(_userId), DateTime.Now.ToString("yyyy:MM:dd HH:mm:ss"), 
                        Convert.ToInt32(GetLastTicketId()), Convert.ToDecimal(opPrice)), connection);
                inputInfoInOperationsTable.ExecuteNonQuery();

                if (_passengersInfo[i][7] != "Младенец")
                {
                    MySqlCommand updateSoldSeats  = new MySqlCommand(
                        String.Format(
                            "UPDATE flights SET soldSeats = soldSeats + 1 " +
                            "WHERE ID_f = '{0}'", _flightInfo[0]), connection);
                    updateSoldSeats.ExecuteNonQuery();
                }
            }

            connection.Close();
            _isDataInputDone = true;
        }

        private void EconomySeatPictureBox_Click(object sender, EventArgs e)
        {
            if (((SeatPictureBox)sender).Available == false)
                return;

            if (((SeatPictureBox)sender).IsChoosen == false)
            {
                if (_seatsChooseLimit == 0)
                {
                    MessageBox.Show("Число выбранных мест больше, чем было заказано");
                    return;
                }
                ((SeatPictureBox)sender).Image = Properties.Resources.airbus_320_EconomyChoosenSeat;
                ((SeatPictureBox)sender).IsChoosen = true;
                _seatsChooseLimit--;
                _economySeatsChoosen++;
            }
            else
            {
                ((SeatPictureBox)sender).Image = Properties.Resources.airbus_320_EconomyUntakenSeat;
                ((SeatPictureBox)sender).IsChoosen = false;
                _seatsChooseLimit++;
                _economySeatsChoosen--;
            }
            LoadResultPanelInfo();
        }

        private void PremiereSeatPictureBox_Click(object sender, EventArgs e)
        {
            if (((SeatPictureBox)sender).Available == false)
                return;

            if (((SeatPictureBox)sender).IsChoosen == false)
            {
                if (_seatsChooseLimit == 0)
                {
                    MessageBox.Show("Число выбранных мест больше, чем было заказано");
                    return;
                }
                ((SeatPictureBox)sender).Image = Properties.Resources.airbus_320_PremierChoosenSeat;
                ((SeatPictureBox)sender).IsChoosen = true;
                _seatsChooseLimit--;
                _premiereSeatsChoosen++;
            }
            else
            {
                ((SeatPictureBox)sender).Image = Properties.Resources.airbus_320_PremierUntakenSeat;
                ((SeatPictureBox)sender).IsChoosen = false;
                _seatsChooseLimit++;
                _premiereSeatsChoosen--;
            }
            LoadResultPanelInfo();
        }

        private void GoBackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StartRegistrationButton_Click(object sender, EventArgs e)
        {
            if (_seatsChooseLimit != 0)
            {
                MessageBox.Show("Выбрано недостаточно мест, чем было заказано");
                return;
            }

            DialogResult result = MessageBox.Show("Купить выбранные места?", 
                "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                //SQL Manipultions here
                InputInfoInBase();
                //

                FinalForm ff = new FinalForm(_ticketsIds);
                ff.FormClosed += Airbus_A320_FormClosed;
                this.Hide();
                ff.ShowDialog();
                this.Show();
            }
        }

        private void BaggageCheckBox_Click(object sender, EventArgs e)
        {
            if (BaggageComboBox.Checked) BaggageCountNumericUpDown.Enabled = true;
            else BaggageCountNumericUpDown.Enabled = false;
            LoadResultPanelInfo();
        }

        private void BaggageCountNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            LoadResultPanelInfo();
        }

        private void Airbus_A320_FormClosed(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Airbus_A320_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_isDataInputDone)
            {
                e.Cancel = true;
                MessageBox.Show("Приложение не может быть закрыто, т.к. ведется работа с базой данных!");
            }
        }
    }
}
