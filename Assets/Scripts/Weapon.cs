using System.Collections;
using Unity.Collections;
using Unity.Jobs;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class Weapon : Items
{
    [SerializeField] protected DamageType damageMultiplyType = DamageType.Undefined;


    private int coolDownDuration;
    private float baseAttackDamage;
    private float damageMultiplier = 1.5f;
    private float damage;

    protected bool canAttack = true;
    private EnemyAI enemyAiScript;

    private void Start()
    {
       
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // preforms attack action

            canAttack = false;
            StartCoroutine(CoolDown());
        }
    }
    private void OnCollisionEnter(Collision attackHit)
    {
        if (damageMultiplyType == enemyAiScript.weakness)
        {
            BonusDamage();
        }
        if (damageMultiplyType == enemyAiScript.resistance)
        {
            ReducedDamage();
        }
        
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
    private void ReducedDamage()
    {
      damage = baseAttackDamage/damageMultiplier;
    }
    private void BonusDamage()
    {
       damage = baseAttackDamage * damageMultiplier;
    }
}