using System.Collections;
using System.Diagnostics.CodeAnalysis;
using Unity.Collections;
using UnityEngine;

    public enum ProjectilePrefabTypes 
    {
        Undefine,
        None,
        PlantSeed,
        FireSeed,
    }
namespace SAE.GAD176.Shoot
{
    public class Projectile : MonoBehaviour
    {

        [SerializeField] private EnemyAI enemyAIScript;
        [SerializeField] public ProjectilePrefabTypes seedName = ProjectilePrefabTypes.Undefine;
        [SerializeField] private DamageType seedDamageType = DamageType.Undefined;

        [SerializeField] private float timer;
        private float projectileTime;
        public GameObject seedsAmmo;
        public Transform spawnPoint;
        public float usersSpeed;
        public float timeAfterShot;

        protected float baseSeedDamage;
        protected float damage;
        protected float damageMultiplier;
        protected int maxAmount;
        public float projectileVelocity;

        // private ProjectileType seedtype = ProjectileType.undefined;

        /* public void velocityPower(Slingshot slingshot)
         {
             projectileVelocity = slingshot.firePower;
             Debug.Log("projectileVelocity: " + projectileVelocity);
         }*/
        protected void SetSeedType()
        { // changes based on what is selected
            /*switch (seedName)
              { 
                  case ProjectilePrefabTypes.Undefine:
                      {
                          return;
                      }
                  case ProjectilePrefabTypes.None:
                      {
                          Debug.Log("no seed Ammo");
                          return;
                      }

                  case ProjectilePrefabTypes.PlantSeed:
                      {
                          Instantiate(seedsAmmo[3]);
                          break;
                      }
                  case ProjectilePrefabTypes.FireSeed:
                      {
                          Instantiate(seedsAmmo[4]);
                          break;
                      }
              }*/
        }

        public void Shoot()
        {
            projectileTime -= Time.deltaTime;

            if (projectileTime > 0) return;

            projectileTime = timer;
            GameObject seedObject = Instantiate(seedsAmmo, transform.position, spawnPoint.transform.rotation) as GameObject;
            Rigidbody seedRigidbody = seedObject.GetComponent<Rigidbody>();
            seedRigidbody.AddForce(transform.forward * usersSpeed);
            Destroy(seedObject, timeAfterShot);
        }

        private void OnCollisionEnter(Collision hitTarget)
        {
            //if projectile makes contact with TARGET (enemy or player) it deals damage.
            if (seedDamageType == enemyAIScript.weakness)
            {
                BonusSeedDamage();
            }
            if (seedDamageType == enemyAIScript.resistance)
            {
                ReducedSeedDamage();
            }


        }
        private void ReducedSeedDamage()
        {
            damage = baseSeedDamage / damageMultiplier;
        }
        private void BonusSeedDamage()
        {
            damage = baseSeedDamage * damageMultiplier;
        }


    }
}
