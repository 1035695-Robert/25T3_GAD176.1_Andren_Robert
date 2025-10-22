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
        if (playerDetect.gameObject.CompareTag("Player"))
        {
            Debug.Log("pickup");
            Destroy(this.gameObject);
            //allow the player to pick up an item
            

            //this may cause issues with projectiles as when fired they would still have the same properties as a normal drop item.
            //adding a bool that could be updated from the shoot script could change its value.
        }
    }
    
}
