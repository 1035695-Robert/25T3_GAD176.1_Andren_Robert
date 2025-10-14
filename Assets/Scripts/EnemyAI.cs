using System.Runtime.CompilerServices;
using Unity.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private string enemyName;
    private Vector3 spawn;
    private string weakness;
    private string resistance;
    private bool isDead = false;
    private int healthAmount;

    
    private void MoveTowards()
    {
        //set range detection
        //detects if player is in range
        // move player towards player
    }
    private void SpawnEnemy()
    {
        //spawn enemy at set vector3 postition
    }
   private void EnemyKill()
    {
      //checks if health is 0 or below
      //if below 0 set isDead to true.
      //dropItem();
    }
    private void DropItems()
    {
        //drops item on death
        //override item type based on enemy type
    }
    private void SetWeakness()
    {
        //override weakness type
    }
    private void SetResistance()
    {
        //override ristance type
    }
}
