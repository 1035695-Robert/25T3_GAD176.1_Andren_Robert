using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using SAE.GAD176.Shoot;



public class Slingshot : Weapon
{
    public float firePower;
    private int maxFirePower = 6;
    public Vector3 attackPoint; // midpoint is vector3(0.5,0.5,0.5)
    [SerializeField] public ProjectilePrefabTypes seedType = ProjectilePrefabTypes.Undefine;
    Projectile projectileScript;

    public override void AttackEnemy()
    {
        //do some stuff
        PewPew();
    }

    private void PewPew()
    {
        projectileScript.seedName = seedType;
        projectileScript.Shoot();
    }
}
    /* if (canAttack == true)
         {
             firePower = 0;


             while (Input.GetKey(KeyCode.Space))
             {
                 firePower = +Time.deltaTime;
                 if (firePower >= maxFirePower)
                 {
                     firePower = maxFirePower;
                 }
             }
             if (Input.GetKeyUp(KeyCode.Space))
             {
                 canAttack = false;
                 */

        /*
        private void Shoot()
        {
           // Instantiate(Vector3(0, 0, 0), Quaternion.identity);

            //fires projectile
            //starts cooldown in weapons class
            //Instantiate projectile seed
            
       
        }*/



