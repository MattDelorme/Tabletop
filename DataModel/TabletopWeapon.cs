using UnityEngine;

namespace Tabletop
{
    [CreateAssetMenu(menuName = "Definitions/TabletopWeapon")]
    public class TabletopWeapon : ScriptableObject
    {
        public int Range;
        public int Strength;
    }
}
