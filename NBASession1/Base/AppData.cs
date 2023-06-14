using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBASession1.Base
{
    public class AppData
    {
        private static NBA_DBEntities context;
        public static NBA_DBEntities GetContext()
        {
            if (context == null)
                context = new NBA_DBEntities();
            return context;
        }
    }
}
