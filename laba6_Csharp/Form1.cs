using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static laba6_Csharp.Particle;

namespace laba6_Csharp
{
    public partial class Form1: Form
    {
        Emitter emitter = new Emitter(); // добавили эмиттер

        public Form1()
        {
            InitializeComponent();
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

            // добавил точечку
            emitter.gravityPoints.Add(new Point(
                picDisplay.Width / 2, picDisplay.Height / 2
            ));

            // добавил еще две        
            emitter.gravityPoints.Add(new Point(
              (int)(picDisplay.Width * 0.75), picDisplay.Height / 2
           ));

            emitter.gravityPoints.Add(new Point(
               (int)(picDisplay.Width * 0.25), picDisplay.Height / 2
           ));
        }

        int counter = 0; // добавлю счетчик чтобы считать вызовы функции

        // ну и обработка тика таймера, тут просто декомпозицию выполнили
        private void timer1_Tick(object sender, EventArgs e)
        {
            emitter.UpdateState(); // тут теперь обновляем эмиттер

            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.Black);
                emitter.Render(g); // а тут теперь рендерим через эмиттер
            }

            picDisplay.Invalidate();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // добавляем переменные для хранения положения мыши
        //private int MousePositionX = 0;
        //private int MousePositionY = 0;

        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            // а тут в эмиттер передаем положение мыфки
            emitter.MousePositionX = e.X;
            emitter.MousePositionY = e.Y;
        }
    }
}
