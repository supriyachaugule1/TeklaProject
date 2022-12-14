using System;
using Tekla.Structures.Geometry3d;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tekla.Structures.Model;
using System.Collections.Generic;

namespace CreateCube
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double len = double.Parse(textBox1.Text);
            double start = double.Parse(textBox2.Text);
            List<Beam> myBeam = new List<Beam>()
            {

                new Beam(new Point(start,0,0),new Point(start,len,0)),
                new Beam(new Point(start+150, len , 0), new Point(len, len, 0)),
                new Beam(new Point(len + 150, len, 0), new Point(len + 150, 0, 0)),
                new Beam(new Point(len , 0, 0), new Point(start + 150, 0, 0)),
                new Beam(new Point(start, 0, 150), new Point(start, 0, len)),
                new Beam(new Point(start, len, len), new Point(start, len, 150)),
                new Beam(new Point(len, len, 150), new Point(len,len,len)),
                new Beam(new Point(len, 0, 150), new Point(len, 0, len)),
                new Beam(new Point(start, 0, len + 150), new Point(start, len, len + 150)),
                new Beam(new Point(start+150, len, len + 150), new Point(len,len,len + 150)),
                new Beam( new Point(len + 150, 0, len + 150), new Point(len + 150, len, len + 150)),
                new Beam( new Point(start + 150, 0, len+150), new Point(len, 0, len+150)),

            };
            Model myModel = new Model();
            if (myModel.GetConnectionStatus())
            {

                foreach (var beam in myBeam)
                {
                    beam.Material.MaterialString = "Steel_Undefined";
                    beam.Profile.ProfileString = "RHS300*300*6";
                    beam.Class = "2";
                    //myBeam.Position.Rotation = Position.RotationEnum.FRONT;
                    beam.Position.Depth = Position.DepthEnum.MIDDLE;
                    beam.Insert();
                    myModel.CommitChanges();

                }
            }
            //OR METHOD
            /*int count = 0;
            double len = double.Parse(textBox1.Text);
            double os = double.Parse(textBox2.Text);
            Point p1 = new Point(os, os, 0);
            Point p2 = new Point(os, len + os, 0);
            Point p3 = new Point(len + os, len + os, 0);
            Point p4 = new Point(len + os, os, 0);
            Point c1 = new Point(os, os, len);
            Point c2 = new Point(os, len + os, len);
            Point c3 = new Point(len + os, len + os, len);
            Point c4 = new Point(len + os, os, len);



            if (myModel.GetConnectionStatus())
            {
                List<Beam> myBeam = new List<Beam>()
                {
                                //for creating beam
                                new Beam(p1,p2),
                                new Beam(p2,p3),
                                new Beam(p3,p4),
                                new Beam(p4,p1),



                               //for creating columns
                                new Beam(p1,c1),
                                new Beam(p2,c2),
                                new Beam(p3,c3),
                                new Beam(p4,c4),



                               ////for creating beam
                                new Beam(c1,c2),
                                new Beam(c2,c3),
                                new Beam(c3,c4),
                                new Beam(c4,c1),
                };



                foreach (Beam beam in myBeam)
                {
                    count++;
                    beam.Material.MaterialString = "Steel_Undefined";
                    beam.Profile.ProfileString = "RHS400*300*2";
                    beam.Class = "3";
                    //beam.Position.Depth = Position.DepthEnum.BEHIND;



                    if (count == 2 || count == 4)
                    {
                        beam.Position.Plane = Position.PlaneEnum.LEFT;
                    }
                    if (count == 7 || count == 8)
                    {
                        beam.Position.Depth = Position.DepthEnum.FRONT;
                    }
                    if (count > 8)
                    {
                        beam.Position.Depth = Position.DepthEnum.FRONT;
                        if (count == 9 || count == 11 || count == 10 || count == 12)
                        {
                            beam.Position.Plane = Position.PlaneEnum.LEFT;
                        }
                    }



                    beam.Insert();
                    myModel.CommitChanges();
                }*/

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Enter the length of cube and starting point of cube");
        }
    }
}

