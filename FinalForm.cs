using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;

namespace Kursovaya_AirBookingSystem
{
    public partial class FinalForm : Form
    {
        private List<string> _ticketsIds;

        public FinalForm()
        {
            InitializeComponent();
        }

        public FinalForm(List<string> ticketsIds)
        {
            InitializeComponent();
            _ticketsIds = ticketsIds;
            progressBar1.Value = 0;
        }

        private void SaveTicketButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            FileStream newFile;

            //reportViewer1.LocalReport.ReportPath = 
            //    @"D:\source\repos\Kursovaya_AirBookingSystem\Ticket.rdlc";
            reportViewer1.LocalReport.ReportPath = Constants.TicketReportPath;

            if (folder.ShowDialog() == DialogResult.OK)
            {
                string MyConString = Constants.DataBaseConnection;
                MySqlConnection connection = new MySqlConnection(MyConString);
                MySqlCommand SelectCommand;
                MySqlDataReader myReader;

                connection.Open();

                for (int i = 0; i < _ticketsIds.Count; i++)
                {
                    SelectCommand = new MySqlCommand(String.Format(
                    "SELECT * FROM view_full_tickes_info " +
                    "WHERE ID_ticket = '{0}'", Convert.ToInt32(_ticketsIds[i])), connection);
                    myReader = SelectCommand.ExecuteReader();
                    myReader.Read();

                    double adultPrice = Convert.ToDouble(myReader["fPrice"]);
                    double childPrice = Convert.ToDouble(myReader["fPrice"]) -
                        ((Convert.ToDouble(myReader["fPrice"]) *
                        Convert.ToDouble(myReader["childrenDiscount"])) / 100);
                    double babyPrice = Convert.ToDouble(myReader["fPrice"]) -
                        ((Convert.ToDouble(myReader["fPrice"]) *
                        Convert.ToDouble(myReader["babiesDiscount"]))) / 100;
                    double economyPrice = Convert.ToDouble(myReader["economy"]);
                    double premierePrice = Convert.ToDouble(myReader["business"]);
                    double flightPrice = 0.0;
                    double seatPrice = 0.0;

                    if (Convert.ToString(myReader["ticketType"]) == "Взрослый")
                        flightPrice = adultPrice;
                    if (Convert.ToString(myReader["ticketType"]) == "Ребенок")
                        flightPrice = childPrice;
                    if (Convert.ToString(myReader["ticketType"]) == "Младенец")
                        flightPrice = babyPrice;

                    if (Convert.ToString(myReader["seatType"]) == "Premier")
                        seatPrice = premierePrice;
                    if (Convert.ToString(myReader["seatType"]) == "Economy")
                        seatPrice = economyPrice;
                    if (Convert.ToString(myReader["seatType"]) == "-")
                        seatPrice = 0.0;

                    reportViewer1.Refresh();
                    reportViewer1.LocalReport.SetParameters(
                        new ReportParameter("ticketID", Convert.ToString(myReader["ID_ticket"])));
                    reportViewer1.LocalReport.SetParameters(
                        new ReportParameter("orderID", Convert.ToString(myReader["IDoperation"])));
                    reportViewer1.LocalReport.SetParameters(
                        new ReportParameter("soldDate", Convert.ToString(myReader["oDateTime"])));
                    reportViewer1.LocalReport.SetParameters(
                        new ReportParameter("name", Convert.ToString(myReader["seatTakerFirstName"]) + " " +
                        Convert.ToString(myReader["seatTakerLastName"])));
                    reportViewer1.LocalReport.SetParameters(
                        new ReportParameter("passport", Convert.ToString(myReader["passportSeries"]) +
                        Convert.ToString(myReader["passportNumber"])));
                    reportViewer1.LocalReport.SetParameters(
                        new ReportParameter("birthCertificate", Convert.ToString(myReader["birthCertificate"])));
                    reportViewer1.LocalReport.SetParameters(
                        new ReportParameter("departure", Convert.ToString(myReader["departureP"]) + ", " +
                        Convert.ToString(myReader["depAirport"])));
                    reportViewer1.LocalReport.SetParameters(
                        new ReportParameter("depTime", Convert.ToString(myReader["fDepartureTime"])));
                    reportViewer1.LocalReport.SetParameters(
                        new ReportParameter("destination", Convert.ToString(myReader["destinationP"]) + ", " +
                        Convert.ToString(myReader["desAirport"])));
                    reportViewer1.LocalReport.SetParameters(
                        new ReportParameter("desTime", Convert.ToString(myReader["fArrivalTime"])));
                    reportViewer1.LocalReport.SetParameters(
                        new ReportParameter("Carrier", Convert.ToString(myReader["carrName"])));
                    reportViewer1.LocalReport.SetParameters(
                        new ReportParameter("airplaneModel", Convert.ToString(myReader["model"])));
                    reportViewer1.LocalReport.SetParameters(
                        new ReportParameter("tailNum", Convert.ToString(myReader["tailNum"])));
                    reportViewer1.LocalReport.SetParameters(
                        new ReportParameter("seatClass", Convert.ToString(myReader["seatType"])));
                    reportViewer1.LocalReport.SetParameters(
                        new ReportParameter("seatNum", Convert.ToString(myReader["seatNum"])));
                    reportViewer1.LocalReport.SetParameters(
                        new ReportParameter("baggage", Convert.ToString(myReader["baggageNum"])));
                    reportViewer1.LocalReport.SetParameters(
                        new ReportParameter("flightPrice", Convert.ToString(flightPrice) + " руб."));
                    reportViewer1.LocalReport.SetParameters(
                        new ReportParameter("seatPrice", Convert.ToString(seatPrice) + " руб."));
                    reportViewer1.LocalReport.SetParameters(
                        new ReportParameter("baggagePrice", Convert.ToString(myReader["baggagePrice"]).Split(',')[0] + " руб."));
                    reportViewer1.LocalReport.SetParameters(
                        new ReportParameter("fullPrice", Convert.ToString(myReader["opPrice"]) + " руб."));
                    reportViewer1.Refresh();

                    byte[] byteViewerPDF = reportViewer1.LocalReport.Render("PDF");
                    newFile = new FileStream(
                        folder.SelectedPath + "\\ticket" + myReader["ID_ticket"] + ".pdf", FileMode.Create);
                    newFile.Write(byteViewerPDF, 0, byteViewerPDF.Length);
                    newFile.Close();
                    myReader.Close();

                    progressBar1.Value += 100 / _ticketsIds.Count;
                }

                connection.Close();
            }
            progressBar1.Value = 100;
            MessageBox.Show("Сохранение завершено!");
        }

        private void FinalForm_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }

        private void CheckTicketButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
