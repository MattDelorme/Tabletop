using System;
using Tabletop;

namespace Tabletop
{
    [Serializable]
    public class TabletopSoldier
    {
        public TabletopStats CurrentStats { get; private set; }

        public int CurrentWounds { get; private set; }

        public TabletopWeapon EquippedWeapon
        {
            get { return tabletopSoldierData.EquippedWeapon; }
        }

        private readonly TabletopSoldierData tabletopSoldierData;

        public TabletopSoldier(TabletopSoldierData tabletopSoldierData)
        {
            this.tabletopSoldierData = tabletopSoldierData;
            CurrentStats = tabletopSoldierData.BaseStats;
            foreach (var modifier in tabletopSoldierData.Modifiers)
            {
                CurrentStats += modifier;
            }
            CurrentWounds = CurrentStats.W;
        }

        public void ApplyWounds(int wounds)
        {
            CurrentWounds -= wounds;
            CurrentWounds = CurrentWounds < 0 ? 0 : CurrentWounds;
        }
    }
}
