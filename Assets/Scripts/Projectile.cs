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
    public class Projectile : DropItems
    {
        private void OnTriggerEnter(Collider other)
        {
           
                Destroy(this.gameObject);
            
        }
    }


}
   
