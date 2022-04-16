
namespace Kursovaya_AirBookingSystem
{
    partial class Airbus_A320
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
            this.P_planePB = new System.Windows.Forms.Panel();
            this.PlaneSeatsPictureBox = new System.Windows.Forms.PictureBox();
            this.RegistratePassengersButton = new System.Windows.Forms.Button();
            this.GoBackButton = new System.Windows.Forms.Button();
            this.PricesGroupBox = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.BabyDiscountLabel = new System.Windows.Forms.Label();
            this.ChildDiscountLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BaggagePriceLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.FlightPriceLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.EconomyPriceLabel = new System.Windows.Forms.Label();
            this.PremierePriceLabel = new System.Windows.Forms.Label();
            this.L_economy = new System.Windows.Forms.Label();
            this.L_premiere = new System.Windows.Forms.Label();
            this.ClienOrderGroupBox = new System.Windows.Forms.GroupBox();
            this.BaggageCountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.BaggageComboBox = new System.Windows.Forms.CheckBox();
            this.FlightSumLabel = new System.Windows.Forms.Label();
            this.FlightExpressionLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ResultNumLabel = new System.Windows.Forms.Label();
            this.EconomyCoutLabel = new System.Windows.Forms.Label();
            this.PremiereCountLabel = new System.Windows.Forms.Label();
            this.L_Result = new System.Windows.Forms.Label();
            this.EconomySumLabel = new System.Windows.Forms.Label();
            this.EconomyExpressionLabel = new System.Windows.Forms.Label();
            this.PremiereSumLabel = new System.Windows.Forms.Label();
            this.SeatsCountNumLabel = new System.Windows.Forms.Label();
            this.PremiereExpressionLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.L_PremiereSeats = new System.Windows.Forms.Label();
            this.L_seatsCount = new System.Windows.Forms.Label();
            this.P_planePB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PlaneSeatsPictureBox)).BeginInit();
            this.PricesGroupBox.SuspendLayout();
            this.ClienOrderGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BaggageCountNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // P_planePB
            // 
            this.P_planePB.AutoScroll = true;
            this.P_planePB.BackColor = System.Drawing.SystemColors.Window;
            this.P_planePB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.P_planePB.Controls.Add(this.PlaneSeatsPictureBox);
            this.P_planePB.Location = new System.Drawing.Point(12, 12);
            this.P_planePB.Name = "P_planePB";
            this.P_planePB.Size = new System.Drawing.Size(425, 700);
            this.P_planePB.TabIndex = 0;
            // 
            // PlaneSeatsPictureBox
            // 
            this.PlaneSeatsPictureBox.Image = global::Kursovaya_AirBookingSystem.Properties.Resources.Airbus_A320_Seats;
            this.PlaneSeatsPictureBox.Location = new System.Drawing.Point(3, 3);
            this.PlaneSeatsPictureBox.Name = "PlaneSeatsPictureBox";
            this.PlaneSeatsPictureBox.Size = new System.Drawing.Size(425, 1680);
            this.PlaneSeatsPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PlaneSeatsPictureBox.TabIndex = 0;
            this.PlaneSeatsPictureBox.TabStop = false;
            // 
            // RegistratePassengersButton
            // 
            this.RegistratePassengersButton.Font = new System.Drawing.Font("Oswald Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RegistratePassengersButton.Location = new System.Drawing.Point(443, 597);
            this.RegistratePassengersButton.Name = "RegistratePassengersButton";
            this.RegistratePassengersButton.Size = new System.Drawing.Size(424, 54);
            this.RegistratePassengersButton.TabIndex = 1;
            this.RegistratePassengersButton.Text = "Оформить";
            this.RegistratePassengersButton.UseVisualStyleBackColor = true;
            this.RegistratePassengersButton.Click += new System.EventHandler(this.StartRegistrationButton_Click);
            // 
            // GoBackButton
            // 
            this.GoBackButton.Font = new System.Drawing.Font("Oswald Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GoBackButton.Location = new System.Drawing.Point(443, 658);
            this.GoBackButton.Name = "GoBackButton";
            this.GoBackButton.Size = new System.Drawing.Size(424, 54);
            this.GoBackButton.TabIndex = 2;
            this.GoBackButton.Text = "Вернуться на главную";
            this.GoBackButton.UseVisualStyleBackColor = true;
            this.GoBackButton.Click += new System.EventHandler(this.GoBackButton_Click);
            // 
            // PricesGroupBox
            // 
            this.PricesGroupBox.Controls.Add(this.label7);
            this.PricesGroupBox.Controls.Add(this.BabyDiscountLabel);
            this.PricesGroupBox.Controls.Add(this.ChildDiscountLabel);
            this.PricesGroupBox.Controls.Add(this.label2);
            this.PricesGroupBox.Controls.Add(this.label1);
            this.PricesGroupBox.Controls.Add(this.BaggagePriceLabel);
            this.PricesGroupBox.Controls.Add(this.label6);
            this.PricesGroupBox.Controls.Add(this.FlightPriceLabel);
            this.PricesGroupBox.Controls.Add(this.label5);
            this.PricesGroupBox.Controls.Add(this.EconomyPriceLabel);
            this.PricesGroupBox.Controls.Add(this.PremierePriceLabel);
            this.PricesGroupBox.Controls.Add(this.L_economy);
            this.PricesGroupBox.Controls.Add(this.L_premiere);
            this.PricesGroupBox.Font = new System.Drawing.Font("Oswald Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PricesGroupBox.Location = new System.Drawing.Point(443, 0);
            this.PricesGroupBox.Name = "PricesGroupBox";
            this.PricesGroupBox.Size = new System.Drawing.Size(424, 181);
            this.PricesGroupBox.TabIndex = 3;
            this.PricesGroupBox.TabStop = false;
            this.PricesGroupBox.Text = "Цены";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Oswald Light", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(256, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(162, 19);
            this.label7.TabIndex = 12;
            this.label7.Text = "*Скидка действует только на цену рейса";
            // 
            // BabyDiscountLabel
            // 
            this.BabyDiscountLabel.AutoSize = true;
            this.BabyDiscountLabel.Font = new System.Drawing.Font("Oswald Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BabyDiscountLabel.Location = new System.Drawing.Point(327, 81);
            this.BabyDiscountLabel.Name = "BabyDiscountLabel";
            this.BabyDiscountLabel.Size = new System.Drawing.Size(45, 27);
            this.BabyDiscountLabel.TabIndex = 11;
            this.BabyDiscountLabel.Text = "label8";
            // 
            // ChildDiscountLabel
            // 
            this.ChildDiscountLabel.AutoSize = true;
            this.ChildDiscountLabel.Font = new System.Drawing.Font("Oswald Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChildDiscountLabel.Location = new System.Drawing.Point(327, 49);
            this.ChildDiscountLabel.Name = "ChildDiscountLabel";
            this.ChildDiscountLabel.Size = new System.Drawing.Size(43, 27);
            this.ChildDiscountLabel.TabIndex = 10;
            this.ChildDiscountLabel.Text = "label7";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Oswald Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(203, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 27);
            this.label2.TabIndex = 9;
            this.label2.Text = "Скидка младенцам*:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Oswald Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(203, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 27);
            this.label1.TabIndex = 8;
            this.label1.Text = "Скидка детям*:";
            // 
            // BaggagePriceLabel
            // 
            this.BaggagePriceLabel.AutoSize = true;
            this.BaggagePriceLabel.Font = new System.Drawing.Font("Oswald Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BaggagePriceLabel.Location = new System.Drawing.Point(90, 145);
            this.BaggagePriceLabel.Name = "BaggagePriceLabel";
            this.BaggagePriceLabel.Size = new System.Drawing.Size(43, 27);
            this.BaggagePriceLabel.TabIndex = 7;
            this.BaggagePriceLabel.Text = "label7";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Oswald Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(6, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 27);
            this.label6.TabIndex = 6;
            this.label6.Text = "Багаж:";
            // 
            // FlightPriceLabel
            // 
            this.FlightPriceLabel.AutoSize = true;
            this.FlightPriceLabel.Font = new System.Drawing.Font("Oswald Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FlightPriceLabel.Location = new System.Drawing.Point(90, 49);
            this.FlightPriceLabel.Name = "FlightPriceLabel";
            this.FlightPriceLabel.Size = new System.Drawing.Size(45, 27);
            this.FlightPriceLabel.TabIndex = 5;
            this.FlightPriceLabel.Text = "label6";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Oswald Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(6, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 27);
            this.label5.TabIndex = 4;
            this.label5.Text = "Цена рейса:";
            // 
            // EconomyPriceLabel
            // 
            this.EconomyPriceLabel.AutoSize = true;
            this.EconomyPriceLabel.Font = new System.Drawing.Font("Oswald Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EconomyPriceLabel.Location = new System.Drawing.Point(90, 113);
            this.EconomyPriceLabel.Name = "EconomyPriceLabel";
            this.EconomyPriceLabel.Size = new System.Drawing.Size(45, 27);
            this.EconomyPriceLabel.TabIndex = 3;
            this.EconomyPriceLabel.Text = "label2";
            // 
            // PremierePriceLabel
            // 
            this.PremierePriceLabel.AutoSize = true;
            this.PremierePriceLabel.Font = new System.Drawing.Font("Oswald Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PremierePriceLabel.Location = new System.Drawing.Point(90, 81);
            this.PremierePriceLabel.Name = "PremierePriceLabel";
            this.PremierePriceLabel.Size = new System.Drawing.Size(43, 27);
            this.PremierePriceLabel.TabIndex = 2;
            this.PremierePriceLabel.Text = "label1";
            // 
            // L_economy
            // 
            this.L_economy.AutoSize = true;
            this.L_economy.Font = new System.Drawing.Font("Oswald Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_economy.Location = new System.Drawing.Point(6, 113);
            this.L_economy.Name = "L_economy";
            this.L_economy.Size = new System.Drawing.Size(65, 27);
            this.L_economy.TabIndex = 1;
            this.L_economy.Text = "Economy: ";
            // 
            // L_premiere
            // 
            this.L_premiere.AutoSize = true;
            this.L_premiere.Font = new System.Drawing.Font("Oswald Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_premiere.Location = new System.Drawing.Point(6, 81);
            this.L_premiere.Name = "L_premiere";
            this.L_premiere.Size = new System.Drawing.Size(67, 27);
            this.L_premiere.TabIndex = 0;
            this.L_premiere.Text = "Premiere: ";
            // 
            // ClienOrderGroupBox
            // 
            this.ClienOrderGroupBox.Controls.Add(this.BaggageCountNumericUpDown);
            this.ClienOrderGroupBox.Controls.Add(this.BaggageComboBox);
            this.ClienOrderGroupBox.Controls.Add(this.FlightSumLabel);
            this.ClienOrderGroupBox.Controls.Add(this.FlightExpressionLabel);
            this.ClienOrderGroupBox.Controls.Add(this.label4);
            this.ClienOrderGroupBox.Controls.Add(this.ResultNumLabel);
            this.ClienOrderGroupBox.Controls.Add(this.EconomyCoutLabel);
            this.ClienOrderGroupBox.Controls.Add(this.PremiereCountLabel);
            this.ClienOrderGroupBox.Controls.Add(this.L_Result);
            this.ClienOrderGroupBox.Controls.Add(this.EconomySumLabel);
            this.ClienOrderGroupBox.Controls.Add(this.EconomyExpressionLabel);
            this.ClienOrderGroupBox.Controls.Add(this.PremiereSumLabel);
            this.ClienOrderGroupBox.Controls.Add(this.SeatsCountNumLabel);
            this.ClienOrderGroupBox.Controls.Add(this.PremiereExpressionLabel);
            this.ClienOrderGroupBox.Controls.Add(this.label3);
            this.ClienOrderGroupBox.Controls.Add(this.L_PremiereSeats);
            this.ClienOrderGroupBox.Controls.Add(this.L_seatsCount);
            this.ClienOrderGroupBox.Font = new System.Drawing.Font("Oswald Light", 18F);
            this.ClienOrderGroupBox.Location = new System.Drawing.Point(443, 187);
            this.ClienOrderGroupBox.Name = "ClienOrderGroupBox";
            this.ClienOrderGroupBox.Size = new System.Drawing.Size(424, 404);
            this.ClienOrderGroupBox.TabIndex = 4;
            this.ClienOrderGroupBox.TabStop = false;
            this.ClienOrderGroupBox.Text = "Ваш заказ";
            // 
            // BaggageCountNumericUpDown
            // 
            this.BaggageCountNumericUpDown.Enabled = false;
            this.BaggageCountNumericUpDown.Font = new System.Drawing.Font("Oswald Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BaggageCountNumericUpDown.Location = new System.Drawing.Point(148, 309);
            this.BaggageCountNumericUpDown.Name = "BaggageCountNumericUpDown";
            this.BaggageCountNumericUpDown.Size = new System.Drawing.Size(71, 31);
            this.BaggageCountNumericUpDown.TabIndex = 17;
            this.BaggageCountNumericUpDown.ValueChanged += new System.EventHandler(this.BaggageCountNumericUpDown_ValueChanged);
            // 
            // BaggageComboBox
            // 
            this.BaggageComboBox.AutoSize = true;
            this.BaggageComboBox.Font = new System.Drawing.Font("Oswald Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BaggageComboBox.Location = new System.Drawing.Point(12, 309);
            this.BaggageComboBox.Name = "BaggageComboBox";
            this.BaggageComboBox.Size = new System.Drawing.Size(109, 31);
            this.BaggageComboBox.TabIndex = 16;
            this.BaggageComboBox.Text = "Багаж (23 кг.)";
            this.BaggageComboBox.UseVisualStyleBackColor = true;
            this.BaggageComboBox.Click += new System.EventHandler(this.BaggageCheckBox_Click);
            // 
            // FlightSumLabel
            // 
            this.FlightSumLabel.AutoSize = true;
            this.FlightSumLabel.Font = new System.Drawing.Font("Oswald Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FlightSumLabel.Location = new System.Drawing.Point(301, 126);
            this.FlightSumLabel.Name = "FlightSumLabel";
            this.FlightSumLabel.Size = new System.Drawing.Size(37, 27);
            this.FlightSumLabel.TabIndex = 15;
            this.FlightSumLabel.Text = "label";
            // 
            // FlightExpressionLabel
            // 
            this.FlightExpressionLabel.AutoSize = true;
            this.FlightExpressionLabel.Font = new System.Drawing.Font("Oswald Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FlightExpressionLabel.Location = new System.Drawing.Point(6, 126);
            this.FlightExpressionLabel.Name = "FlightExpressionLabel";
            this.FlightExpressionLabel.Size = new System.Drawing.Size(37, 27);
            this.FlightExpressionLabel.TabIndex = 13;
            this.FlightExpressionLabel.Text = "label";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Oswald Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(6, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 27);
            this.label4.TabIndex = 12;
            this.label4.Text = "Цена рейса:";
            // 
            // ResultNumLabel
            // 
            this.ResultNumLabel.AutoSize = true;
            this.ResultNumLabel.Font = new System.Drawing.Font("Oswald", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ResultNumLabel.Location = new System.Drawing.Point(62, 362);
            this.ResultNumLabel.Name = "ResultNumLabel";
            this.ResultNumLabel.Size = new System.Drawing.Size(52, 36);
            this.ResultNumLabel.TabIndex = 11;
            this.ResultNumLabel.Text = "label";
            // 
            // EconomyCoutLabel
            // 
            this.EconomyCoutLabel.AutoSize = true;
            this.EconomyCoutLabel.Font = new System.Drawing.Font("Oswald Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EconomyCoutLabel.Location = new System.Drawing.Point(76, 234);
            this.EconomyCoutLabel.Name = "EconomyCoutLabel";
            this.EconomyCoutLabel.Size = new System.Drawing.Size(37, 27);
            this.EconomyCoutLabel.TabIndex = 10;
            this.EconomyCoutLabel.Text = "label";
            // 
            // PremiereCountLabel
            // 
            this.PremiereCountLabel.AutoSize = true;
            this.PremiereCountLabel.Font = new System.Drawing.Font("Oswald Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PremiereCountLabel.Location = new System.Drawing.Point(76, 162);
            this.PremiereCountLabel.Name = "PremiereCountLabel";
            this.PremiereCountLabel.Size = new System.Drawing.Size(37, 27);
            this.PremiereCountLabel.TabIndex = 9;
            this.PremiereCountLabel.Text = "label";
            // 
            // L_Result
            // 
            this.L_Result.AutoSize = true;
            this.L_Result.Font = new System.Drawing.Font("Oswald", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_Result.Location = new System.Drawing.Point(5, 358);
            this.L_Result.Name = "L_Result";
            this.L_Result.Size = new System.Drawing.Size(61, 41);
            this.L_Result.TabIndex = 8;
            this.L_Result.Text = "Итог:";
            // 
            // EconomySumLabel
            // 
            this.EconomySumLabel.AutoSize = true;
            this.EconomySumLabel.Font = new System.Drawing.Font("Oswald Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EconomySumLabel.Location = new System.Drawing.Point(301, 270);
            this.EconomySumLabel.Name = "EconomySumLabel";
            this.EconomySumLabel.Size = new System.Drawing.Size(37, 27);
            this.EconomySumLabel.TabIndex = 7;
            this.EconomySumLabel.Text = "label";
            // 
            // EconomyExpressionLabel
            // 
            this.EconomyExpressionLabel.AutoSize = true;
            this.EconomyExpressionLabel.Font = new System.Drawing.Font("Oswald Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EconomyExpressionLabel.Location = new System.Drawing.Point(6, 270);
            this.EconomyExpressionLabel.Name = "EconomyExpressionLabel";
            this.EconomyExpressionLabel.Size = new System.Drawing.Size(37, 27);
            this.EconomyExpressionLabel.TabIndex = 6;
            this.EconomyExpressionLabel.Text = "label";
            // 
            // PremiereSumLabel
            // 
            this.PremiereSumLabel.AutoSize = true;
            this.PremiereSumLabel.Font = new System.Drawing.Font("Oswald Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PremiereSumLabel.Location = new System.Drawing.Point(301, 198);
            this.PremiereSumLabel.Name = "PremiereSumLabel";
            this.PremiereSumLabel.Size = new System.Drawing.Size(37, 27);
            this.PremiereSumLabel.TabIndex = 5;
            this.PremiereSumLabel.Text = "label";
            // 
            // SeatsCountNumLabel
            // 
            this.SeatsCountNumLabel.AutoSize = true;
            this.SeatsCountNumLabel.Font = new System.Drawing.Font("Oswald Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SeatsCountNumLabel.Location = new System.Drawing.Point(106, 54);
            this.SeatsCountNumLabel.Name = "SeatsCountNumLabel";
            this.SeatsCountNumLabel.Size = new System.Drawing.Size(37, 27);
            this.SeatsCountNumLabel.TabIndex = 4;
            this.SeatsCountNumLabel.Text = "label";
            // 
            // PremiereExpressionLabel
            // 
            this.PremiereExpressionLabel.AutoSize = true;
            this.PremiereExpressionLabel.Font = new System.Drawing.Font("Oswald Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PremiereExpressionLabel.Location = new System.Drawing.Point(6, 198);
            this.PremiereExpressionLabel.Name = "PremiereExpressionLabel";
            this.PremiereExpressionLabel.Size = new System.Drawing.Size(37, 27);
            this.PremiereExpressionLabel.TabIndex = 3;
            this.PremiereExpressionLabel.Text = "label";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Oswald Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(6, 234);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 27);
            this.label3.TabIndex = 2;
            this.label3.Text = "Economy:";
            // 
            // L_PremiereSeats
            // 
            this.L_PremiereSeats.AutoSize = true;
            this.L_PremiereSeats.Font = new System.Drawing.Font("Oswald Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_PremiereSeats.Location = new System.Drawing.Point(6, 162);
            this.L_PremiereSeats.Name = "L_PremiereSeats";
            this.L_PremiereSeats.Size = new System.Drawing.Size(64, 27);
            this.L_PremiereSeats.TabIndex = 1;
            this.L_PremiereSeats.Text = "Premiere:";
            // 
            // L_seatsCount
            // 
            this.L_seatsCount.AutoSize = true;
            this.L_seatsCount.Font = new System.Drawing.Font("Oswald Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_seatsCount.Location = new System.Drawing.Point(6, 54);
            this.L_seatsCount.Name = "L_seatsCount";
            this.L_seatsCount.Size = new System.Drawing.Size(94, 27);
            this.L_seatsCount.TabIndex = 0;
            this.L_seatsCount.Text = "Мест заказано:";
            // 
            // Airbus_A320
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(879, 719);
            this.Controls.Add(this.ClienOrderGroupBox);
            this.Controls.Add(this.PricesGroupBox);
            this.Controls.Add(this.GoBackButton);
            this.Controls.Add(this.RegistratePassengersButton);
            this.Controls.Add(this.P_planePB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Airbus_A320";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Airbus_A320";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Airbus_A320_FormClosing);
            this.P_planePB.ResumeLayout(false);
            this.P_planePB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PlaneSeatsPictureBox)).EndInit();
            this.PricesGroupBox.ResumeLayout(false);
            this.PricesGroupBox.PerformLayout();
            this.ClienOrderGroupBox.ResumeLayout(false);
            this.ClienOrderGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BaggageCountNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel P_planePB;
        private System.Windows.Forms.PictureBox PlaneSeatsPictureBox;
        private System.Windows.Forms.Button RegistratePassengersButton;
        private System.Windows.Forms.Button GoBackButton;
        private System.Windows.Forms.GroupBox PricesGroupBox;
        private System.Windows.Forms.Label L_premiere;
        private System.Windows.Forms.Label L_economy;
        private System.Windows.Forms.Label EconomyPriceLabel;
        private System.Windows.Forms.Label PremierePriceLabel;
        private System.Windows.Forms.GroupBox ClienOrderGroupBox;
        private System.Windows.Forms.Label L_seatsCount;
        private System.Windows.Forms.Label L_PremiereSeats;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label SeatsCountNumLabel;
        private System.Windows.Forms.Label PremiereExpressionLabel;
        private System.Windows.Forms.Label PremiereSumLabel;
        private System.Windows.Forms.Label EconomySumLabel;
        private System.Windows.Forms.Label EconomyExpressionLabel;
        private System.Windows.Forms.Label L_Result;
        private System.Windows.Forms.Label EconomyCoutLabel;
        private System.Windows.Forms.Label PremiereCountLabel;
        private System.Windows.Forms.Label ResultNumLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label FlightExpressionLabel;
        private System.Windows.Forms.Label FlightSumLabel;
        private System.Windows.Forms.Label FlightPriceLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox BaggageComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label BaggagePriceLabel;
        private System.Windows.Forms.NumericUpDown BaggageCountNumericUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label BabyDiscountLabel;
        private System.Windows.Forms.Label ChildDiscountLabel;
        private System.Windows.Forms.Label label7;
    }
}