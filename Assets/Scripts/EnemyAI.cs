using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEditor;
using UnityEngine;
//using SAE.GAD176.damageMultiplier.MeleeSlime;
//using SAE.GAD176.damageMultiplier.RangePlant;


public class EnemyAI : MonoBehaviour

{
   
    public enum DamageType
    {
        None,
        Fire,
        Blunt,
        Slash,
    }

    public GameObject[] enemyType;

    private string enemyName;
    private Vector3 spawn;

    private GameObject player;
    private bool isDead = false;
    protected int healthAmount;

    private float range;



    private void Start()
    {
     player = GameObject.FindGameObjectWithTag("player");
    }
    private void Update()
    {
        //set range detection

        //detects if player is in range
        if ()// enemy detects player in range
            MoveTowards)();
    }

    private void SpawnEnemy()
    {
        //spawn enemy at random vector3 postition
       
    }
    private void MoveTowards()
    {
        
        // move player towards player
       // Rigidbody.
    }

    private void TakeDamage()
    {
        //check what type of damage
        /// 

        // healthAmount =- weapondamage
        EnemyKilled();
    }
   private void EnemyKilled()
    { 
        //checks if health is 0 or below
        //if below 0 set isDead to true.
        //dropItem();
        if (healthAmount > 0) 
        {
            isDead = true;
            DropItems();
        }
     
    }
    private void DropItems()
    { 
        //drops item on death
        //override item type based on enemy type
    }
    public virtual void SetWeakness()
    {
    //override weakness types
    }
    public virtual void SetResistance()
    {
        //DamageType resistance1 = DamageType.None;

        //DamageType resistance2 = DamageType.Fire;

        //override ristance type
    }
}
