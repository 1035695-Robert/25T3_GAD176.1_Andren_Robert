using Unity.Collections;
using UnityEngine;

    public enum ProjectileType 
    {
        Undefine,
        None,
        plantSeed,
        FireSeed,
    }
namespace SAE.GAD176.Shoot
{
    public class Projectile : MonoBehaviour
    {

        protected int damage;
        protected int maxAmount;
        public float projectileVelocity;
        public Vector3 attackPoint;
        [SerializeField] private ProjectileType SeedName = ProjectileType.Undefine;


       // private ProjectileType seedtype = ProjectileType.undefined;

        /* public void velocityPower(Slingshot slingshot)
         {
             projectileVelocity = slingshot.firePower;
             Debug.Log("projectileVelocity: " + projectileVelocity);
         }*/

        public virtual void ShootProjectile()
        {
           
        }

        private void OnCollisionEnter(Collision hitTarget)
        {

            //if projectile makes contact with TARGET (enemy or player) it deals damage.
        }
        public virtual void DamageSet()
        {
            damage = 0;
        }
        public virtual void AmmunitionAmountStack()
        {
            maxAmount = 0;
        }
    private void Shoot()
        {
           /// 
           /// readyToShoot = false
           /// bulletsLeft--;
           /// bulletsShot++;
        }
    }

}
