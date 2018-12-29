using System;
using System.Windows.Forms;

namespace ServerGridEditor
{
    public partial class ProgressForm : Form
    {
        int currentStep = 1;
        int maxSteps = 1;

        public ProgressForm()
        {
            InitializeComponent();
        }

        public void Initialize(int maxSteps, string startingStepDescription)
        {
            stepDescLbl.Text = startingStepDescription;
            currentStep = 1;
            this.maxSteps = maxSteps;
            UpdateStepLabel();
            Show();
            Invalidate(true);
            Refresh();
        }

        public void SkipSteps(int NumSteps = 1, bool bRefresh = false)
        {
            currentStep = Math.Min(maxSteps, currentStep + NumSteps);
            if (bRefresh)
            {
                Invalidate(true);
                Refresh();
            }
        }
        public void NextStep(string stepDesc)
        {
            stepDescLbl.Text = stepDesc;
            currentStep = Math.Min(maxSteps, ++currentStep);
            UpdateStepLabel();
            Invalidate(true);
            Refresh();
        }

        void UpdateStepLabel()
        {
            stepLbl.Text = string.Format("({0}/{1})", "" + currentStep, "" + maxSteps);
        }

        private void stepDescLbl_Click(object sender, EventArgs e)
        {

        }
    }
}
