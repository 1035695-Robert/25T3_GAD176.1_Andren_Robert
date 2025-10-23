using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using SAE.GAD176.SlimeBall.Healing;
using JetBrains.Annotations;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using UnityEditor.Experimental.GraphView;
using System.Globalization;
using UnityEngine.InputSystem.Processors;

public class MeleeSlime : EnemyAI
{
    //  protected override DamageType weakness => DamageType.Fire;

    private float attackRange;
    private int attackPower;
    private SlimeBall slimeballScript;
    [SerializeField] private GameObject slimeDrops;
    [SerializeField] private float healthLow;
    [SerializeField] public float healAmount;
    [SerializeField] private float lowHealthMovement;
    //public bool oneTimeHealSlimeBall = false; 



    private void Awake()
    {

    }

    public override void AttackPlayer()
    {
        //this is where i would put the attack for the slime if player had a health script to call on
        // for this project itll only debug.log a message as it cant do damage to the player 
        Debug.Log("slimeAttack");
        //if in attackRange
        //attacks player 
    }
    public override void EnemyMove()
    {  // distance from player  detection 


        if (enemyHealth <= healthLow && isDead == false)  //does a base check to see if the enemy health is lower than set variable  the reason for having detect low health before the enemy as when it switches it need to have the priority so that it wont move towards player but itll move towards dropped items
        {
            LowHealthFlee();
        }
        else
        {
            if (distanceFromPlayer <= detectionDistance)
                // move player towards player
                TowardsPlayer();            //work from week 5 class content
        }
    }
    public void LowHealthFlee()
    {
        // Having the slime only heal once   
        //when low on health

        if (slimeDrops != null)
        {
            slimeDrops = GameObject.FindGameObjectWithTag("droppedItems");
            Debug.Log("found drop item"); // this part is working fine: 

        }
        if (slimeDrops == null)     //checks if the meleeSlime has no object detected this allow
        {
            TowardsPlayer(); 
            return;
        }
        else
            //seeks closest dropped Item
            //if gmaeobject is found for slimeball then do this:
            rigidBody.MovePosition(transform.position + (slimeDrops.transform.position - transform.position) * lowHealthMovement * Time.fixedDeltaTime); // moves towards the 
        //else return
    }

    private void TowardsPlayer()
    {
        rigidBody.MovePosition(transform.position + (player.transform.position - transform.position) * movementSpeed * Time.fixedDeltaTime); //since i had this statement twice in this script i moved it to its own function to compress the script. as it helps remove the repetitiveness.

    }


    private void OnTriggerEnter(Collider DroppedItem) //this originally use to be a OnCollisionEnter but until drop items were updated to be triggers for player to interact with i had to update this so that it would work as well
    {
        if (DroppedItem.gameObject.CompareTag("droppedItems") && enemyHealth <= healthLow)       
        {
          slimeballScript = DroppedItem.gameObject.GetComponent<SlimeBall>();                   //  
          Debug.Log("healing Amount: " + slimeballScript.healingAmount);                        //prints a message letting me know that it did heal the slime a set amount.     

            enemyHealth += slimeballScript.healingAmount;                                       // to access an varable from another script you have to specify the script as a variable before coding if you just call script in the code you only have access to the functions
            

                                                    //i originally have this if statement "if( enemyHealth <= maxEnemyHealth)" instead of >= this ment that everytime it healed back to full not a set amount. 
            if ( enemyHealth >= maxEnemyHealth)     // i need to pay more attention to if it is greater or lesser than as it can mess up the whole script if not written properly.
            {
                enemyHealth = maxEnemyHealth;       //this now works as intended: small error on my end as i had the wrong calculation.
            }
            //oneTimeHealSlimeBall = true;      //this bool is no longer used as i had some issues with the enemy constantly trying to seek gameobjects and broke the game, but this is kept here as if i wanted to have the enemy can only heal once. this would be added in movment function for checking health in the if statement
            Destroy(DroppedItem.gameObject);        // needed to destroy the gameobject as if i didnt it would constantly heal the slime when it touched the dropped item
        }
    }
}

