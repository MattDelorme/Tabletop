using System;
using Shared.Unity;
using UnityEngine;

namespace Tabletop
{
    [CreateAssetMenu(menuName="Data Definitions/Tabletop Weapon Data Definition")]
    public class WeaponDataDefinition : DataDefinition
    {
        #pragma warning disable 0649
        [SerializeField] int range;
        [SerializeField] int shortRange;
        [SerializeField] int strength;
        #pragma warning restore 0649

        public int Range { get { return range; } }
        public int ShortRange { get { return shortRange; } }
        public int Strength { get { return strength; } }
    }

    [Serializable]
    public class WeaponDataDefinitionId : DataDefinitionId<WeaponDataDefinition> { }
}
