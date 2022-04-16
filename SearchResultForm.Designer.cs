
namespace Kursovaya_AirBookingSystem
{
    partial class SearchResultForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.FiltersPanel = new System.Windows.Forms.Panel();
            this.CancelFiltersButton = new System.Windows.Forms.Button();
            this.DayTimesFiltersGroupBox = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CB_destinationTime = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CB_DepartionTime = new System.Windows.Forms.ComboBox();
            this.CompanyFilterGroupBox = new System.Windows.Forms.GroupBox();
            this.CB_CompanyFilter = new System.Windows.Forms.ComboBox();
            this.PricesFiltersGroupBox = new System.Windows.Forms.GroupBox();
            this.TB_PriceEnd = new System.Windows.Forms.TextBox();
            this.TB_PriceStart = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SearchResultPanel = new System.Windows.Forms.Panel();
            this.BackToMainFormButton = new System.Windows.Forms.Button();
            this.HeaderPanel = new System.Windows.Forms.Panel();
            this.SearchResultLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.FiltersPanel.SuspendLayout();
            this.DayTimesFiltersGroupBox.SuspendLayout();
            this.CompanyFilterGroupBox.SuspendLayout();
            this.PricesFiltersGroupBox.SuspendLayout();
            this.HeaderPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.FiltersPanel);
            this.panel1.Controls.Add(this.SearchResultPanel);
            this.panel1.Controls.Add(this.BackToMainFormButton);
            this.panel1.Controls.Add(this.HeaderPanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1168, 664);
            this.panel1.TabIndex = 0;
            // 
            // FiltersPanel
            // 
            this.FiltersPanel.BackColor = System.Drawing.Color.White;
            this.FiltersPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FiltersPanel.Controls.Add(this.CancelFiltersButton);
            this.FiltersPanel.Controls.Add(this.DayTimesFiltersGroupBox);
            this.FiltersPanel.Controls.Add(this.CompanyFilterGroupBox);
            this.FiltersPanel.Controls.Add(this.PricesFiltersGroupBox);
            this.FiltersPanel.Controls.Add(this.label1);
            this.FiltersPanel.Location = new System.Drawing.Point(12, 61);
            this.FiltersPanel.Name = "FiltersPanel";
            this.FiltersPanel.Size = new System.Drawing.Size(228, 591);
            this.FiltersPanel.TabIndex = 4;
            // 
            // CancelFiltersButton
            // 
            this.CancelFiltersButton.Font = new System.Drawing.Font("Oswald Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CancelFiltersButton.Location = new System.Drawing.Point(3, 529);
            this.CancelFiltersButton.Name = "CancelFiltersButton";
            this.CancelFiltersButton.Size = new System.Drawing.Size(220, 57);
            this.CancelFiltersButton.TabIndex = 4;
            this.CancelFiltersButton.Text = "Очистить";
            this.CancelFiltersButton.UseVisualStyleBackColor = true;
            this.CancelFiltersButton.Click += new System.EventHandler(this.CancelFilterButton_Click);
            // 
            // DayTimesFiltersGroupBox
            // 
            this.DayTimesFiltersGroupBox.Controls.Add(this.label5);
            this.DayTimesFiltersGroupBox.Controls.Add(this.CB_destinationTime);
            this.DayTimesFiltersGroupBox.Controls.Add(this.label4);
            this.DayTimesFiltersGroupBox.Controls.Add(this.CB_DepartionTime);
            this.DayTimesFiltersGroupBox.Font = new System.Drawing.Font("Oswald Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DayTimesFiltersGroupBox.Location = new System.Drawing.Point(3, 305);
            this.DayTimesFiltersGroupBox.Name = "DayTimesFiltersGroupBox";
            this.DayTimesFiltersGroupBox.Size = new System.Drawing.Size(220, 218);
            this.DayTimesFiltersGroupBox.TabIndex = 3;
            this.DayTimesFiltersGroupBox.TabStop = false;
            this.DayTimesFiltersGroupBox.Text = "По времени суток";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 32);
            this.label5.TabIndex = 3;
            this.label5.Text = "Время прибытия";
            // 
            // CB_destinationTime
            // 
            this.CB_destinationTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_destinationTime.FormattingEnabled = true;
            this.CB_destinationTime.Items.AddRange(new object[] {
            "Утро",
            "День",
            "Вечер",
            "Ночь"});
            this.CB_destinationTime.Location = new System.Drawing.Point(6, 142);
            this.CB_destinationTime.Name = "CB_destinationTime";
            this.CB_destinationTime.Size = new System.Drawing.Size(207, 40);
            this.CB_destinationTime.TabIndex = 2;
            this.CB_destinationTime.SelectedIndexChanged += new System.EventHandler(this.DestinationTimeComboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 32);
            this.label4.TabIndex = 1;
            this.label4.Text = "Время вылета";
            // 
            // CB_DepartionTime
            // 
            this.CB_DepartionTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_DepartionTime.FormattingEnabled = true;
            this.CB_DepartionTime.Items.AddRange(new object[] {
            "Утро",
            "День",
            "Вечер",
            "Ночь"});
            this.CB_DepartionTime.Location = new System.Drawing.Point(6, 64);
            this.CB_DepartionTime.Name = "CB_DepartionTime";
            this.CB_DepartionTime.Size = new System.Drawing.Size(207, 40);
            this.CB_DepartionTime.TabIndex = 0;
            this.CB_DepartionTime.SelectedValueChanged += new System.EventHandler(this.DepartionTimeComboBox_SelectedValueChanged);
            // 
            // CompanyFilterGroupBox
            // 
            this.CompanyFilterGroupBox.Controls.Add(this.CB_CompanyFilter);
            this.CompanyFilterGroupBox.Font = new System.Drawing.Font("Oswald Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CompanyFilterGroupBox.Location = new System.Drawing.Point(3, 224);
            this.CompanyFilterGroupBox.Name = "CompanyFilterGroupBox";
            this.CompanyFilterGroupBox.Size = new System.Drawing.Size(220, 82);
            this.CompanyFilterGroupBox.TabIndex = 2;
            this.CompanyFilterGroupBox.TabStop = false;
            this.CompanyFilterGroupBox.Text = "По компании";
            // 
            // CB_CompanyFilter
            // 
            this.CB_CompanyFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_CompanyFilter.FormattingEnabled = true;
            this.CB_CompanyFilter.Location = new System.Drawing.Point(7, 33);
            this.CB_CompanyFilter.Name = "CB_CompanyFilter";
            this.CB_CompanyFilter.Size = new System.Drawing.Size(207, 40);
            this.CB_CompanyFilter.TabIndex = 0;
            this.CB_CompanyFilter.SelectedValueChanged += new System.EventHandler(this.CompanyFilterComboBox_SelectedValueChanged);
            // 
            // PricesFiltersGroupBox
            // 
            this.PricesFiltersGroupBox.Controls.Add(this.TB_PriceEnd);
            this.PricesFiltersGroupBox.Controls.Add(this.TB_PriceStart);
            this.PricesFiltersGroupBox.Controls.Add(this.label3);
            this.PricesFiltersGroupBox.Controls.Add(this.label2);
            this.PricesFiltersGroupBox.Font = new System.Drawing.Font("Oswald Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PricesFiltersGroupBox.Location = new System.Drawing.Point(3, 47);
            this.PricesFiltersGroupBox.Name = "PricesFiltersGroupBox";
            this.PricesFiltersGroupBox.Size = new System.Drawing.Size(220, 171);
            this.PricesFiltersGroupBox.TabIndex = 1;
            this.PricesFiltersGroupBox.TabStop = false;
            this.PricesFiltersGroupBox.Text = "По цене";
            // 
            // TB_PriceEnd
            // 
            this.TB_PriceEnd.Location = new System.Drawing.Point(12, 125);
            this.TB_PriceEnd.Name = "TB_PriceEnd";
            this.TB_PriceEnd.Size = new System.Drawing.Size(201, 36);
            this.TB_PriceEnd.TabIndex = 4;
            this.TB_PriceEnd.TextChanged += new System.EventHandler(this.PriceEndTextBox_TextChanged);
            this.TB_PriceEnd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PriceEndTextBox_KeyPress);
            // 
            // TB_PriceStart
            // 
            this.TB_PriceStart.Location = new System.Drawing.Point(12, 62);
            this.TB_PriceStart.Name = "TB_PriceStart";
            this.TB_PriceStart.Size = new System.Drawing.Size(201, 36);
            this.TB_PriceStart.TabIndex = 3;
            this.TB_PriceStart.TextChanged += new System.EventHandler(this.PriceStartTextBox_TextChanged);
            this.TB_PriceStart.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PriceStartTextBox_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 32);
            this.label3.TabIndex = 2;
            this.label3.Text = "До";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "От";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Oswald Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Фильтр";
            // 
            // SearchResultPanel
            // 
            this.SearchResultPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchResultPanel.AutoScroll = true;
            this.SearchResultPanel.BackColor = System.Drawing.Color.White;
            this.SearchResultPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SearchResultPanel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.SearchResultPanel.Location = new System.Drawing.Point(246, 61);
            this.SearchResultPanel.Name = "SearchResultPanel";
            this.SearchResultPanel.Size = new System.Drawing.Size(910, 591);
            this.SearchResultPanel.TabIndex = 3;
            // 
            // BackToMainFormButton
            // 
            this.BackToMainFormButton.BackColor = System.Drawing.Color.Transparent;
            this.BackToMainFormButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BackToMainFormButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackToMainFormButton.Font = new System.Drawing.Font("Oswald", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BackToMainFormButton.Location = new System.Drawing.Point(12, 12);
            this.BackToMainFormButton.Name = "BackToMainFormButton";
            this.BackToMainFormButton.Size = new System.Drawing.Size(141, 32);
            this.BackToMainFormButton.TabIndex = 2;
            this.BackToMainFormButton.Text = "Вернуться на главную";
            this.BackToMainFormButton.UseVisualStyleBackColor = false;
            this.BackToMainFormButton.Click += new System.EventHandler(this.BackToMainFormButton_Click);
            // 
            // HeaderPanel
            // 
            this.HeaderPanel.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.HeaderPanel.Controls.Add(this.SearchResultLabel);
            this.HeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.Size = new System.Drawing.Size(1168, 55);
            this.HeaderPanel.TabIndex = 5;
            // 
            // SearchResultLabel
            // 
            this.SearchResultLabel.BackColor = System.Drawing.Color.Transparent;
            this.SearchResultLabel.Font = new System.Drawing.Font("Oswald", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SearchResultLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SearchResultLabel.Location = new System.Drawing.Point(467, -3);
            this.SearchResultLabel.Name = "SearchResultLabel";
            this.SearchResultLabel.Size = new System.Drawing.Size(330, 58);
            this.SearchResultLabel.TabIndex = 1;
            this.SearchResultLabel.Text = "Результаты поиска";
            this.SearchResultLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // SearchResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1168, 664);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SearchResultForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TicketsForm";
            this.panel1.ResumeLayout(false);
            this.FiltersPanel.ResumeLayout(false);
            this.FiltersPanel.PerformLayout();
            this.DayTimesFiltersGroupBox.ResumeLayout(false);
            this.DayTimesFiltersGroupBox.PerformLayout();
            this.CompanyFilterGroupBox.ResumeLayout(false);
            this.PricesFiltersGroupBox.ResumeLayout(false);
            this.PricesFiltersGroupBox.PerformLayout();
            this.HeaderPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label SearchResultLabel;
        private System.Windows.Forms.Button BackToMainFormButton;
        private System.Windows.Forms.Panel FiltersPanel;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Panel SearchResultPanel;
        private System.Windows.Forms.GroupBox PricesFiltersGroupBox;
        private System.Windows.Forms.GroupBox CompanyFilterGroupBox;
        private System.Windows.Forms.GroupBox DayTimesFiltersGroupBox;
        private System.Windows.Forms.Button CancelFiltersButton;
        private System.Windows.Forms.ComboBox CB_CompanyFilter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CB_DepartionTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CB_destinationTime;
        private System.Windows.Forms.TextBox TB_PriceEnd;
        private System.Windows.Forms.TextBox TB_PriceStart;
        private System.Windows.Forms.Panel HeaderPanel;
    }
}