using Shared;
using Tabletop;

namespace Tabletop
{
    public struct AttackResult
    {
        public bool IsHit;
        public bool IsWounded;
        public int Wounds;
    }

    public class AttackResolutionManager
    {
        public AttackResult MakeAttack(TabletopSoldier attacker, TabletopSoldier target, float attackRange)
        {
            var attackResult = new AttackResult();
            int weaponRange = attacker.EquippedWeapon.Range;

            if (attackRange <= weaponRange)
            {
                attackResult.IsHit = D6.Roll() >= attacker.CurrentStats.GetBaseBSRoll();
                if (attackResult.IsHit)
                {
                    attackResult.IsWounded = D6.Roll() >= target.CurrentStats.GetWoundRoll(attacker.EquippedWeapon.Strength);
                    if (!attackResult.IsWounded)
                    {
                        UnityEngine.Debug.Log("Not wounded");
                    }
                }
                else
                {
                    UnityEngine.Debug.Log("Missed");
                }
            }
            return attackResult;
        }
    }
}

