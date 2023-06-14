using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBASession1.Base
{
    public partial class Team
    {
        public string Conference => Division.Conference.Name;
        public decimal Salary
        {
            get
            {
                decimal salary = 0;
                foreach (var player in PlayerInTeam)
                {
                    salary += player.Salary;
                }
                return salary;
            }
        }
    }
}
