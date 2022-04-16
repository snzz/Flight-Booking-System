using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;

namespace Kursovaya_AirBookingSystem
{
    public partial class RegistrationForm : Form
    {
        private readonly object[] _flightInfo;
        private readonly int _adultsCount;
        private readonly int _childrenCount;
        private readonly int _babiesCount;
        private readonly string _userId;
        private InputInfoPanelCreator _creator;

        public RegistrationForm()
        {
            InitializeComponent();
        }

        public RegistrationForm(object[] flightInfo, int adultsCount, int childrenCount, 
            int babiesCount, string userId)
        {
            InitializeComponent();
            _creator = new InputInfoPanelCreator(this);
            _flightInfo = flightInfo;
            _adultsCount = adultsCount;
            _childrenCount = childrenCount;
            _babiesCount = babiesCount;
            _userId = userId;
            
            GenerateInputInfoPanel();
        }

        private void GenerateInputInfoPanel()
        {
            for (int i = 0; i < _adultsCount; i++)
                _creator.AddPanel(0);

            for (int i = 0; i < _childrenCount; i++)
                _creator.AddPanel(1);

            for (int i = 0; i < _babiesCount; i++)
                _creator.AddPanel(2);
        }

        private bool IsDataCorrect()
        {
            Panel p;

            for (int i = 0; i < _adultsCount; i++)
            {
                p = _creator.Items[i];

                if ((p.Controls["TB_FName"] as TextBox).Text == "")
                    return false;
                if ((p.Controls["TB_LName"] as TextBox).Text == "")
                    return false;
                if ((p.Controls["TB_PassportSeries"] as TextBox).Text.Length != 4)
                    return false;
                if ((p.Controls["TB_PassportNum"] as TextBox).Text.Length != 6)
                    return false;
            }

            for (int i = _adultsCount; i < _creator.Items.Count; i++)
            {
                p = _creator.Items[i];

                if ((p.Controls["TB_FName"] as TextBox).Text == "")
                    return false;
                if ((p.Controls["TB_LName"] as TextBox).Text == "")
                    return false;
                if ((p.Controls["TB_BCFirstNum"] as TextBox).Text == "")
                    return false;
                if ((p.Controls["TB_BCLetters"] as TextBox).Text.Length != 2)
                    return false;
                if ((p.Controls["TB_BCLastNum"] as TextBox).Text.Length != 6)
                    return false;
            }

            return true;
        }

        private void FindIncorrectData()
        {
            for (int i = 0; i < _adultsCount; i++)
            {
                Panel p = _creator.Items[i];

                if ((p.Controls["TB_FName"] as TextBox).Text == "")
                    (p.Controls["TB_FName"] as TextBox).BackColor = Color.Red;

                if ((p.Controls["TB_LName"] as TextBox).Text == "")
                    (p.Controls["TB_LName"] as TextBox).BackColor = Color.Red;

                if ((p.Controls["TB_PassportSeries"] as TextBox).Text.Length != 4)
                    (p.Controls["TB_PassportSeries"] as TextBox).BackColor = Color.Red;

                if ((p.Controls["TB_PassportNum"] as TextBox).Text.Length != 6)
                    (p.Controls["TB_PassportNum"] as TextBox).BackColor = Color.Red;
            }

            for (int i = _adultsCount; i < _creator.Items.Count; i++)
            {
                Panel p = _creator.Items[i];

                if ((p.Controls["TB_FName"] as TextBox).Text == "")
                    (p.Controls["TB_FName"] as TextBox).BackColor = Color.Red;

                if ((p.Controls["TB_LName"] as TextBox).Text == "")
                    (p.Controls["TB_LName"] as TextBox).BackColor = Color.Red;

                if ((p.Controls["TB_BCFirstNum"] as TextBox).Text == "")
                    (p.Controls["TB_BCFirstNum"] as TextBox).BackColor = Color.Red;

                if ((p.Controls["TB_BCLetters"] as TextBox).Text.Length != 2)
                    (p.Controls["TB_BCLetters"] as TextBox).BackColor = Color.Red;

                if ((p.Controls["TB_BCLastNum"] as TextBox).Text.Length != 6)
                    (p.Controls["TB_BCLastNum"] as TextBox).BackColor = Color.Red;
            }
        }

        private void GoBackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChooseSeatButton_Click(object sender, EventArgs e)
        {
            if (IsDataCorrect())
            {
                int passengersCount = _adultsCount + _childrenCount + _babiesCount;
                string[][] passengersInfo = new string[passengersCount][];
                
                for (int i = 0; i < passengersCount; i++)
                {
                    passengersInfo[i] = new string[] 
                    {
                        (_creator.Items[i].Controls["TB_FName"] as TextBox).Text,
                        (_creator.Items[i].Controls["TB_LName"] as TextBox).Text,
                        (_creator.Items[i].Controls["TB_PassportSeries"] as TextBox).Text,
                        (_creator.Items[i].Controls["TB_PassportNum"] as TextBox).Text,
                        (_creator.Items[i].Controls["TB_BCFirstNum"] as TextBox).Text,
                        (_creator.Items[i].Controls["TB_BCLetters"] as TextBox).Text,
                        (_creator.Items[i].Controls["TB_BCLastNum"] as TextBox).Text,
                        (_creator.Items[i].Controls["L_AgeType"] as Label).Text
                    };
                }

                string MyConString = Constants.DataBaseConnection;
                MySqlConnection connection = new MySqlConnection(MyConString);
                MySqlCommand SelectCommand = new MySqlCommand(String.Format(
                    "SELECT * FROM airplanes WHERE ID_ap = '{0}'", _flightInfo[6]), connection);
                MySqlDataReader myReader;

                connection.Open();
                myReader = SelectCommand.ExecuteReader();
                myReader.Read();
                string plane = Convert.ToString(myReader["model"]);

                if (plane == "Airbus A320")
                {
                    Airbus_A320 AA320 = new Airbus_A320(_flightInfo, passengersInfo, _userId);
                    AA320.FormClosed += RegistrationForm_FormClosed;
                    this.Hide();
                    AA320.ShowDialog();
                    this.Show();
                }
            }
            else
            {
                FindIncorrectData();
                MessageBox.Show("Данные заполнены неверно");
            }
        }

        private void RegistrationForm_FormClosed(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    class InputInfoPanelCreator
    {
        private readonly Panel _P_InputInfo;
        
        public List<Panel> Items { get; set; }

        public InputInfoPanelCreator(RegistrationForm senderForm)
        {
            Items = new List<Panel>();
            _P_InputInfo = senderForm.InputInfoPanel;
        }
        
        public void AddPanel(int humanType)
        {
            Items.Add(new Panel());

            int W, H;
            int X, Y;
            int distantBetweenPanels = 2;
            string type = "";

            _P_InputInfo.Controls.Add(Items.Last());

            X = 1;

            if (Items.Count == 1) Y = 1;
            else Y = Items[Items.Count - 2].Size.Height +
                    Items[Items.Count - 2].Location.Y + distantBetweenPanels;

            W = _P_InputInfo.Width - X * 2 - 2;
            H = 200;

            if (humanType == 0) type = "Взрослый";
            else if (humanType == 1) type = "Ребенок";
            else if (humanType == 2) type = "Младенец";

            Label L_Type = new Label();
            int L_TypeX = 2, L_TypeY = 2;
            Items.Last().Controls.Add(L_Type);
            L_Type.Location = new Point(L_TypeX, L_TypeY);
            L_Type.Text = type;
            L_Type.Font = new Font("Oswald", 20f);
            L_Type.AutoSize = true;

            Label L_FName = new Label();
            int L_FNameX = 20, L_FNameY = L_TypeY + 50;
            Items.Last().Controls.Add(L_FName);
            L_FName.Location = new Point(L_FNameX, L_FNameY);
            L_FName.Text = "Имя";
            L_FName.Font = new Font("Oswald Light", 12f);
            L_FName.AutoSize = true;

            TextBox TB_FName = new TextBox();
            int TB_FNameX = L_FNameX + 1, TB_FNameY = L_FNameY + 27;
            Items.Last().Controls.Add(TB_FName);
            TB_FName.Location = new Point(TB_FNameX, TB_FNameY);
            TB_FName.Font = new Font("Oswald Light", 12f);
            TB_FName.AutoSize = true;
            TB_FName.Width *= 2;
            TB_FName.MaxLength = 50;
            TB_FName.KeyPress += NamesTextBoxes_KeyPress;

            Label L_LName = new Label();
            int L_LNameX = L_FNameX + 250, L_LNameY = L_TypeY + 50;
            Items.Last().Controls.Add(L_LName);
            L_LName.Location = new Point(L_LNameX, L_LNameY);
            L_LName.Text = "Фамилия";
            L_LName.Font = new Font("Oswald Light", 12f);
            L_LName.AutoSize = true;

            TextBox TB_LName = new TextBox();
            int TB_LNameX = L_LNameX + 1, TB_LNameY = L_LNameY + 27;
            Items.Last().Controls.Add(TB_LName);
            TB_LName.Location = new Point(TB_LNameX, TB_LNameY);
            TB_LName.Font = new Font("Oswald Light", 12f);
            TB_LName.AutoSize = true;
            TB_LName.Width *= 2;
            TB_LName.Width += 21;
            TB_LName.MaxLength = 50;
            TB_LName.KeyPress += NamesTextBoxes_KeyPress;

            Label L_PassportSeries = new Label();
            int L_PassportSeriesX = L_FNameX, L_PassportSeriesY = TB_FNameY + 30;
            Items.Last().Controls.Add(L_PassportSeries);
            L_PassportSeries.Location = new Point(L_PassportSeriesX, L_PassportSeriesY);
            L_PassportSeries.Text = "Серия паспорта";
            L_PassportSeries.Font = new Font("Oswald Light", 12f);
            L_PassportSeries.AutoSize = true;

            TextBox TB_PassportSeries = new TextBox();
            int TB_PassportSeriesX = L_PassportSeriesX + 1, 
                TB_PassportSeriesY = L_PassportSeriesY + 27;
            Items.Last().Controls.Add(TB_PassportSeries);
            TB_PassportSeries.Location = new Point(TB_PassportSeriesX, TB_PassportSeriesY);
            TB_PassportSeries.Font = new Font("Oswald Light", 12f);
            TB_PassportSeries.AutoSize = true;
            TB_PassportSeries.Width -= 5;
            TB_PassportSeries.MaxLength = 4;
            TB_PassportSeries.KeyPress += NumbersTextBoxes_KeyPress;
            if (humanType != 0) TB_PassportSeries.Enabled = false;

            Label L_PassportNum = new Label();
            int L_PassportNumX = L_PassportSeriesX + 100, 
                L_PassportNumY = L_PassportSeriesY;
            Items.Last().Controls.Add(L_PassportNum);
            L_PassportNum.Location = new Point(L_PassportNumX, L_PassportNumY);
            L_PassportNum.Text = "Номер паспорта";
            L_PassportNum.Font = new Font("Oswald Light", 12f);
            L_PassportNum.AutoSize = true;

            TextBox TB_PassportNum = new TextBox();
            int TB_PassportNumX = L_PassportNumX + 1,
                TB_PassportNumY = L_PassportNumY + 27;
            Items.Last().Controls.Add(TB_PassportNum);
            TB_PassportNum.Location = new Point(TB_PassportNumX, TB_PassportNumY);
            TB_PassportNum.Font = new Font("Oswald Light", 12f);
            TB_PassportNum.AutoSize = true;
            TB_PassportNum.MaxLength = 6;
            TB_PassportNum.KeyPress += NumbersTextBoxes_KeyPress;
            if (humanType != 0) TB_PassportNum.Enabled = false;

            Label L_BirthCertificate = new Label();
            int L_BirthCertificateX = L_LNameX,
                L_BirthCertificateY = L_PassportSeriesY;
            Items.Last().Controls.Add(L_BirthCertificate);
            L_BirthCertificate.Location = new Point(L_BirthCertificateX, L_BirthCertificateY);
            L_BirthCertificate.Text = "Свидетельство о рождении";
            L_BirthCertificate.Font = new Font("Oswald Light", 12f);
            L_BirthCertificate.AutoSize = true;

            TextBox TB_BCFirstNum = new TextBox();
            int TB_BCFirstNumX = L_BirthCertificateX,
                TB_BCFirstNumY = L_BirthCertificateY + 27;
            Items.Last().Controls.Add(TB_BCFirstNum);
            TB_BCFirstNum.Location = new Point(TB_BCFirstNumX, TB_BCFirstNumY);
            TB_BCFirstNum.Font = new Font("Oswald Light", 12f);
            TB_BCFirstNum.AutoSize = true;
            TB_BCFirstNum.Width = 70;
            TB_BCFirstNum.MaxLength = 7;
            TB_BCFirstNum.KeyPress += BirthCertificateFirstNumTextBox_KeyPress;
            if (humanType == 0) TB_BCFirstNum.Enabled = false;

            Label L_Hyphen = new Label();
            int L_HyphenX = TB_BCFirstNumX + 70,
                L_HyphenY = TB_BCFirstNumY;
            Items.Last().Controls.Add(L_Hyphen);
            L_Hyphen.Location = new Point(L_HyphenX, L_HyphenY);
            L_Hyphen.Text = "-";
            L_Hyphen.Font = new Font("Oswald Light", 12f, FontStyle.Bold);
            L_Hyphen.AutoSize = true;

            TextBox TB_BCLetters = new TextBox();
            int TB_BCLettersX = L_HyphenX + 17,
                TB_BCLettersY = L_HyphenY;
            Items.Last().Controls.Add(TB_BCLetters);
            TB_BCLetters.Location = new Point(TB_BCLettersX, TB_BCLettersY);
            TB_BCLetters.Font = new Font("Oswald Light", 12f);
            TB_BCLetters.AutoSize = true;
            TB_BCLetters.MaxLength = 2;
            TB_BCLetters.Width /= 2;
            TB_BCLetters.KeyPress += BirthCertificateLettersTextBox_KeyPress;
            if (humanType == 0) TB_BCLetters.Enabled = false;

            Label L_Num = new Label();
            int L_NumX = TB_BCLettersX + 50,
                L_NumY = TB_BCLettersY;
            Items.Last().Controls.Add(L_Num);
            L_Num.Location = new Point(L_NumX, L_NumY);
            L_Num.Text = "№";
            L_Num.Font = new Font("Oswald Light", 12f, FontStyle.Bold);
            L_Num.AutoSize = true;

            TextBox TB_BCLastNum = new TextBox();
            int TB_BCLastNumX = L_NumX + 25,
                TTB_BCLastNumY = L_NumY;
            Items.Last().Controls.Add(TB_BCLastNum);
            TB_BCLastNum.Location = new Point(TB_BCLastNumX, TTB_BCLastNumY);
            TB_BCLastNum.Font = new Font("Oswald Light", 12f);
            TB_BCLastNum.AutoSize = true;
            TB_BCLastNum.MaxLength = 6;
            TB_BCLastNum.Width /= 2;
            TB_BCLastNum.Width += 10;
            TB_BCLastNum.KeyPress += NumbersTextBoxes_KeyPress;
            if (humanType == 0) TB_BCLastNum.Enabled = false;

            TB_FName.Name = "TB_FName";
            TB_LName.Name = "TB_LName";
            TB_PassportSeries.Name = "TB_PassportSeries";
            TB_PassportNum.Name = "TB_PassportNum";
            TB_BCFirstNum.Name = "TB_BCFirstNum";
            TB_BCLetters.Name = "TB_BCLetters";
            TB_BCLastNum.Name = "TB_BCLastNum";
            L_Type.Name = "L_AgeType";

            Items.Last().BackColor = Color.White;
            Items.Last().Location = new Point(X, Y);
            Items.Last().AutoSize = false;
            Items.Last().Size = new Size(W, H);
            Items.Last().Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            Items.Last().ForeColor = Color.Black;
            Items.Last().Visible = true;
            Items.Last().BorderStyle = BorderStyle.FixedSingle;
        }

        private void BirthCertificateFirstNumTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;
            string[] symbs = new string[] 
            { 
                "I", "V", "X", "L", "C",
                "i", "v", "x", "l", "c"
            }; 

            if (!Char.IsLetter(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
            if (e.KeyChar != 8 && !symbs.Contains(e.KeyChar.ToString()))
                e.Handled = true;

            e.KeyChar = e.KeyChar.ToString().ToUpper().ToCharArray()[0];
            tb.BackColor = Color.White;
        }

        private void BirthCertificateLettersTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;

            if (!Char.IsLetter(e.KeyChar) && e.KeyChar != 8) 
                e.Handled = true;

            if (e.KeyChar != 8 && !Regex.IsMatch(e.KeyChar.ToString(), "^[А-Яа-я]+$")) 
                e.Handled = true;

            e.KeyChar = e.KeyChar.ToString().ToUpper().ToCharArray()[0];
            tb.BackColor = Color.White;
        }

        private void NamesTextBoxes_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (!Char.IsLetter(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
            tb.BackColor = Color.White;
        }

        private void NumbersTextBoxes_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
            tb.BackColor = Color.White;
        }
    }
}
