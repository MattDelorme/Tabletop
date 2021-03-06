﻿using System;
using System.Collections.Generic;
using Shared;
using Tabletop;

namespace Tabletop
{
    [Serializable]
    public class TabletopSoldier
    {
        public TabletopStats CurrentStats { get; private set; }

        public int CurrentWounds { get; private set; }

        private WeaponDataDefinition equippedWeapon;
        public WeaponDataDefinition EquippedWeapon
        {
            get
            {
                if (tabletopSoldierData.EquippedWeapon != null)
                {
                    if (equippedWeapon != null && equippedWeapon.Id == tabletopSoldierData.EquippedWeapon.Id)
                    {
                        return equippedWeapon;
                    }
                    else
                    {
                        equippedWeapon = Service.Get<Data>().GetDataDefinitionById(tabletopSoldierData.EquippedWeapon);
                        return equippedWeapon;
                    }
                }
                else
                {
                    return null;
                }
            }
        }

        public List<WeaponAttachmentDataDefinition> EquippedWeaponAttachments
        {
            get
            {
                List<WeaponAttachmentDataDefinition> equippedWeaponAttachments = new List<WeaponAttachmentDataDefinition>();
                for (int i = 0; i < tabletopSoldierData.EquippedWeaponAttachments.Count; i++)
                {
                    equippedWeaponAttachments.Add(Service.Get<Data>().GetDataDefinitionById(tabletopSoldierData.EquippedWeaponAttachments[i]));
                }
                return equippedWeaponAttachments;
            }
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

//        public void AddModifier(TabletopStats modifier)
//        {
//            if (modifiers == null)
//            {
//                modifiers = new List<TabletopStats>();
//            }
//            modifiers.Add(modifier);
//        }
    }
}
