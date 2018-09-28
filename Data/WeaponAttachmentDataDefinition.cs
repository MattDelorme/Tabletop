using System;
using System.Collections.Generic;
using Shared.Unity;
using UnityEngine;

namespace Tabletop
{
    [CreateAssetMenu(menuName="Data Definitions/Weapon Attachment Data Definition")]
    public class WeaponAttachmentDataDefinition : DataDefinition
    {
        public List<WeaponModifier> Modifiers;
    }

    [Serializable]
    public class WeaponAttachmentDataDefinitionId : DataDefinitionId<WeaponAttachmentDataDefinition> { }
}
