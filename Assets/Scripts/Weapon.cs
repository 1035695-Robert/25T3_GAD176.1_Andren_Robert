using System.Collections;
using Unity.Collections;
using Unity.Jobs;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class Weapon : Items
{
    [SerializeField] protected DamageType damageMultiplyType = DamageType.Undefined;


    [SerializeField] protected int coolDownDuration;
    [SerializeField] private float baseAttackDamage;
    [SerializeField] private float damageMultiplier = 1.5f;
    [SerializeField] public float damage;

    [SerializeField] protected bool canAttack = true;
    [SerializeField] protected GameObject[] enemies;
   
    [SerializeField] protected EnemyAI enemyAiScript;

    private void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("enemy");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            AttackEnemy();

            canAttack = false;
            StartCoroutine(CoolDown());
        } 
    IEnumerator CoolDown()
    {
        float coolDownTime = coolDownDuration;
        while (coolDownTime > 0)
        {
            coolDownTime -= Time.deltaTime;
            yield return null;
        }
        canAttack = true;
        yield break;
    }
    }
    protected void BonusMultiplierDamageCheck()
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

   
    public virtual void AttackEnemy()
    {
        //this gets overridden depending on the weapon the player holds
    }


    protected void ReducedDamage()
    {
      damage = baseAttackDamage/damageMultiplier;
        Debug.Log("resist damage" + damage);
        enemyAiScript.FinalDamageCount();

    }
    protected void BonusDamage()
    {
       damage = baseAttackDamage * damageMultiplier;
        Debug.Log("bonus damage" + damage);
        enemyAiScript.FinalDamageCount();
    }
}