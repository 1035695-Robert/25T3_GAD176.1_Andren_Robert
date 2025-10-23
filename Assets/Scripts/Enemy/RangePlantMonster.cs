using System.Collections;
using UnityEngine;
using SAE.GAD176.Shoot;
using Unity.VisualScripting;
using NUnit.Framework.Constraints;
public class RangePlantMonster : EnemyAI
{
    protected GameObject ammo;
    [SerializeField] private float fleeingDistance;
    [SerializeField] private float fleeingSpeed;
    [SerializeField] private float safeDistance;

  
    //[SerializeField] private Projectile projectile;

    [SerializeField] private Shoot shootScript;
    [SerializeField] private DamageMultiplier damageMultiplierScript;
    public override void EnemyMove()
    {
        if (distanceFromPlayer <= detectionDistance && distanceFromPlayer > attackDistance) //if enemy is in range of player move closer
        {
            // move player towards player
            rigidBody.MovePosition(transform.position + (player.transform.position - transform.position) * movementSpeed * Time.fixedDeltaTime);
            //work from week 5 class content
        }
        if (distanceFromPlayer < fleeingDistance)       //detects if the player is too close to it, 
        {
            StartCoroutine(RunAway());                  //starting a coroutine to make the enemy flee. this occasionally has some issues where the game object clips through walls since it moves in a set determined direction.
        }
    }

    private IEnumerator RunAway()
    {
        while (distanceFromPlayer < safeDistance)       //while it continues to move away it checks if its now at a safe distance
        {
            rigidBody.MovePosition(transform.position - (player.transform.position - transform.position) * fleeingSpeed * Time.fixedDeltaTime);
            yield return null;
        }
        yield break;

    }


    public override void AttackPlayer()
    {
        shootScript = gameObject.GetComponent<Shoot>();
        
        shootScript.SetSeedType();
    }
  
}

        //projectile.Shoot();
        //if plant is in range of player

        //instantiate selected projectile ammunition type in intervals

    
