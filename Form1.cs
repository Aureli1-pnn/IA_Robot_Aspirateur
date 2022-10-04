using System;
using System.Threading;

namespace Graphic_interface
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            int dimension = Constants.DIMENSION;
            this.Width = dimension * 200 + 20;
            this.Height = dimension * 200 + 50;
        }

        // Create pen.
        Pen whitePen = new Pen(Color.White, 3);
        Pen blackPen = new Pen(Color.Black, 3);
        Pen redPen = new Pen(Color.Red, 3);
        Pen bluePen = new Pen(Color.Aqua, 3);
        Pen greenPen = new Pen(Color.Green, 3);
        public int dim = Constants.DIMENSION;

        //pour remplir les formes
        SolidBrush greenBrush = new SolidBrush(Color.Green);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush blueBrush = new SolidBrush(Color.Aqua);
        SolidBrush whiteBrush = new SolidBrush(Color.White);

        //à modifier selon les coordonnées du Robot et de l'environnement
        public int x = 4;
        public int y = 4;  


        public void Initiate_Graph(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;



            //fond blanc selon les dimensions données
            g.DrawRectangle(whitePen, 0, 0, 1000, 1000);
            Rectangle recttemp = new Rectangle(0, 0, 1000, 1000);
            g.FillRectangle(whiteBrush, recttemp);



            /*int dim = Constants.DIMENSION;*/
            //lignes verticales
            for (int i = 0; i < dim * 200; i++)
            {
                g.DrawLine(blackPen, i * 200, 0, i * 200, dim * 200);

            }

            Thread.Sleep(3000);

            //lignes horizontales 
            for (int i = 0; i < dim * 200; i++)
            {
                g.DrawLine(blackPen, 0, i * 200, dim * 200, i * 200);
            }

            /*Thread.Sleep(3000);*/


        }

        public void add_jewel(object sender, PaintEventArgs e)
        {
            Thread.Sleep(8000);
            Graphics g = e.Graphics;
            Rectangle temp2 = new Rectangle(x * 200 + 110, y * 200 + 110, 80, 80);
            g.DrawEllipse(bluePen, temp2);
            g.FillEllipse(blueBrush, temp2);
        }
        public void erase_jewel(object sender, PaintEventArgs e) {
            Graphics g = e.Graphics;
            Rectangle temp2 = new Rectangle(x * 200 + 110, y * 200 + 110, 80, 80);
            g.DrawEllipse(whitePen, temp2);
            g.FillEllipse(whiteBrush, temp2);
        }

        public void add_robot(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawRectangle(greenPen, x * 200 + 20, y * 200 + 10, 160, 80);
            Rectangle temp = new Rectangle(x * 200 + 20, y * 200 + 10, 160, 80);
            g.FillRectangle(greenBrush, temp);
        }

        public void erase_robot(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawRectangle(whitePen, x * 200 + 20, y * 200 + 10, 160, 80);
            Rectangle temp = new Rectangle(x * 200 + 20, y * 200 + 10, 160, 80);
            g.FillRectangle(whiteBrush, temp);
        }

        public void add_dust(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawRectangle(redPen, x * 200 + 10, y * 200 + 110, 80, 80);
            Rectangle temp3 = new Rectangle(x * 200 + 10, y * 200 + 110, 80, 80);
            g.FillRectangle(redBrush, temp3);
        }

        public void erase_dust(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawRectangle(whitePen, x * 200 + 10, y * 200 + 110, 80, 80);
            Rectangle temp3 = new Rectangle(x * 200 + 10, y * 200 + 110, 80, 80);
            g.FillRectangle(whiteBrush, temp3);
        }






        /*public void template_graph(object sender, PaintEventArgs e) {

            *//*int dim = Constants.DIMENSION;*//*
            Graphics g = e.Graphics;
            for (int i = 0; i < dim * 200; i++)
            {
                for (int j = 0; j < dim * 200; j++)
                {
                    //condition robot
                    g.DrawRectangle(greenPen, i * 200 + 20, j * 200 + 10, 160, 80);
                    Rectangle temp = new Rectangle(i * 200 + 20, j * 200 + 10, 160, 80);
                    g.FillRectangle(greenBrush, temp);

                    //condition bijou
                    Rectangle temp2 = new Rectangle(i * 200 + 110, j * 200 + 110, 80, 80);
                    g.DrawEllipse(bluePen, temp2);
                    g.FillEllipse(blueBrush, temp2);

                    //condition poussiere
                    g.DrawRectangle(redPen, i * 200 + 10, j * 200 + 110, 80, 80);
                    Rectangle temp3 = new Rectangle(i * 200 + 10, j * 200 + 110, 80, 80);
                    g.FillRectangle(redBrush, temp3);


                }
            }



        }*/
    }
}