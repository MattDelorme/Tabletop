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
            if (attackRange <= attacker.EquippedWeapon.LongRange)
            {
                WeaponModifier weaponModifier = attacker.EquippedWeapon.Modifier;
                var equippedWeaponAttachments = attacker.EquippedWeaponAttachments;
                for (int i = 0; i < equippedWeaponAttachments.Count; i++)
                {
                    for (int j = 0; j < equippedWeaponAttachments[i].Modifiers.Count; j++)
                    {
                        weaponModifier += equippedWeaponAttachments[i].Modifiers[j];
                    }
                }

                int rangeModifier = attackRange <= attacker.EquippedWeapon.ShortRange ? weaponModifier.ShortRange : weaponModifier.LongRange;

                int hitRoll = D6.Roll();
                attackResult.IsHit = hitRoll + rangeModifier >= attacker.CurrentStats.GetBaseBSRoll();
                if (attackResult.IsHit)
                {
                    int woundRoll = D6.Roll();
                    attackResult.IsWounded = woundRoll >= target.CurrentStats.GetWoundRoll(attacker.EquippedWeapon.Strength);
                    if (attackResult.IsWounded)
                    {
                        attackResult.Wounds = 1;
                    }
                    else
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

