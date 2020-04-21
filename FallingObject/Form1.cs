using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FallingObject
{
    public partial class Form1 : Form
    {

        float x=0, y, vx, vy, vx0, vy0, v, alpha, t=0 , y0, ax, ay, x0 ;

        private void button3_Click(object sender, EventArgs e)
        {
            axis1.ClearDin();
            axis1.ClearPic(); 
            x = 0; y = 0; t = 0; 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
            x = 0; y = 0; t = 0; 
        }

          public Form1()
        {
            InitializeComponent();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
           float dt = 0.01f;
            t = t + dt;          
            vx = vx - t * vx * vx * 0.001f;
            x = x + vx * t;
            vy = vy + t * 9.81f;
            y = y - vy * t;
            if (y <= 0)
            {
                timer2.Enabled = false;
                x = 0; y = 0; t = 0;
            }
            axis1.PixDraw(x, y, Color.Green, 1);
            axis1.StatToPic();
        }

        private void button1_Click(object sender, EventArgs e)
        {

           try {
            y = (float)(Convert.ToDouble(textBox3.Text));
               }catch
            {
                y = 0; 
            }
            alpha = (float)Convert.ToDouble(textBox1.Text);
            v = (float)(Convert.ToDouble(textBox2.Text));
            vx = (float)(v * Math.Cos(alpha * Math.PI / 180));
            vy = (float)(v * Math.Sin(-alpha * Math.PI / 180));  
            if (checkBox1.Checked == false)
            {
                timer1.Interval = 1;
                timer1.Enabled = true;
            }
            else
            {
                timer2.Interval = 1;
                timer2.Enabled = true;
            }
        }
        private void axis1_Load(object sender, EventArgs e)
        {
            axis1.Axis_Type = 3;
            axis1.x_Name = "X";
            axis1.y_Name = "Y";
            axis1.x_Base = 1000;
            axis1.y_Base = 1000;
            axis1.Pix_Size = 0.008f;
            axis1.AxisDraw();
            axis1.PixDraw(x, y, Color.Black, 1);
            axis1.StatToPic();
        }
        private void timer1_Tick(object sender,  EventArgs e)
        {

            t = t + 0.1f;
            x = vx * t;
            try
            {
 y = (float)((float)(Convert.ToDouble(textBox3.Text)) - vy * t - 9.82 * t * t / 2);
            }
            catch
            {
                y = (float)(- vy * t - 9.82 * t * t / 2);
            }
            if (y <= 0)
            {
                timer1.Enabled = false;
                x = 0; y = 0; t = 0;
            }

            axis1.PixDraw(x, y, Color.Red, 1);
            axis1.StatToPic();
        }

 
      


    }
}
