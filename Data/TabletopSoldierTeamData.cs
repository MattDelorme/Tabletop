using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tabletop
{
    [Serializable]
    public class TabletopSoldierTeamData : ScriptableObject
    {
        public string Name;
        public List<TabletopSoldierData> Soldiers;
    }
}

