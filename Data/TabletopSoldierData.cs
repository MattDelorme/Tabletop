using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tabletop
{
    [Serializable]
    public class TabletopSoldierData
    {
        public string Name;
        public TabletopStats BaseStats;
        public List<WeaponDataDefinitionId> Weapons;

        [SerializeField] int equippedWeaponIndex;
        public WeaponDataDefinitionId EquippedWeapon
        {
            get { return Weapons.Count > 0 ? Weapons[equippedWeaponIndex] : null; }
        }

        [SerializeField]
        private List<TabletopStats> modifiers;
        public IEnumerable<TabletopStats> Modifiers { get { return modifiers; } }

        public void AddModifier(TabletopStats modifier)
        {
            if (modifiers == null)
            {
                modifiers = new List<TabletopStats>();
            }
            modifiers.Add(modifier);
        }

        public void RemoveModifier(TabletopStats modifier)
        {
            if (modifiers != null)
            {
                modifiers.Remove(modifier);
            }
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
