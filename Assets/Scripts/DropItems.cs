using SAE.GAD176.SlimeBall.Healing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Editor;

public enum DropList
{
    Undefined,
    None,
    SlimeBall,
    PlantSeed,
}
public class DropItems : MonoBehaviour
{
   private GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider playerDetect)
    {
        if (playerDetect.gameObject.CompareTag("Player")) // similarly to when enemy is hit with projectile or weapon, this trigger can only be accessed by an object with a player tag.
        {
            Debug.Log("pickup");
            Destroy(this.gameObject); //since i didnt have an actual inventory i never had a way to store these items. i was  going to have ammo/seed value incease but it would of caused alot more time to create another script for such thing.
            //allow the player to pick up an item
            

            //this may cause issues with projectiles as when fired they would still have the same properties as a normal drop item.
            //adding a bool that could be updated from the shoot script could change its value.
        }
    }
    
}
