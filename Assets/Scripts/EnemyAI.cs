using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEditor;
using UnityEngine;
//using SAE.GAD176.damageMultiplier.MeleeSlime;
//using SAE.GAD176.damageMultiplier.RangePlant;


public class EnemyAI : MonoBehaviour
{
    public GameObject[] enemyType;

    private Vector3 spawn;
    //[SerializeField] string[] weakness; AG commented out in preparation of using an ENUM instead
    // [SerializeField] string[] ;
    private bool isDead = false;
    [SerializeField] protected int EnemyHealth;


   // private string[] dropItem;
    protected Rigidbody rigidBody;
    [SerializeField] protected Transform player;

    [SerializeField] protected float distanceFromPlayer;
    [SerializeField] protected float detectionDistance;
    [SerializeField] protected float attackDistance;

    [SerializeField] protected float movementSpeed = 2f;
    [SerializeField] private string enemyName;

    [SerializeField] public DamageType weakness = DamageType.Undefined;
    [SerializeField] public DamageType resistance = DamageType.Undefined;
    //[SerializeField] private Weapon weaponScript;
    //[SerializeField] private Projectile projectileScript;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        // SetResistance();
        //  SetWeakness();
    }
    public virtual void Update()
    {
        //detection tutorial video by Online Code Coaching "enemy Agro - attack player when too close
        //set range detection
        distanceFromPlayer = Vector3.Distance(player.position, transform.position);
        //detects if player is in range
        if (distanceFromPlayer <= detectionDistance)
        {
            EnemyMove();
        }
        if (distanceFromPlayer <= attackDistance)
        {
            AttackPlayer();
        }

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
        Debug.Log("did nothing"); //if it displayed this log something went wrong thankfully the override method worked wonders.
        //this function gets overridden by the specified child class for the enemy type. 
        //since each enemy has a different type of attack method (range or melee)
    }
    private void TakeDamage()
    {


        //enemy health -= Weapon.BaseDamage 

        // healthAmount =- weapondamage
        EnemyKilled();
    }
    private void EnemyKilled()
    {
        //checks if health is 0 or below
        if (EnemyHealth > 0)
        {
            //if below 0 set isDead to true.
            isDead = true;
            //dropItem();
            DropItems();
        }

    }
    private void DropItems()
    {
        //drops item on death
        //override item type based on enemy type
    }
}
