using System.Drawing;
using System.Windows.Forms;

namespace CaroGame2020_AI_Team01.Model
{
    public class Field : Button
    {
        private Point position;
        private Image mark;

        public Field(Point position, Image mark)
        {
            this.position = position;
            this.mark = mark;
        }

        public Point Position
        {
            get => position;
            set => position = value;
        }

        public Image Mark
        {
            get
            {
                return mark;
            }
            set
            {
                mark = value;
                this.BackgroundImageLayout = ImageLayout.Stretch;
                this.BackgroundImage = mark;
            }
        }

        public Field()
        {
        }
        public Field(int fWidth, int fHeight)
        {
            this.Size = new Size(fWidth, fHeight);
        }

    }
}