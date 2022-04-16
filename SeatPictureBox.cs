using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursovaya_AirBookingSystem
{
    public class SeatPictureBox : PictureBox
    {
        public int Row { get; set; }
        public int Number { get; set; }
        public string Seat => $"{Row}{Number}";
        public bool Available { get; set; }
        public bool IsChoosen { get; set; }
        public string SeatClass { get; set; }
    }
}
