using System.Collections.Generic;
using System.Drawing;

namespace CaroGame2020_AI_Team01.Model
{
    public class Cons
    {
        public static string FULL_PATH =
            "C:\\Users\\VõThanh\\Desktop\\COURSES\\AI\\Project\\CaroGame2020_AI_Team01\\CaroGame2020_AI_Team01\\Resources\\";
        public static List<string> MODE = new List<string>()
        {
            "1 vs 1", "AI", "LAN"
        };

        public static List<Image> MARK = new List<Image>()
        {
            Image.FromFile(FULL_PATH+"o_color.png"), Image.FromFile(FULL_PATH+"x_color.png")
        };

        public static int RULE = 5;
        public static int F_HEIGHT = 30;
        public static int F_WIDTH = 30;
        public static int ROWS = 14;
        public static int COLUMNS = 16;

        public static int COOL_DOWN_STEP = 100;
        public static int COOL_DOWN_TIME = 10000;
        public static int COOL_DOWN_INTERVAL = 100;

    }
}