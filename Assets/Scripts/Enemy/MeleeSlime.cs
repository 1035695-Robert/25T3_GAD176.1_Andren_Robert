using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using SAE.GAD176.SlimeBall.Healing;
using JetBrains.Annotations;
using System.Runtime.CompilerServices;
using System.ComponentModel;

public class MeleeSlime : EnemyAI
{
 //  protected override DamageType weakness => DamageType.Fire;
    
    private float attackRange;
    private int attackPower;
    private SlimeBall slimeball;
    protected int health = 20;
   

    private void Start()
    {
       
    }
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

