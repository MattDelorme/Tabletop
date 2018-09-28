using System;
using UnityEngine;

namespace Tabletop
{
    [Serializable]
    public struct WeaponModifier
    {
        #pragma warning disable 0649
        [SerializeField] int shortRange;
        [SerializeField] int longRange;
        #pragma warning restore 0649

        public int ShortRange { get { return shortRange; } }
        public int LongRange { get { return longRange; } }

        public static WeaponModifier operator +(WeaponModifier a, WeaponModifier b)
        {
            WeaponModifier result = new WeaponModifier();

            result.shortRange = a.shortRange + b.shortRange;
            result.longRange = a.longRange + b.longRange;

            return result;
        }

        public static WeaponModifier operator -(WeaponModifier a, WeaponModifier b)
        {
            WeaponModifier result = new WeaponModifier();

            result.shortRange = a.shortRange - b.shortRange;
            result.longRange = a.longRange - b.longRange;

            return result;
        }
    }
}
