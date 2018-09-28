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

        #pragma warning disable 0649
        [SerializeField] List<WeaponData> weapons;
        #pragma warning restore 0649

        [SerializeField] int equippedWeaponIndex;
        public WeaponDataDefinitionId EquippedWeapon
        {
            get { return weapons != null && weapons.Count > equippedWeaponIndex ? weapons[equippedWeaponIndex].Weapon : null; }
        }

        public List<WeaponAttachmentDataDefinitionId> EquippedWeaponAttachments
        {
            get
            {
                return weapons != null && weapons.Count > equippedWeaponIndex && weapons[equippedWeaponIndex].WeaponAttachments != null ?
                    weapons[equippedWeaponIndex].WeaponAttachments
                        : new List<WeaponAttachmentDataDefinitionId>();
            }
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
            if (weapons.Count > weaponIndex)
            {
                equippedWeaponIndex = weaponIndex;
            }
            else
            {
                throw new IndexOutOfRangeException(string.Format("Index {0} is out of range, Weapons count is {1}", weaponIndex, weapons.Count));
            }
        }
    }
}
