using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FF4FE_Tracker_and_Timer
{
    public partial class RandoObjectiveSet : Form
    {
        public RandoObjectiveSet()
        {
            InitializeComponent();
        }

        private void RandoObjectiveSet_Load(object sender, EventArgs e)
        {
            string[] objectiveList = new string[] { };

            cbObjective.Items.Clear();

            objectiveList = Tracker.randoObjectiveList.ToArray<string>();

            cbObjective.Items.AddRange(objectiveList);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Tracker.ObjectiveName = cbObjective.SelectedItem.ToString();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
