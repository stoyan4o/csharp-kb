using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KnowledgeBaseAllInOne
{
    public partial class GDIDrawInForm : Form
    {
        Graphics g;
        Ball ball;

        public GDIDrawInForm()
        {
            InitializeComponent();
        }

        private void GDIDrawInForm_Load(object sender, EventArgs e)
        {
            g = Graphics.FromHwnd(this.Handle); // use when drawing in a own method not in OnPaint
            ball = new Ball();

            ball.Pos.X = 40;
            ball.Pos.Y = 40;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            ball.Draw(e.Graphics);
        }
    }

    class SimpleSprite
    {
        internal Point Pos;
        protected Pen pen;

        public SimpleSprite()
        {
            pen = new Pen(Color.Green,2.0f);
        }

        public virtual void Draw(System.Drawing.Graphics g)
        {
            // 
        }
    }

    class Ball : SimpleSprite
    {
        public override void Draw(Graphics g)
        {
            g.DrawEllipse(pen, this.Pos.X, this.Pos.Y, 20, 20);
        }
    }
}
