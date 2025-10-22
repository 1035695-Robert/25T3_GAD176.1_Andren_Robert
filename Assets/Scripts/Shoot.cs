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


  
    private void Awake()
    {
       
    }

    private void Start()
    {
       
    }


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
       
        seedObject.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, projectileVelocity));
          
       Destroy(seedObject, timeAfterShot);
    }

 
}
