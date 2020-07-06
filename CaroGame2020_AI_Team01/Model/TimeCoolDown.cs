using System.Windows.Forms;

namespace CaroGame2020_AI_Team01.Model
{
    public class TimeCoolDown
    {
        private Timer MytimeCoolDown;
        private ProgressBar pgbCoolDown;

        public TimeCoolDown(Timer timeCoolDown, ProgressBar pgbCoolDown)
        {
            this.MytimeCoolDown = timeCoolDown;
            this.pgbCoolDown = pgbCoolDown;
        }

        public Timer MyTimeCoolDown
        {
            get => MytimeCoolDown;
            set => MytimeCoolDown = value;
        }

        public ProgressBar PgbCoolDown
        {
            get => pgbCoolDown;
            set => pgbCoolDown = value;
        }
    }
}