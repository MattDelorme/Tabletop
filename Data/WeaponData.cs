using System;
using System.Collections.Generic;

namespace Tabletop
{
    [Serializable]
    public class WeaponData
    {
        public WeaponDataDefinitionId Weapon;
        public List<WeaponAttachmentDataDefinitionId> WeaponAttachments;
    }
}
