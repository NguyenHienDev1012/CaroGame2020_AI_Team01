using System.Drawing;
using System.Windows.Forms;

namespace CaroGame2020_AI_Team01.Model
{
    public class Field : Button
    {
        // private int fHeight;
        // private int fWidth;

        public Field(int fWidth,int fHeight)
        {
            this.Size = new Size(fWidth,fHeight);
        }

        // public int FHeight
        // {
        //     get => fHeight;
        //     set => fHeight = value;
        // }
        //
        // public int FWidth
        // {
        //     get => fWidth;
        //     set => fWidth = value;
        // }

        // private void setSize(int height, int width)
        // {
        //     this.Size = new Size(height,width);
        // }
    }
}