using System.Collections;
using System.Diagnostics.CodeAnalysis;
using Unity.Collections;
using UnityEngine;

    public enum ProjectilePrefabTypes 
    {
        None,
        PlantSeed,
        FireSeed,
    }
namespace SAE.GAD176.Shoot
{
    public class Projectile : MonoBehaviour
    {

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

        /*private void OnCollisionEnter(Collision hitTarget)
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


    }*/
    }
}
