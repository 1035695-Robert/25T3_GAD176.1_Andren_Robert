using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using SAE.GAD176.Shoot;



    public class Slingshot : Weapon
    {
        public float firePower;
        private int maxFirePower = 6;
        [SerializeField] private ProjectileType seedType = ProjectileType.Undefine;


        private void DrawBack()
        {

            if (canAttack == true)
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
                    
                    Shoot();
                }
            }
        }
        private void Shoot()
        {
           // Instantiate(Vector3(0, 0, 0), Quaternion.identity);

            //fires projectile
            //starts cooldown in weapons class
            //Instantiate projectile seed
            
       
        }
    }



