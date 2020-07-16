using System.Drawing;

namespace CaroGame2020_AI_Team01
{
    public class Player
    {
        private string name;
        private Image mark;

        public Player(string name, Image mark)
        {
            this.name = name;
            this.mark = mark;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public Image Mark
        {
            get => mark;
            set => mark = value;
        }
    }
}