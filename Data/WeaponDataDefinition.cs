using System;
using Shared.Unity;
using UnityEngine;

namespace Tabletop
{
    [CreateAssetMenu(menuName="Data Definitions/Weapon Data Definition")]
    public class WeaponDataDefinition : DataDefinition
    {
        #pragma warning disable 0649
        [SerializeField] int shortRange;
        [SerializeField] int longRange;
        [SerializeField] int strength;
        [SerializeField] WeaponModifier modifier;
        #pragma warning restore 0649

        public int ShortRange { get { return shortRange; } }
        public int LongRange { get { return longRange; } }
        public int Strength { get { return strength; } }

        public WeaponModifier Modifier { get { return modifier; } }
    }

    [Serializable]
    public class WeaponDataDefinitionId : DataDefinitionId<WeaponDataDefinition> { }
}
