using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final{
    public partial class Schedules : Form{
        public Schedules(){InitializeComponent();}
        //loads up the current work schedule.
        private void Schedules_Load(object sender, EventArgs e){
            ScheduleReports scheduleReports = new ScheduleReports();
            scheduleReports.SetDatabaseLogon("mawall", "1175037");
            scheduleReports.Refresh();
            crvSchedules.ReportSource = scheduleReports;}
    }
}
