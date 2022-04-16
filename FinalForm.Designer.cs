
namespace Kursovaya_AirBookingSystem
{
    partial class FinalForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.CheckTicketButton = new System.Windows.Forms.Button();
            this.SaveTicketButton = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Oswald", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(79, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(484, 109);
            this.label1.TabIndex = 0;
            this.label1.Text = "Приятного полета!";
            // 
            // CheckTicketButton
            // 
            this.CheckTicketButton.BackColor = System.Drawing.SystemColors.Window;
            this.CheckTicketButton.Font = new System.Drawing.Font("Oswald Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CheckTicketButton.Location = new System.Drawing.Point(221, 247);
            this.CheckTicketButton.Name = "CheckTicketButton";
            this.CheckTicketButton.Size = new System.Drawing.Size(181, 40);
            this.CheckTicketButton.TabIndex = 1;
            this.CheckTicketButton.Text = "Вернуться на главную";
            this.CheckTicketButton.UseVisualStyleBackColor = false;
            this.CheckTicketButton.Click += new System.EventHandler(this.CheckTicketButton_Click);
            // 
            // SaveTicketButton
            // 
            this.SaveTicketButton.BackColor = System.Drawing.SystemColors.Window;
            this.SaveTicketButton.Font = new System.Drawing.Font("Oswald Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveTicketButton.Location = new System.Drawing.Point(202, 195);
            this.SaveTicketButton.Name = "SaveTicketButton";
            this.SaveTicketButton.Size = new System.Drawing.Size(223, 46);
            this.SaveTicketButton.TabIndex = 2;
            this.SaveTicketButton.Text = "Сохранить билет(ы) в PDF";
            this.SaveTicketButton.UseVisualStyleBackColor = false;
            this.SaveTicketButton.Click += new System.EventHandler(this.SaveTicketButton_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.DocumentMapWidth = 70;
            this.reportViewer1.Enabled = false;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Kursovaya_AirBookingSystem.Ticket.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(518, 306);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(92, 61);
            this.reportViewer1.TabIndex = 3;
            this.reportViewer1.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(202, 177);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(223, 12);
            this.progressBar1.TabIndex = 4;
            // 
            // FinalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(622, 379);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.SaveTicketButton);
            this.Controls.Add(this.CheckTicketButton);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FinalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FinalForm";
            this.Load += new System.EventHandler(this.FinalForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CheckTicketButton;
        private System.Windows.Forms.Button SaveTicketButton;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}