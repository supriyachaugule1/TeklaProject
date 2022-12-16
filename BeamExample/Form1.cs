using System;
using Tekla.Structures.Model.Operations;
using Tekla.Structures.Geometry3d;
using System.Windows.Forms;
using Tekla.Structures.Model;

namespace BeamExample
{
    public partial class Form1 : Form
    {
        Model myModel = new Model();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            
            if (myModel.GetConnectionStatus())
            {
                Beam myBeam = new Beam(new Point(0, 0, 0), new Point(0, 6000, 0));
                myBeam.Material.MaterialString = "Steel_Undefined";
                myBeam.Profile.ProfileString = "RHS400*300*6";
                myBeam.Class = "2";
                myBeam.Position.Rotation= Position.RotationEnum.FRONT;
                myBeam.Position.Depth = Position.DepthEnum.MIDDLE;

                myBeam.Insert();
                myModel.CommitChanges();
                

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (myModel.GetConnectionStatus())
            {
                ContourPoint point = new ContourPoint(new Point(7200, 0, 0), null);
                ContourPoint point2 = new ContourPoint(new Point(7200, 6000, 0), null);
                ContourPoint point3 = new ContourPoint(new Point(14400, 6000, 0), null);

                PolyBeam PolyBeam = new PolyBeam();

                PolyBeam.AddContourPoint(point);
                PolyBeam.AddContourPoint(point2);
                PolyBeam.AddContourPoint(point3);

                PolyBeam.Material.MaterialString = "Steel_Undefined";
                PolyBeam.Profile.ProfileString = "RHS400*300*6";
                PolyBeam.Position.Depth = Position.DepthEnum.MIDDLE;
                PolyBeam.Finish = "PAINT";
                PolyBeam.Class= "5";
                PolyBeam.Insert();
                myModel.CommitChanges();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (myModel.GetConnectionStatus())
            {
                Beam myBeam = new Beam(new Point(14400, 0, 0), new Point(14400, 0, 2000));
                myBeam.Material.MaterialString = "Steel_Undefined";
                myBeam.Profile.ProfileString = "RHS400*300*6";
                myBeam.Class = "6";
                myBeam.Position.Depth = Position.DepthEnum.MIDDLE;
                myBeam.Position.Rotation = Position.RotationEnum.TOP;
               

                myBeam.Insert();
                myModel.CommitChanges();


            }
        }
    }
}
