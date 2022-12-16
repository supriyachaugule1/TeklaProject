using System;
using Tekla.Structures.Model;
using Tekla.Structures.Geometry3d;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CreateContourPlate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        Model myModel = new Model();
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (myModel.GetConnectionStatus())
            {
                double rad = double.Parse(textBox1.Text);
                double side = rad * 1.7320;
                ContourPoint point = new ContourPoint(new Point(0, 5000, 0), null);
                ContourPoint point2 = new ContourPoint(new Point(0.866 * side, (side / 2) + 5000, 0), new Chamfer(0, 0, Chamfer.ChamferTypeEnum.CHAMFER_ARC_POINT));
                ContourPoint point3 = new ContourPoint(new Point(0, 5000 + side, 0), new Chamfer(0, 0, Chamfer.ChamferTypeEnum.CHAMFER_ARC_POINT));
                ContourPlate CP = new ContourPlate();

                CP.AddContourPoint(point);
                CP.AddContourPoint(point2);
                CP.AddContourPoint(point3);
                CP.Finish = "FOO";
                CP.Profile.ProfileString = "PL300";
                CP.Material.MaterialString = "Steel_Undefined";

                CP.Insert();
                myModel.CommitChanges();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (myModel.GetConnectionStatus())
            {
                double rad1 = Convert.ToDouble(textBox1.Text);
                string s = "ROD" + rad1;

                Point p1 = new Point(20000, 20000, 0);
                Point p2 = new Point(20000, 20000, 300);
                var beam = new Beam(p1, p2);
                beam.Profile.ProfileString = s;
                beam.Insert();
                myModel.CommitChanges();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (myModel.GetConnectionStatus())
            {
                double rad = double.Parse(textBox1.Text);
                double side = rad * 1.7320;
                ContourPoint point = new ContourPoint(new Point(0, 20000, 0), null);
                ContourPoint point2 = new ContourPoint(new Point(0.866 * side, (side / 2) + 20000, 0), new Chamfer(0, 0, Chamfer.ChamferTypeEnum.CHAMFER_ARC_POINT));
                ContourPoint point3 = new ContourPoint(new Point(0, 20000 + side, 0), new Chamfer(0, 0, Chamfer.ChamferTypeEnum.CHAMFER_ARC_POINT));
                ContourPoint point4 = new ContourPoint(new Point(0, 20000, 0), null);
                PolyBeam polyBeam = new PolyBeam();

                polyBeam.AddContourPoint(point);
                polyBeam.AddContourPoint(point2);
                polyBeam.AddContourPoint(point3);
                polyBeam.AddContourPoint(point4);
                polyBeam.Finish = "FOO";
                polyBeam.Profile.ProfileString = "RHS300*2500*6";
                polyBeam.Material.MaterialString = "Steel_Undefined";

                polyBeam.Insert();
                myModel.CommitChanges();
            }
        }
    }
}
