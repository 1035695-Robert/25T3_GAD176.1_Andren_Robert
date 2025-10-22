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
        if (attackHit.gameObject.CompareTag("enemy"))
        {

           enemyAiScript = attackHit.gameObject.GetComponent<EnemyAI>();

            Debug.Log("enemy health test: " + enemyAiScript.enemyHealth);
            BonusMultiplierDamageCheck();
        }
        
    }
    //something isnt working in the BonusMultiplierDamageCheck() isnt working for the plantmonster

    public void BonusMultiplierDamageCheck()
    {
        print("start BMD check");
        if (damageMultiplyType == enemyAiScript.weakness)
        {
            print("bonus");

            Debug.Log("strike weakness" + enemyAiScript.weakness);
            BonusDamage();
        }
        if (damageMultiplyType == enemyAiScript.resistance)
        {
            print("reduce");
            ReducedDamage();
        }
        else
            enemyAiScript.damageReceived = baseAttackDamage;
            enemyAiScript.FinalDamageCount();
    }
    protected void ReducedDamage()
    {
        damage = baseAttackDamage / damageMultiplier;
        Debug.Log("resist damage" + damage);
        enemyAiScript.damageReceived = damage;
        print(enemyAiScript.damageReceived);

        enemyAiScript.FinalDamageCount();
    }
    protected void BonusDamage()
    {
        damage = baseAttackDamage * damageMultiplier;
        Debug.Log(damage + "damage amount");
        enemyAiScript.damageReceived = damage;
        print(enemyAiScript.damageReceived);
        
        Debug.Log(enemyAiScript.damageReceived + "damageRecieved");
        Debug.Log("bonus damage" + damage);
        enemyAiScript.FinalDamageCount();
    }
}