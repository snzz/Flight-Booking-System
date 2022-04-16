
namespace Kursovaya_AirBookingSystem
{
    partial class RegistrationForm
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
            this.InputInfoPanel = new System.Windows.Forms.Panel();
            this.GoBackButton = new System.Windows.Forms.Button();
            this.ChooseSeatButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // InputInfoPanel
            // 
            this.InputInfoPanel.AutoScroll = true;
            this.InputInfoPanel.BackColor = System.Drawing.SystemColors.Window;
            this.InputInfoPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InputInfoPanel.Location = new System.Drawing.Point(13, 13);
            this.InputInfoPanel.Name = "InputInfoPanel";
            this.InputInfoPanel.Size = new System.Drawing.Size(563, 527);
            this.InputInfoPanel.TabIndex = 0;
            // 
            // GoBackButton
            // 
            this.GoBackButton.Font = new System.Drawing.Font("Oswald Light", 14.25F);
            this.GoBackButton.Location = new System.Drawing.Point(13, 547);
            this.GoBackButton.Name = "GoBackButton";
            this.GoBackButton.Size = new System.Drawing.Size(283, 50);
            this.GoBackButton.TabIndex = 1;
            this.GoBackButton.Text = "Вернуться на главную";
            this.GoBackButton.UseVisualStyleBackColor = true;
            this.GoBackButton.Click += new System.EventHandler(this.GoBackButton_Click);
            // 
            // ChooseSeatButton
            // 
            this.ChooseSeatButton.Font = new System.Drawing.Font("Oswald Light", 14.25F);
            this.ChooseSeatButton.Location = new System.Drawing.Point(302, 546);
            this.ChooseSeatButton.Name = "ChooseSeatButton";
            this.ChooseSeatButton.Size = new System.Drawing.Size(274, 51);
            this.ChooseSeatButton.TabIndex = 2;
            this.ChooseSeatButton.Text = "Выбрать место(а)";
            this.ChooseSeatButton.UseVisualStyleBackColor = true;
            this.ChooseSeatButton.Click += new System.EventHandler(this.ChooseSeatButton_Click);
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(588, 609);
            this.Controls.Add(this.ChooseSeatButton);
            this.Controls.Add(this.GoBackButton);
            this.Controls.Add(this.InputInfoPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "RegistrationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegistrationForm";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button GoBackButton;
        public System.Windows.Forms.Panel InputInfoPanel;
        public System.Windows.Forms.Button ChooseSeatButton;
    }
}