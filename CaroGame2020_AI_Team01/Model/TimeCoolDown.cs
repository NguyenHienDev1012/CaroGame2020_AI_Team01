using System.Windows.Forms;

namespace CaroGame2020_AI_Team01.Model
{
    public class TimeCoolDown
    {
        private Timer mytimeCoolDown;
        private ProgressBar pgbCoolDown;

        public TimeCoolDown(Timer mytimeCoolDown, ProgressBar pgbCoolDown)
        {
            this.mytimeCoolDown = mytimeCoolDown;
            this.pgbCoolDown = pgbCoolDown;
        }

        public Timer MyTimeCoolDown
        {
            get => mytimeCoolDown;
            set => mytimeCoolDown = value;
        }

        public ProgressBar PgbCoolDown
        {
            get => pgbCoolDown;
            set => pgbCoolDown = value;
        }
    }
}