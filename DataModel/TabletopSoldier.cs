using System;
using System.Collections.Generic;

namespace Tabletop
{
    [Serializable]
    public class TabletopSoldier
    {
        public TabletopStats BaseStats;
        public List<TabletopWeapon> Weapons;

        private int equippedWeaponIndex;
        public TabletopWeapon EquippedWeapon
        {
            get { return Weapons.Count > 0 ? Weapons[equippedWeaponIndex] : null; }
        }

        public void EquipWeapon(int weaponIndex)
        {
            if (Weapons.Count > weaponIndex)
            {
                equippedWeaponIndex = weaponIndex;
            }
            else
            {
                throw new IndexOutOfRangeException(string.Format("Index {0} is out of range, Weapons count is {1}", weaponIndex, Weapons.Count));
            }
        }
    }
}
