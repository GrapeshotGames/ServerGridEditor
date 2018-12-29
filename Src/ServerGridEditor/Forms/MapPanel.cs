using System.Windows.Forms;

namespace ServerGridEditor
{
    public class MapPanel : Panel
    {
        public MainForm mainForm;

        public MapPanel()
        {
            //SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);

            //DoubleBuffered = true;

            this.SetStyle(ControlStyles.UserPaint | ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            this.SetStyle(ControlStyles.UserPaint, false);

            base.OnPaint(e);
            mainForm.mapPanel_Paint(this, e);

            this.SetStyle(ControlStyles.UserPaint, true);
        }
    }
}
