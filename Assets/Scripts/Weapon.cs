using JetBrains.Annotations;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using Unity.Collections;
using Unity.Jobs;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;


public class Weapon : Items
{
    //[SerializeField] public DamageType damageMultiplyType = DamageType.Undefined;

    [SerializeField] GameObject weapon;

    [SerializeField] protected int coolDownDuration;
    

    [SerializeField] protected bool canAttack = true;
    [SerializeField] protected GameObject[] enemies;

    [SerializeField] protected EnemyAI enemyAiScript;

    private void Start()
    {
        weapon = this.gameObject;
        weapon.GetComponent<Collider>().enabled = false;

    }
    private void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("enemy");

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            weapon.GetComponent<BoxCollider>().enabled = true;
            AttackEnemy();
            canAttack = false;
            StartCoroutine(CoolDown());
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
        weapon.GetComponent<Collider>().enabled = false;

        yield break;
    }


    public virtual void AttackEnemy()
    {
        //this gets overridden depending on the weapon the player holds
    }

}