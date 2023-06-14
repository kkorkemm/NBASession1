using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBASession1.Base
{
    public partial class Player
    {
        public int Experience => DateTime.Now.Year - JoinYear.Year;
        public string Team => PlayerInTeam.FirstOrDefault() != null ? PlayerInTeam.FirstOrDefault().Team.Abbr : "";
        public string No => PlayerInTeam.FirstOrDefault() != null ? PlayerInTeam.FirstOrDefault().ShirtNumber : "";

        public int Season => PlayerInTeam.FirstOrDefault() != null ? PlayerInTeam.FirstOrDefault().SeasonId : 0;

        public int TeamID => PlayerInTeam.FirstOrDefault() != null ? PlayerInTeam.FirstOrDefault().Team.TeamId : 0;
    }
}
