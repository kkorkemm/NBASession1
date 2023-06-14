using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBASession1.Base
{
    public partial class Matchup
    {
        public string Result => Team_Away_Score + " - " + Team_Home_Score;
        public string Name => Team.TeamName + " @ " + Team1.TeamName;

        public string StatusName
        {
            get
            {
                if (Status == 1)
                    return "Finished";
                else if (Status == 0)
                    return "Running";
                else
                    return "Not Start";
            }
        }
        public string StatusColor
        {
            get
            {
                if (Status == 1)
                    return "Gray";
                else if (Status == 0)
                    return "Red";
                else
                    return "Blue";
            }
        }
        public string Finished
        {
            get
            {
                if (Status == 1)
                    return "Yes";
                else
                    return "No";
            }
        }
    }
}
