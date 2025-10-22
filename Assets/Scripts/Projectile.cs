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

        private void OnTriggerEnter(Collider hitEnemy)
        {
            if (hitEnemy.gameObject.CompareTag("enemy"))
            {
                Destroy(this.gameObject);
            }
        }
    }


}
   
