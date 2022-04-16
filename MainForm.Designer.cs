
namespace Kursovaya_AirBookingSystem
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.SelectPage = new System.Windows.Forms.TabPage();
            this.SearchPanel = new System.Windows.Forms.Panel();
            this.BabiesCountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.ChildrenCountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.AdultsCountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.SearchFlightsButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DepartureTimeDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.DestinationsComboBox = new System.Windows.Forms.ComboBox();
            this.DeparturesComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.PPersonalArea = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.ChartsTabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.cartesianChart2 = new LiveCharts.WinForms.CartesianChart();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label14 = new System.Windows.Forms.Label();
            this.PurchaseHistoryPanel = new System.Windows.Forms.Panel();
            this.HeaderPanel = new System.Windows.Forms.Panel();
            this.LUserFullName = new System.Windows.Forms.Label();
            this.UserLabel = new System.Windows.Forms.Label();
            this.ExitPersonalAreaButton = new System.Windows.Forms.Button();
            this.PLogReg = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TBFName = new System.Windows.Forms.TextBox();
            this.BRegistration = new System.Windows.Forms.Button();
            this.MTBRegPhone = new System.Windows.Forms.MaskedTextBox();
            this.TBLName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MTBPhoneNumber = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.BLogIn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dSroutesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.routesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TabControl.SuspendLayout();
            this.SelectPage.SuspendLayout();
            this.SearchPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BabiesCountNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChildrenCountNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AdultsCountNumericUpDown)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.PPersonalArea.SuspendLayout();
            this.ChartsTabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.HeaderPanel.SuspendLayout();
            this.PLogReg.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSroutesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.routesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.SelectPage);
            this.TabControl.Controls.Add(this.tabPage2);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.Font = new System.Drawing.Font("Oswald", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TabControl.Location = new System.Drawing.Point(0, 0);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(1368, 734);
            this.TabControl.TabIndex = 2;
            // 
            // SelectPage
            // 
            this.SelectPage.Controls.Add(this.SearchPanel);
            this.SelectPage.Location = new System.Drawing.Point(4, 35);
            this.SelectPage.Name = "SelectPage";
            this.SelectPage.Padding = new System.Windows.Forms.Padding(3);
            this.SelectPage.Size = new System.Drawing.Size(1360, 695);
            this.SelectPage.TabIndex = 0;
            this.SelectPage.Text = "Поиск билетов";
            this.SelectPage.UseVisualStyleBackColor = true;
            // 
            // SearchPanel
            // 
            this.SearchPanel.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.SearchPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SearchPanel.Controls.Add(this.BabiesCountNumericUpDown);
            this.SearchPanel.Controls.Add(this.ChildrenCountNumericUpDown);
            this.SearchPanel.Controls.Add(this.label13);
            this.SearchPanel.Controls.Add(this.label12);
            this.SearchPanel.Controls.Add(this.label11);
            this.SearchPanel.Controls.Add(this.AdultsCountNumericUpDown);
            this.SearchPanel.Controls.Add(this.SearchFlightsButton);
            this.SearchPanel.Controls.Add(this.label5);
            this.SearchPanel.Controls.Add(this.label4);
            this.SearchPanel.Controls.Add(this.DepartureTimeDateTimePicker);
            this.SearchPanel.Controls.Add(this.DestinationsComboBox);
            this.SearchPanel.Controls.Add(this.DeparturesComboBox);
            this.SearchPanel.Controls.Add(this.label3);
            this.SearchPanel.Controls.Add(this.label2);
            this.SearchPanel.Controls.Add(this.label1);
            this.SearchPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchPanel.Location = new System.Drawing.Point(3, 3);
            this.SearchPanel.Name = "SearchPanel";
            this.SearchPanel.Size = new System.Drawing.Size(1354, 689);
            this.SearchPanel.TabIndex = 1;
            // 
            // BabiesCountNumericUpDown
            // 
            this.BabiesCountNumericUpDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BabiesCountNumericUpDown.Font = new System.Drawing.Font("Oswald", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BabiesCountNumericUpDown.Location = new System.Drawing.Point(1134, 237);
            this.BabiesCountNumericUpDown.Name = "BabiesCountNumericUpDown";
            this.BabiesCountNumericUpDown.Size = new System.Drawing.Size(95, 39);
            this.BabiesCountNumericUpDown.TabIndex = 20;
            this.BabiesCountNumericUpDown.ValueChanged += new System.EventHandler(this.BabiesCountNumericUpDown_ValueChanged);
            // 
            // ChildrenCountNumericUpDown
            // 
            this.ChildrenCountNumericUpDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ChildrenCountNumericUpDown.Font = new System.Drawing.Font("Oswald", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChildrenCountNumericUpDown.Location = new System.Drawing.Point(1033, 239);
            this.ChildrenCountNumericUpDown.Name = "ChildrenCountNumericUpDown";
            this.ChildrenCountNumericUpDown.Size = new System.Drawing.Size(95, 39);
            this.ChildrenCountNumericUpDown.TabIndex = 19;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.SystemColors.Window;
            this.label13.Location = new System.Drawing.Point(3, 661);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(223, 26);
            this.label13.TabIndex = 18;
            this.label13.Text = "*На одного взрослого - один младенец";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Oswald Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.ForeColor = System.Drawing.SystemColors.Window;
            this.label12.Location = new System.Drawing.Point(1128, 204);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(95, 32);
            this.label12.TabIndex = 17;
            this.label12.Text = "Младенцы*";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Oswald Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.ForeColor = System.Drawing.SystemColors.Window;
            this.label11.Location = new System.Drawing.Point(1027, 204);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 32);
            this.label11.TabIndex = 16;
            this.label11.Text = "Дети";
            // 
            // AdultsCountNumericUpDown
            // 
            this.AdultsCountNumericUpDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AdultsCountNumericUpDown.Font = new System.Drawing.Font("Oswald", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AdultsCountNumericUpDown.Location = new System.Drawing.Point(932, 239);
            this.AdultsCountNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.AdultsCountNumericUpDown.Name = "AdultsCountNumericUpDown";
            this.AdultsCountNumericUpDown.Size = new System.Drawing.Size(95, 39);
            this.AdultsCountNumericUpDown.TabIndex = 13;
            this.AdultsCountNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // SearchFlightsButton
            // 
            this.SearchFlightsButton.BackColor = System.Drawing.SystemColors.Window;
            this.SearchFlightsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SearchFlightsButton.Font = new System.Drawing.Font("Oswald", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SearchFlightsButton.Location = new System.Drawing.Point(151, 286);
            this.SearchFlightsButton.Name = "SearchFlightsButton";
            this.SearchFlightsButton.Size = new System.Drawing.Size(1078, 45);
            this.SearchFlightsButton.TabIndex = 12;
            this.SearchFlightsButton.Text = "Найти";
            this.SearchFlightsButton.UseVisualStyleBackColor = false;
            this.SearchFlightsButton.Click += new System.EventHandler(this.SearchTicketsButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Oswald Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.SystemColors.Window;
            this.label5.Location = new System.Drawing.Point(926, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 32);
            this.label5.TabIndex = 11;
            this.label5.Text = "Взрослые";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Oswald Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.SystemColors.Window;
            this.label4.Location = new System.Drawing.Point(697, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 32);
            this.label4.TabIndex = 9;
            this.label4.Text = "Когда";
            // 
            // DepartureTimeDateTimePicker
            // 
            this.DepartureTimeDateTimePicker.CalendarFont = new System.Drawing.Font("Oswald", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DepartureTimeDateTimePicker.CalendarTitleBackColor = System.Drawing.SystemColors.Menu;
            this.DepartureTimeDateTimePicker.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DepartureTimeDateTimePicker.Font = new System.Drawing.Font("Oswald", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DepartureTimeDateTimePicker.Location = new System.Drawing.Point(703, 241);
            this.DepartureTimeDateTimePicker.MinDate = new System.DateTime(2021, 12, 30, 0, 0, 0, 0);
            this.DepartureTimeDateTimePicker.Name = "DepartureTimeDateTimePicker";
            this.DepartureTimeDateTimePicker.Size = new System.Drawing.Size(223, 39);
            this.DepartureTimeDateTimePicker.TabIndex = 7;
            // 
            // DestinationsComboBox
            // 
            this.DestinationsComboBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DestinationsComboBox.DisplayMember = "destinationP";
            this.DestinationsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DestinationsComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DestinationsComboBox.Font = new System.Drawing.Font("Oswald", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DestinationsComboBox.FormattingEnabled = true;
            this.DestinationsComboBox.Location = new System.Drawing.Point(427, 243);
            this.DestinationsComboBox.Name = "DestinationsComboBox";
            this.DestinationsComboBox.Size = new System.Drawing.Size(270, 37);
            this.DestinationsComboBox.TabIndex = 6;
            this.DestinationsComboBox.ValueMember = "destinationP";
            // 
            // DeparturesComboBox
            // 
            this.DeparturesComboBox.BackColor = System.Drawing.SystemColors.Window;
            this.DeparturesComboBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DeparturesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DeparturesComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DeparturesComboBox.Font = new System.Drawing.Font("Oswald", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeparturesComboBox.FormattingEnabled = true;
            this.DeparturesComboBox.Location = new System.Drawing.Point(151, 243);
            this.DeparturesComboBox.Name = "DeparturesComboBox";
            this.DeparturesComboBox.Size = new System.Drawing.Size(270, 37);
            this.DeparturesComboBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Oswald Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.Window;
            this.label3.Location = new System.Drawing.Point(421, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 32);
            this.label3.TabIndex = 4;
            this.label3.Text = "Куда";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Oswald Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.Window;
            this.label2.Location = new System.Drawing.Point(145, 208);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 32);
            this.label2.TabIndex = 3;
            this.label2.Text = "Откуда";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Oswald", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(478, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(448, 86);
            this.label1.TabIndex = 0;
            this.label1.Text = "Поиск билетов";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.PPersonalArea);
            this.tabPage2.Controls.Add(this.PLogReg);
            this.tabPage2.Location = new System.Drawing.Point(4, 35);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1360, 695);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Личный кабинет";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // PPersonalArea
            // 
            this.PPersonalArea.Controls.Add(this.label15);
            this.PPersonalArea.Controls.Add(this.ChartsTabControl);
            this.PPersonalArea.Controls.Add(this.pictureBox2);
            this.PPersonalArea.Controls.Add(this.label14);
            this.PPersonalArea.Controls.Add(this.PurchaseHistoryPanel);
            this.PPersonalArea.Controls.Add(this.HeaderPanel);
            this.PPersonalArea.Controls.Add(this.ExitPersonalAreaButton);
            this.PPersonalArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PPersonalArea.Location = new System.Drawing.Point(3, 3);
            this.PPersonalArea.Name = "PPersonalArea";
            this.PPersonalArea.Size = new System.Drawing.Size(1354, 689);
            this.PPersonalArea.TabIndex = 10;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Oswald", 14.25F);
            this.label15.Location = new System.Drawing.Point(727, 59);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(76, 32);
            this.label15.TabIndex = 10;
            this.label15.Text = "Графики";
            // 
            // ChartsTabControl
            // 
            this.ChartsTabControl.Controls.Add(this.tabPage1);
            this.ChartsTabControl.Controls.Add(this.tabPage3);
            this.ChartsTabControl.Location = new System.Drawing.Point(729, 93);
            this.ChartsTabControl.Name = "ChartsTabControl";
            this.ChartsTabControl.SelectedIndex = 0;
            this.ChartsTabControl.Size = new System.Drawing.Size(620, 515);
            this.ChartsTabControl.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cartesianChart1);
            this.tabPage1.Controls.Add(this.reportViewer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 35);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(612, 476);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Количество поездок по городам";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cartesianChart1.Location = new System.Drawing.Point(3, 3);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(606, 470);
            this.cartesianChart1.TabIndex = 0;
            this.cartesianChart1.Text = "cartesianChart1";
            // 
            // reportViewer1
            // 
            this.reportViewer1.DocumentMapWidth = 97;
            this.reportViewer1.Enabled = false;
            this.reportViewer1.Location = new System.Drawing.Point(-714, 462);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(99, 74);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Visible = false;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.cartesianChart2);
            this.tabPage3.Location = new System.Drawing.Point(4, 35);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(612, 476);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "Траты на полеты по датам";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // cartesianChart2
            // 
            this.cartesianChart2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cartesianChart2.Location = new System.Drawing.Point(3, 3);
            this.cartesianChart2.Name = "cartesianChart2";
            this.cartesianChart2.Size = new System.Drawing.Size(606, 470);
            this.cartesianChart2.TabIndex = 0;
            this.cartesianChart2.Text = "cartesianChart2";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = global::Kursovaya_AirBookingSystem.Properties.Resources.icons8_обновить_30;
            this.pictureBox2.Location = new System.Drawing.Point(1315, 62);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 30);
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.UpdateInfoPictureBox_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Oswald", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.Location = new System.Drawing.Point(5, 59);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(132, 32);
            this.label14.TabIndex = 6;
            this.label14.Text = "История покупок";
            // 
            // PurchaseHistoryPanel
            // 
            this.PurchaseHistoryPanel.AutoScroll = true;
            this.PurchaseHistoryPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PurchaseHistoryPanel.Location = new System.Drawing.Point(5, 93);
            this.PurchaseHistoryPanel.Name = "PurchaseHistoryPanel";
            this.PurchaseHistoryPanel.Size = new System.Drawing.Size(718, 591);
            this.PurchaseHistoryPanel.TabIndex = 5;
            // 
            // HeaderPanel
            // 
            this.HeaderPanel.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.HeaderPanel.Controls.Add(this.LUserFullName);
            this.HeaderPanel.Controls.Add(this.UserLabel);
            this.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.Size = new System.Drawing.Size(1354, 56);
            this.HeaderPanel.TabIndex = 0;
            // 
            // LUserFullName
            // 
            this.LUserFullName.AutoSize = true;
            this.LUserFullName.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.LUserFullName.Font = new System.Drawing.Font("Oswald Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LUserFullName.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.LUserFullName.Location = new System.Drawing.Point(117, 11);
            this.LUserFullName.Name = "LUserFullName";
            this.LUserFullName.Size = new System.Drawing.Size(64, 32);
            this.LUserFullName.TabIndex = 1;
            this.LUserFullName.Text = "label10";
            // 
            // UserLabel
            // 
            this.UserLabel.AutoSize = true;
            this.UserLabel.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.UserLabel.Font = new System.Drawing.Font("Oswald Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UserLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.UserLabel.Location = new System.Drawing.Point(8, 11);
            this.UserLabel.Name = "UserLabel";
            this.UserLabel.Size = new System.Drawing.Size(114, 32);
            this.UserLabel.TabIndex = 0;
            this.UserLabel.Text = "Пользователь:";
            // 
            // ExitPersonalAreaButton
            // 
            this.ExitPersonalAreaButton.Font = new System.Drawing.Font("Oswald", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExitPersonalAreaButton.Location = new System.Drawing.Point(729, 614);
            this.ExitPersonalAreaButton.Name = "ExitPersonalAreaButton";
            this.ExitPersonalAreaButton.Size = new System.Drawing.Size(620, 70);
            this.ExitPersonalAreaButton.TabIndex = 3;
            this.ExitPersonalAreaButton.Text = "Выйти из личного кабинета";
            this.ExitPersonalAreaButton.UseVisualStyleBackColor = true;
            this.ExitPersonalAreaButton.Click += new System.EventHandler(this.ExitPersonalAreaButton_Click);
            // 
            // PLogReg
            // 
            this.PLogReg.BackColor = System.Drawing.Color.White;
            this.PLogReg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PLogReg.Controls.Add(this.groupBox2);
            this.PLogReg.Controls.Add(this.groupBox1);
            this.PLogReg.Controls.Add(this.pictureBox1);
            this.PLogReg.Controls.Add(this.label9);
            this.PLogReg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PLogReg.Location = new System.Drawing.Point(3, 3);
            this.PLogReg.Name = "PLogReg";
            this.PLogReg.Size = new System.Drawing.Size(1354, 689);
            this.PLogReg.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.TBFName);
            this.groupBox2.Controls.Add(this.BRegistration);
            this.groupBox2.Controls.Add(this.MTBRegPhone);
            this.groupBox2.Controls.Add(this.TBLName);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Font = new System.Drawing.Font("Oswald Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(13, 277);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(231, 407);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Регистрация";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Oswald Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(5, 145);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 22);
            this.label10.TabIndex = 4;
            this.label10.Text = "Номер телефона";
            // 
            // TBFName
            // 
            this.TBFName.Location = new System.Drawing.Point(6, 52);
            this.TBFName.Name = "TBFName";
            this.TBFName.Size = new System.Drawing.Size(204, 31);
            this.TBFName.TabIndex = 5;
            // 
            // BRegistration
            // 
            this.BRegistration.BackColor = System.Drawing.SystemColors.Menu;
            this.BRegistration.Location = new System.Drawing.Point(6, 207);
            this.BRegistration.Name = "BRegistration";
            this.BRegistration.Size = new System.Drawing.Size(163, 38);
            this.BRegistration.TabIndex = 4;
            this.BRegistration.Text = "Зарегистрироваться";
            this.BRegistration.UseVisualStyleBackColor = false;
            this.BRegistration.Click += new System.EventHandler(this.RegistrationButton_Click);
            // 
            // MTBRegPhone
            // 
            this.MTBRegPhone.Location = new System.Drawing.Point(6, 170);
            this.MTBRegPhone.Mask = "+7(999) 000-0000";
            this.MTBRegPhone.Name = "MTBRegPhone";
            this.MTBRegPhone.Size = new System.Drawing.Size(204, 31);
            this.MTBRegPhone.TabIndex = 9;
            // 
            // TBLName
            // 
            this.TBLName.Location = new System.Drawing.Point(6, 111);
            this.TBLName.Name = "TBLName";
            this.TBLName.Size = new System.Drawing.Size(204, 31);
            this.TBLName.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Oswald Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(4, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 22);
            this.label7.TabIndex = 7;
            this.label7.Text = "Имя";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Oswald Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(5, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 22);
            this.label6.TabIndex = 8;
            this.label6.Text = "Фамилия";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.MTBPhoneNumber);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.BLogIn);
            this.groupBox1.Font = new System.Drawing.Font("Oswald Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(13, 126);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(231, 145);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Вход";
            // 
            // MTBPhoneNumber
            // 
            this.MTBPhoneNumber.Location = new System.Drawing.Point(6, 57);
            this.MTBPhoneNumber.Mask = "+7(999) 000-0000";
            this.MTBPhoneNumber.Name = "MTBPhoneNumber";
            this.MTBPhoneNumber.Size = new System.Drawing.Size(205, 31);
            this.MTBPhoneNumber.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Oswald Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(5, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 22);
            this.label8.TabIndex = 2;
            this.label8.Text = "Номер телефона";
            // 
            // BLogIn
            // 
            this.BLogIn.BackColor = System.Drawing.SystemColors.Menu;
            this.BLogIn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BLogIn.Location = new System.Drawing.Point(6, 92);
            this.BLogIn.Name = "BLogIn";
            this.BLogIn.Size = new System.Drawing.Size(93, 33);
            this.BLogIn.TabIndex = 3;
            this.BLogIn.Text = "Войти";
            this.BLogIn.UseVisualStyleBackColor = false;
            this.BLogIn.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::Kursovaya_AirBookingSystem.Properties.Resources.photo_1436491865332_7a61a109cc05;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(260, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1094, 684);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Oswald", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label9.Location = new System.Drawing.Point(48, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(150, 54);
            this.label9.TabIndex = 0;
            this.label9.Text = "AirBooking";
            // 
            // routesBindingSource
            // 
            this.routesBindingSource.DataMember = "routes";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1368, 734);
            this.Controls.Add(this.TabControl);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AirBooking";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.TabControl.ResumeLayout(false);
            this.SelectPage.ResumeLayout(false);
            this.SearchPanel.ResumeLayout(false);
            this.SearchPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BabiesCountNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChildrenCountNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AdultsCountNumericUpDown)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.PPersonalArea.ResumeLayout(false);
            this.PPersonalArea.PerformLayout();
            this.ChartsTabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.HeaderPanel.ResumeLayout(false);
            this.HeaderPanel.PerformLayout();
            this.PLogReg.ResumeLayout(false);
            this.PLogReg.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSroutesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.routesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage SelectPage;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel PLogReg;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TBLName;
        private System.Windows.Forms.TextBox TBFName;
        private System.Windows.Forms.Button BRegistration;
        private System.Windows.Forms.Button BLogIn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox MTBPhoneNumber;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox MTBRegPhone;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel PPersonalArea;
        private System.Windows.Forms.Panel HeaderPanel;
        private System.Windows.Forms.Label UserLabel;
        private System.Windows.Forms.Label LUserFullName;
        private System.Windows.Forms.Button ExitPersonalAreaButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel SearchPanel;
        private System.Windows.Forms.NumericUpDown AdultsCountNumericUpDown;
        private System.Windows.Forms.Button SearchFlightsButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker DepartureTimeDateTimePicker;
        public System.Windows.Forms.ComboBox DestinationsComboBox;
        public System.Windows.Forms.ComboBox DeparturesComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown BabiesCountNumericUpDown;
        private System.Windows.Forms.NumericUpDown ChildrenCountNumericUpDown;
        private System.Windows.Forms.Panel PurchaseHistoryPanel;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.TabControl ChartsTabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label15;
        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private LiveCharts.WinForms.CartesianChart cartesianChart2;
        private System.Windows.Forms.BindingSource dSroutesBindingSource;
        private System.Windows.Forms.BindingSource routesBindingSource;
    }
}

