using System.Collections;
using UnityEngine;
using SAE.GAD176.Shoot;
using Unity.VisualScripting;
public class RangePlantMonster : EnemyAI
{
    protected GameObject ammo;
    [SerializeField] private float fleeingDistance;
    [SerializeField] private float fleeingSpeed;
    [SerializeField] private float safeDistance;

  
    //[SerializeField] private Projectile projectile;
    [SerializeField] public ProjectilePrefabTypes ammotype = ProjectilePrefabTypes.PlantSeed;
    [SerializeField] private Projectile projectile;

    public override void EnemyMove()
    {
        if (distanceFromPlayer <= detectionDistance && distanceFromPlayer > attackDistance)
        {
            // move player towards player
            rigidBody.MovePosition(transform.position + (player.transform.position - transform.position) * movementSpeed * Time.fixedDeltaTime);
            //work from week 5 class content
        }
        if (distanceFromPlayer < fleeingDistance)
        {
            StartCoroutine(RunAway());
        }
    }

    private IEnumerator RunAway()
    {
        while (distanceFromPlayer < safeDistance)
        {
            rigidBody.MovePosition(transform.position - (player.transform.position - transform.position) * fleeingSpeed * Time.fixedDeltaTime);
            yield return null;
        }
        yield break;

    }


    public override void AttackPlayer()
    {
        if(projectile != null)
        {
           projectile =  projectile.GetComponent<Projectile>();
        }
       projectile.Shoot();
        //Debug.Log("pew");
    }
  
}

        //projectile.Shoot();
        //if plant is in range of player

        //instantiate selected projectile ammunition type in intervals

    
