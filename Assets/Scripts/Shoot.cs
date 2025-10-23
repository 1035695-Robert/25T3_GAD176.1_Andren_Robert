using System.Runtime.CompilerServices;
using System.Transactions;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private float projectileTime;
    [SerializeField] public GameObject seedsAmmo;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float projectileVelocity;
    [SerializeField] private float timeAfterShot;

    [SerializeField] public GameObject plantSeed;
    [SerializeField] public GameObject fireSeed;
    [SerializeField] public ProjectilePrefabTypes seedName = ProjectilePrefabTypes.None;


    public void SetSeedType()
    { 
        switch (seedName)
        {
            case ProjectilePrefabTypes.None:   
                {
                    Debug.Log("not set seed");
                    break; 
                }
            case ProjectilePrefabTypes.PlantSeed:
                {
                    Debug.Log("plantseed shoot");

                   seedsAmmo = plantSeed;
                    ShootProjectile();

                    break;
                }
            case ProjectilePrefabTypes.FireSeed:
                {
                    Debug.Log("fire Seed shoot ");

                    seedsAmmo = fireSeed;
                    ShootProjectile();

                    break;
                }
        }
    }
    private void ShootProjectile()
    { 

   
         GameObject seedObject = Instantiate(seedsAmmo, spawnPoint.transform.position, transform.rotation) as GameObject; 
       
        seedObject.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, projectileVelocity)); //this allows the seed/ammo to be propelled forward.
          
       Destroy(seedObject, timeAfterShot); //if the gameobject isnt already destroyed from on trigger in the projectiles script it will destory them here after a set amount of time
    }

 
}
