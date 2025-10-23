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

    [SerializeField] protected float coolDownDuration;
    

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
        enemies = GameObject.FindGameObjectsWithTag("enemy");   //finds all thegameobjects with the tag enemy.

        if (Input.GetKeyDown(KeyCode.Mouse0) && canAttack == true)  //            
        {
            weapon.GetComponent<BoxCollider>().enabled = true;      //having the box collider turn off mainly for the sword this means if an enemy runs up against you it wont take damge until you actually attack.
            AttackEnemy();                                          // calls the attack functions
            canAttack = false;                                       //can attack helps set a switch on or off for when the player can attack next.
            StartCoroutine(CoolDown());
        }
    }
    IEnumerator CoolDown()                              // having a Coroutine run as a cooldown between attacks. 
    {
        float coolDownTime = coolDownDuration;      
        while (coolDownTime > 0)
        {
            coolDownTime -= Time.deltaTime;
            yield return null;
        }
        canAttack = true;
        weapon.GetComponent<Collider>().enabled = false;    //this helps us disable the weapons collision so it doenst deal damage outside attacking.

        yield break;
    }


    public virtual void AttackEnemy()
    {
        //this gets overridden depending on the weapon the player holds
    }

}