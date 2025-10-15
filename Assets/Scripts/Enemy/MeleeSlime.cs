using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using SAE.GAD176.SlimeBall.Healing;
using JetBrains.Annotations;
public class MeleeSlime : EnemyAI
{
    private float attackRange;
    private int attackPower;
    private SlimeBall slimeball;
    protected int health = 20;
    public string weakness;
    public string resistance1;

    private void Attack()
    {
        //if in attackRange
        //attacks player 
    }
    public void LowHealth()
    {
        //when low on health
        if (healthAmount >= 5)
        {
            //seeks closest dropped Item
        }

    }

    public void AbsorbHeal()
    {
        //calling amount from slimeball to heal
        healthAmount += slimeball.healingAmount;
        //destroys dropItems to heal health
        SlimeBall.Destroy(this);
    }
}

/*namespace SAE.GAD176.damageMultiplier.MeleeSlime
{
    public class MeleeSlime : EnemyAI
    {

        public override void SetResistance()
        {
            DamageType resistance1 = DamageType.Slash;
            DamageType resistance2 = DamageType.None;
            base.SetResistance();
        }
        public override void SetWeakness()
        {
            DamageType weakness1 = DamageType.Blunt;
            DamageType weakness2 = DamageType.None;
            base.SetWeakness();
        }

    }
}*/

