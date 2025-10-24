using Unity.VisualScripting;
using UnityEngine;

public class DamageMultiplier : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   
    [SerializeField] private float baseAttackDamage;
    private float damageMultiplier = 1.5f;
    public float damage;
    [SerializeField] private DamageType damageMultiplyType = DamageType.Undefined;

    protected EnemyAI enemyAiScript;
    [SerializeField] protected GameObject[] enemylist;



   

    private void OnTriggerEnter (Collider attackHit)
    {
        if (attackHit.gameObject.CompareTag("enemy"))                               //this prevents anything other than the enemies to take damage through this script.
        {

           enemyAiScript = attackHit.gameObject.GetComponent<EnemyAI>();          //finds the script for the enemy that was hit

            Debug.Log("enemy health test: " + enemyAiScript.enemyHealth);       //this was used to see if the enemy script was being read properly as this script takes a lot of information from that script.
            BonusMultiplierDamageCheck();
        }
        
    }
    //something isnt working in the BonusMultiplierDamageCheck() isnt working for the plantmonster

    private void BonusMultiplierDamageCheck()
    {
        print("start BMD check");
        if (damageMultiplyType == enemyAiScript.weakness)   // checks the damage type form the sword and compares it to the ememies weeakness
        {                                                   // if it does have have same value it will deal more damage to the enemy
            print("bonus");                                 

            Debug.Log("strike weakness" + enemyAiScript.weakness);
            BonusDamage();
        }
        if (damageMultiplyType == enemyAiScript.resistance)     //similar to the weakness check, it checks the weapons or projectile damage type to the enemies resistance
        {                                                          // if they have same value deals less damage to enemy
            print("reduce");
            ReducedDamage();
        }
        else
            enemyAiScript.damageReceived = baseAttackDamage;
            enemyAiScript.FinalDamageCount();
    }
    protected void ReducedDamage()
    {
        damage = baseAttackDamage / damageMultiplier;               //divides the base damage by a certain amount
        Debug.Log("resist damage" + damage);
        enemyAiScript.damageReceived = damage;                      // then sends it to the enemy script to subtract from its health
        print(enemyAiScript.damageReceived);

        enemyAiScript.FinalDamageCount();
    }
    protected void BonusDamage()
    {
        damage = baseAttackDamage * damageMultiplier;               //multiplies the base damage by a set amount
        Debug.Log(damage + "damage amount");
        enemyAiScript.damageReceived = damage;                      // then send it to the enemy script to subtract from its health
        print(enemyAiScript.damageReceived);
        
        enemyAiScript.FinalDamageCount();
    }
}