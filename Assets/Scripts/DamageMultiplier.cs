using UnityEngine;

public class DamageMultiplier : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   
    [SerializeField] private float baseAttackDamage;
    private float damageMultiplier = 1.5f;
    public float damage;
     private DamageType damageMultiplyType;

    protected EnemyAI enemyAiScript;
    [SerializeField] protected GameObject[] enemylist;

    private void OnTriggerEnter(Collider attackHit)
    {
        if (attackHit.gameObject.CompareTag("enemy"))
        {
            enemyAiScript = attackHit.gameObject.GetComponent<EnemyAI>();
            BonusMultiplierDamageCheck();
        }
        
    }


    public void BonusMultiplierDamageCheck()
    {
        if (damageMultiplyType == enemyAiScript.weakness)
        {
            Debug.Log("strike weakness" + enemyAiScript.weakness);
            BonusDamage();
        }
        if (damageMultiplyType == enemyAiScript.resistance)
        {
            Debug.Log("strike Risistance" + enemyAiScript.resistance);

            ReducedDamage();
        }
        else
            enemyAiScript.FinalDamageCount();
    }
    protected void ReducedDamage()
    {
        damage = baseAttackDamage / damageMultiplier;
        Debug.Log("resist damage" + damage);
        enemyAiScript.FinalDamageCount();

    }
    protected void BonusDamage()
    {
        damage = baseAttackDamage * damageMultiplier;
        enemyAiScript.damageReceived = damage;
        Debug.Log(enemyAiScript.damageReceived + "damageRecieved");
        Debug.Log("bonus damage" + damage);
        enemyAiScript.FinalDamageCount();
    }
}