using System;
using System.Collections.Generic;

namespace Tabletop
{
    [Serializable]
    public class TabletopSoldierTeamData
    {
        public string Name;
        public List<TabletopSoldierData> Soldiers;
    }
}

