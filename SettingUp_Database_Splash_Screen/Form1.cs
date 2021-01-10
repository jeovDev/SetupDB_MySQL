using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SettingUp_Database_Splash_Screen
{
    public partial class Form1 : Form
    {
        int progressValue;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            progressValue++;
            progressBar1.Value = progressValue;

            if (progressValue == 20)
            {
                ClassConnection createDB = new ClassConnection();
                createDB.OpenDatabase();
                label3.Text = "Checking Database";


            }
            else if (progressValue == 30)
            {
                ClassConnection createTable = new ClassConnection();
                createTable.table();
                label3.Text = "Checking Table";
            }


            else if (progressValue == 80)
            {

                label3.Text = "Complete";
            }
            else if (progressValue == progressBar1.Maximum)
            {
                timer.Stop();
                MessageBox.Show("Database and Table Successfully Created");
                Application.Exit();
            }
        }
    }
}
