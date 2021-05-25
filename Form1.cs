using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab6
{
    public partial class Form1 : Form
    {
        struct points
        {
            public double X;
            public double Y;
            public double Z;
        }

        struct lines
        {
            public double x1;
            public double y1;
            public double x2;
            public double y2;
        }

        public Form1()
        {
            InitializeComponent();
        }

        int left = 0;
        int right = 0;
        int up = 0;
        int down = 0;
        int zoomin = 1;
        int zoomout = 1;

        void shifting(ref points a, int shiftX, int shiftY, int shiftZ)
        {
            a.X -= shiftX;
            a.Y -= shiftY;
            a.Z -= shiftZ;
        }


        void zooming(ref points a, double zoom)
        {
            a.X *= zoom;
            a.Y *= zoom;
            a.Z *= zoom;
        }

        void turnZ(ref points a, double f)
        {
            double tempX = a.X * Math.Cos(f) + a.Y * Math.Sin(f);
            double tempY = - a.X * Math.Sin(f) + a.Y * Math.Cos(f);
            a.X = tempX;
            a.Y = tempY;
        }

        void turnY(ref points a, double f)
        {
            double tempZ = a.Z * Math.Cos(f) + a.X * Math.Sin(f);
            double tempY = - a.Z * Math.Sin(f) + a.X * Math.Cos(f);
            a.Z = tempZ;
            a.X = tempY;
        }

        void allign(ref points a)
        {
            shifting(ref a, -10*left+10*right, -10*up + 10*down, 0);
           
            shifting(ref a, 135, 120, 0);
        }
        void disallign(ref points a)
        {
            shifting(ref a, 10 * left - 10 * right, 10 * up - 10 * down, 0);
            
            shifting(ref a, -135, -120, 0);
        }

        void turnX(ref points a, double f)
        {
            double tempY = a.Y * Math.Cos(f) + a.Z * Math.Sin(f);
            double tempZ = -a.Y * Math.Sin(f) + a.Z * Math.Cos(f);
            a.Y = tempY;
            a.Z = tempZ;
        }

        static points[] createSide(int sw)
        {
            points[] sideA = new points[18];
            for (int i = 0; i < 18; ++i)
                sideA[i].Z = 0;
            sideA[0].X = 130;
            sideA[0].Y = 80;
            sideA[1].X = 140;
            sideA[1].Y = 80;
            sideA[2].X = 150;
            sideA[2].Y = 90;
            sideA[3].X = 150;
            sideA[3].Y = 100;
            sideA[4].X = 140;
            sideA[4].Y = 100;
            sideA[5].X = 140;
            sideA[5].Y = 90;
            sideA[6].X = 130;
            sideA[6].Y = 90;
            sideA[7].X = 125;
            sideA[7].Y = 100;
            sideA[8].X = 125;
            sideA[8].Y = 140;
            sideA[9].X = 130;
            sideA[9].Y = 150;
            sideA[10].X = 140;
            sideA[10].Y = 150;
            sideA[11].X = 140;
            sideA[11].Y = 140;
            sideA[12].X = 150;
            sideA[12].Y = 140;
            sideA[13].X = 150;
            sideA[13].Y = 150;
            sideA[14].X = 140;
            sideA[14].Y = 160;
            sideA[15].X = 130;
            sideA[15].Y = 160;
            sideA[16].X = 120;
            sideA[16].Y = 150;
            sideA[17].X = 120;
            sideA[17].Y = 90;

            points[] sideB = new points[18];
            for (int i = 0; i < 18; ++i)
            {
                sideB[i].X = sideA[i].X;
                sideB[i].Y = sideA[i].Y;
                sideB[i].Z = 10;
            }

            if (sw == 1) return sideA;
            else return sideB;
            
        }

        lines[] createLetter(points[] a, points[] b)
        {
            lines[] s = new lines[54];
            for (int i = 0; i < 18; ++i)
            {
                s[i].x1 = a[i].X;
                s[i].y1 = a[i].Y;
                s[i].x2 = b[i].X;
                s[i].y2 = b[i].Y;
            }

            for (int i = 18; i < 35; ++i)
            {
                s[i].x1 = a[i - 18].X;
                s[i].y1 = a[i - 18].Y;
                s[i].x2 = a[i - 17].X;
                s[i].y2 = a[i - 17].Y;
            }
            s[35].x1 = a[17].X;
            s[35].y1 = a[17].Y;
            s[35].x2 = a[0].X;
            s[35].y2 = a[0].Y;

            for (int i = 36; i < 53; ++i)
            {
                s[i].x1 = b[i - 36].X;
                s[i].y1 = b[i - 36].Y;
                s[i].x2 = b[i - 35].X;
                s[i].y2 = b[i - 35].Y;
            }
            s[53].x1 = b[17].X;
            s[53].y1 = b[17].Y;
            s[53].x2 = b[0].X;
            s[53].y2 = b[0].Y;

            return s;
        }

        Graphics g;
        static Brush myBrush = new SolidBrush(Color.Green);
        Pen myPen = new Pen(myBrush);

        points[] sideA = createSide(1);
        points[] sideB = createSide(2);

        private void button1_Click(object sender, EventArgs e)
        {
            g = pictureBox1.CreateGraphics();
           
            for(int i = 0; i < 18; ++i)
            {
                /*turnZ(ref sideA[i], 0.927295218);
                turnZ(ref sideB[i], 0.927295218);
                turnY(ref sideA[i], -0.927295218);
                turnY(ref sideB[i], -0.927295218);*/
            }
            lines[] letterS = createLetter(sideA, sideB);
           
            for (int i = 0; i < 54; ++i)
                g.DrawLine(myPen, (float)letterS[i].x1, (float)letterS[i].y1, (float)letterS[i].x2, (float)letterS[i].y2);
            

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            g = pictureBox1.CreateGraphics();
            g.Clear(pictureBox1.BackColor);

            for (int i = 0; i < 18; ++i)
            {
                allign(ref sideA[i]);
                allign(ref sideB[i]);
                turnY(ref sideA[i], 6.174533);
                turnY(ref sideB[i], 6.174533);
                disallign(ref sideA[i]);
                disallign(ref sideB[i]);

            }
            lines[] letterS = createLetter(sideA, sideB);

            for (int i = 0; i < 54; ++i)
                g.DrawLine(myPen, (float)letterS[i].x1, (float)letterS[i].y1, (float)letterS[i].x2, (float)letterS[i].y2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            g = pictureBox1.CreateGraphics();
            g.Clear(pictureBox1.BackColor);

            for (int i = 0; i < 18; ++i)
            {
                allign(ref sideA[i]);
                allign(ref sideB[i]);
                turnY(ref sideA[i], 0.174533);
                turnY(ref sideB[i], 0.174533);
                disallign(ref sideA[i]);
                disallign(ref sideB[i]);

            }
            lines[] letterS = createLetter(sideA, sideB);

            for (int i = 0; i < 54; ++i)
                g.DrawLine(myPen, (float)letterS[i].x1, (float)letterS[i].y1, (float)letterS[i].x2, (float)letterS[i].y2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            g = pictureBox1.CreateGraphics();
            g.Clear(pictureBox1.BackColor);

            for (int i = 0; i < 18; ++i)
            {
                allign(ref sideA[i]);
                allign(ref sideB[i]);
                turnX(ref sideA[i], 0.174533);
                turnX(ref sideB[i], 0.174533);
                disallign(ref sideA[i]);
                disallign(ref sideB[i]);

            }
            lines[] letterS = createLetter(sideA, sideB);

            for (int i = 0; i < 54; ++i)
                g.DrawLine(myPen, (float)letterS[i].x1, (float)letterS[i].y1, (float)letterS[i].x2, (float)letterS[i].y2);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            g = pictureBox1.CreateGraphics();
            g.Clear(pictureBox1.BackColor);

            for (int i = 0; i < 18; ++i)
            {
                allign(ref sideA[i]);
                allign(ref sideB[i]);
                turnX(ref sideA[i], 6.174533);
                turnX(ref sideB[i], 6.174533);
                disallign(ref sideA[i]);
                disallign(ref sideB[i]);

            }
            lines[] letterS = createLetter(sideA, sideB);

            for (int i = 0; i < 54; ++i)
                g.DrawLine(myPen, (float)letterS[i].x1, (float)letterS[i].y1, (float)letterS[i].x2, (float)letterS[i].y2);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            g = pictureBox1.CreateGraphics();
            g.Clear(pictureBox1.BackColor);

            for (int i = 0; i < 18; ++i)
            {
                allign(ref sideA[i]);
                allign(ref sideB[i]);
                turnZ(ref sideA[i], 6.174533);
                turnZ(ref sideB[i], 6.174533);
                disallign(ref sideA[i]);
                disallign(ref sideB[i]);

            }
            lines[] letterS = createLetter(sideA, sideB);

            for (int i = 0; i < 54; ++i)
                g.DrawLine(myPen, (float)letterS[i].x1, (float)letterS[i].y1, (float)letterS[i].x2, (float)letterS[i].y2);
        }
        

        private void button7_Click(object sender, EventArgs e)
        {
            g = pictureBox1.CreateGraphics();
            g.Clear(pictureBox1.BackColor);
            
            for (int i = 0; i < 18; ++i)
            {
                allign(ref sideA[i]);
                allign(ref sideB[i]);
                zooming(ref sideA[i], 2);
                zooming(ref sideB[i], 2);
                disallign(ref sideA[i]);
                disallign(ref sideB[i]);

            }
            lines[] letterS = createLetter(sideA, sideB);

            zoomin *= 2;
            for (int i = 0; i < 54; ++i)
                g.DrawLine(myPen, (float)letterS[i].x1, (float)letterS[i].y1, (float)letterS[i].x2, (float)letterS[i].y2);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            g = pictureBox1.CreateGraphics();
            g.Clear(pictureBox1.BackColor);
            
            for (int i = 0; i < 18; ++i)
            {
                allign(ref sideA[i]);
                allign(ref sideB[i]);
                zooming(ref sideA[i], 0.5);
                zooming(ref sideB[i], 0.5);
                disallign(ref sideA[i]);
                disallign(ref sideB[i]);

            }
            lines[] letterS = createLetter(sideA, sideB);

            zoomout *= 2;
            for (int i = 0; i < 54; ++i)
                g.DrawLine(myPen, (float)letterS[i].x1, (float)letterS[i].y1, (float)letterS[i].x2, (float)letterS[i].y2);
        }

        
        private void button10_Click(object sender, EventArgs e)
        {
            g = pictureBox1.CreateGraphics();
            g.Clear(pictureBox1.BackColor);
            up++;
            for (int i = 0; i < 18; ++i)
            {
                shifting(ref sideA[i],0,10,0);
                shifting(ref sideB[i],0,10,0);

            }
            lines[] letterS = createLetter(sideA, sideB);

            for (int i = 0; i < 54; ++i)
                g.DrawLine(myPen, (float)letterS[i].x1, (float)letterS[i].y1, (float)letterS[i].x2, (float)letterS[i].y2);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            g = pictureBox1.CreateGraphics();
            g.Clear(pictureBox1.BackColor);
            down++;
            for (int i = 0; i < 18; ++i)
            {
                shifting(ref sideA[i], 0, -10, 0);
                shifting(ref sideB[i], 0, -10, 0);

            }
            lines[] letterS = createLetter(sideA, sideB);

            for (int i = 0; i < 54; ++i)
                g.DrawLine(myPen, (float)letterS[i].x1, (float)letterS[i].y1, (float)letterS[i].x2, (float)letterS[i].y2);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            g = pictureBox1.CreateGraphics();
            g.Clear(pictureBox1.BackColor);
            left++;
            for (int i = 0; i < 18; ++i)
            {
                shifting(ref sideA[i], 10, 0, 0);
                shifting(ref sideB[i], 10, 0, 0);

            }
            lines[] letterS = createLetter(sideA, sideB);

            for (int i = 0; i < 54; ++i)
                g.DrawLine(myPen, (float)letterS[i].x1, (float)letterS[i].y1, (float)letterS[i].x2, (float)letterS[i].y2);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            g = pictureBox1.CreateGraphics();
            g.Clear(pictureBox1.BackColor);
            right++;
            for (int i = 0; i < 18; ++i)
            {
                shifting(ref sideA[i], -10, 0, 0);
                shifting(ref sideB[i], -10, 0, 0);

            }
            lines[] letterS = createLetter(sideA, sideB);

            for (int i = 0; i < 54; ++i)
                g.DrawLine(myPen, (float)letterS[i].x1, (float)letterS[i].y1, (float)letterS[i].x2, (float)letterS[i].y2);
        }

    }

}
