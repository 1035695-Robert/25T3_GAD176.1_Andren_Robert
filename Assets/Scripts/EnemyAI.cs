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
        rigidBody = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyHealth = maxEnemyHealth;
         

    }
    private void Update()
    {
        //detection tutorial video by Online Code Coaching "enemy Agro - attack player when too close
        //set range detection
        distanceFromPlayer = Vector3.Distance(player.position, transform.position);
        //detects if player is in range
        if (distanceFromPlayer <= detectionDistance)
        {
            rigidBody.transform.LookAt(new Vector3 (player.position.x, transform.position.y, player.position.z));
            EnemyMove();
        }
        if (distanceFromPlayer <= attackDistance && checkAttack == true)
        {
            checkAttack = false;

            StartCoroutine(NextAttack());
        }
        

    }
    IEnumerator NextAttack()
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
    static void Main(string[] enemytype)
    {
        RangePlantMonster plant = new RangePlantMonster();
        MeleeSlime slime = new MeleeSlime();

        plant.AttackPlayer();
        slime.AttackPlayer();

        plant.EnemyMove();
        slime.EnemyMove();
    }


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
        enemyHealth -= damageReceived;
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
                case DropList.SlimeBall:
                {
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
