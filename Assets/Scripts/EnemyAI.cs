using System.Collections;
using System.Runtime.CompilerServices;
using System.Threading;
using Unity.Collections;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEditor;
using UnityEngine;


public class EnemyAI : MonoBehaviour
{
    public GameObject[] enemyType;

    private Vector3 spawn;
    //[SerializeField] string[] weakness; AG commented out in preparation of using an ENUM instead
    // [SerializeField] string[] ;
   [SerializeField] protected bool isDead = false;

    [SerializeField] protected float maxEnemyHealth;
    [SerializeField] public float enemyHealth;


    // private string[] dropItem;
    protected Rigidbody rigidBody;
    [SerializeField] protected Transform player;

    [SerializeField] protected float distanceFromPlayer;
    [SerializeField] protected float detectionDistance;
    [SerializeField] protected float attackDistance;

    
    [SerializeField] protected float movementSpeed;
    [SerializeField] private string enemyName;
    [SerializeField] protected float coolDownTime;
    [SerializeField] protected bool checkAttack = true;

    [SerializeField] public DamageType weakness = DamageType.Undefined;
    [SerializeField] public DamageType resistance = DamageType.Undefined;

    [SerializeField] public float damageReceived;

    [SerializeField] protected DropList itemList;
    [SerializeField] private GameObject slimeball;
    [SerializeField] private GameObject plantseed;

    [SerializeField] protected DamageMultiplier damageScript;

    //[SerializeField] private Projectile projectileScript;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();                              //finds the game objects rigidbody allowing this script to move the enemy around 
        player = GameObject.FindGameObjectWithTag("Player").transform;     // this locates the player as it ends up helping the enemies to be able to know where the player is
        enemyHealth = maxEnemyHealth;
         

    }
    private void Update()
    {
        //detection tutorial video by Online Code Coaching "enemy Agro - attack player when too close
        //set range detection
        distanceFromPlayer = Vector3.Distance(player.position, transform.position);                 //here it sets a vector of were the player position is and allows the enemy to know how far away the player is from an enemy
        //detects if player is in range
        if (distanceFromPlayer <= detectionDistance)
        {
            rigidBody.transform.LookAt(new Vector3 (player.position.x, transform.position.y, player.position.z)); //LookAt uses rotations to rotate the enemies towards the player
            EnemyMove();
        }
        if (distanceFromPlayer <= attackDistance && checkAttack == true)  // detects when player is close in set range and will do its attack action 
        {
            checkAttack = false;                                         // waits till enemy cooldown has eneded
            StartCoroutine(NextAttack());                                  //starts the nextattack cooldown when that ends it will be able to attack again
        }
        

    }
    IEnumerator NextAttack() //similar idea for the weapon attack 
        //this could of been put into its own script that weapons and enemies used reducing the repeativeness of the coding.
    {
        AttackPlayer();
        
        float waitTime = coolDownTime;
        while (waitTime > 0)
        {
            waitTime -= Time.deltaTime;
            yield return null;
        }
        checkAttack = true;
        yield break;
    }

    // this was never implemented as i didnt have enough time but im leaving it here showing it was in plans but was a stretch goal.
    private void SpawnEnemy() 
    {
        //spawn enemy at random vector3 postition

    }
    public virtual void EnemyMove()
    {
        //this function gets overridden depending which enemy it applies to (eg. plantMonster or the Slime)
    }



    public virtual void AttackPlayer()
    {
        Debug.Log("did nothing");   //if it displayed this log something went wrong thankfully the override method worked wonders.
                                    //this function gets overridden by the specified child class for the enemy type. 
                                    //since each enemy has a different type of attack method (range or melee)
    }

    public void FinalDamageCount()
    {
        
       
        Debug.Log(damageReceived + " hit damage" + this.gameObject.name);
        enemyHealth -= damageReceived; //is is were the damage is provided after it runs through the damageMultiplier script. 
        //had some issue with the value being sent across since i was originally trying to get the value from this script it wasnt working so i sent it from the other script and it seems to work fine now.
        Debug.Log(enemyHealth + " hp LEFT");
        if(enemyHealth <= 0)
        {
            EnemyKilled();
        }
    }

    private void EnemyKilled()
    {
        //checks if health is 0 or below
           
            isDead = true;
            //drops items
            DropItems();           
        Destroy(this.gameObject);
    }
   
    private void DropItems()
    {
       switch(itemList)
        {
                case DropList.None:
                {
                    break;
                }
                case DropList.SlimeBall:        //if the selected item from the enum is one of these it will drop that corrosponding item.
                {                               //if slimeball was selected then it will Instantiate a slimeball same with the plantseed. 
                    Debug.Log("slimeball"); 
                    Instantiate(slimeball, transform.position, Quaternion.identity); 

                    break;
                }
                case DropList.PlantSeed:       
                {
                    Instantiate(plantseed, transform.position, Quaternion.identity);
                    break;
                }

        }
       
        //drops item on death
        //override item type based on enemy type
    }
}
