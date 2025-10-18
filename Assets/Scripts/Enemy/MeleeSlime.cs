using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using SAE.GAD176.SlimeBall.Healing;
using JetBrains.Annotations;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using UnityEditor.Experimental.GraphView;

public class MeleeSlime : EnemyAI
{
 //  protected override DamageType weakness => DamageType.Fire;
    
    private float attackRange;
    private int attackPower;
    private SlimeBall slimeballScript;
    [SerializeField]private GameObject slimeDrops;
    [SerializeField]private int healthLow;
    private void Awake()
    {
        slimeDrops = GameObject.FindGameObjectWithTag("droppedItems");
    }
 
    public override void AttackPlayer()
    {
       // Debug.Log("slimeAttack");
        //if in attackRange
        //attacks player 
    }
    public override void EnemyMove()
    {
        if (EnemyHealth <= healthLow)
        {
           LowHealth();
        }
        
        if (distanceFromPlayer <= detectionDistance && EnemyHealth > healthLow)
            // move player towards player
            rigidBody.MovePosition(transform.position + (player.transform.position - transform.position) * movementSpeed * Time.fixedDeltaTime);
        //work from week 5 class content
       
    }
    public void LowHealth()
    {
        //when low on health
        if (slimeDrops == null)
        {
            slimeDrops = GameObject.FindGameObjectWithTag("droppedItems");
        }
       //seeks closest dropped Item
            rigidBody.MovePosition(transform.position + (slimeDrops.transform.position - transform.position) * movementSpeed * Time.fixedDeltaTime);
    }
    public void AbsorbHeal()
    {   
        slimeballScript = slimeDrops.GetComponent<SlimeBall>();
        //calling amount from slimeballscript to heal
        Debug.Log("heal");
        //EnemyHealth += slimeballScript.healingAmount;
        //destroys dropItems to heal health
        
    }

    
}

