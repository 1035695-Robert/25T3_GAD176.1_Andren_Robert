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
    protected int healthAmount;

    private string[] dropItem;

    protected Rigidbody rigidBody;
    [SerializeField] protected Transform player;
    
   protected float distanceFromPlayer;
   [SerializeField] private float detectionDistance;
    private float attackDistance;
   
    [SerializeField] private float movementSpeed = 2f;
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
    private void Update()
    {
        //detection tutorial video by Online Code Coaching "enemy Agro - attack player when too close
        //set range detection
        distanceFromPlayer = Vector3.Distance(player.position, transform.position);
        //detects if player is in range
        if(distanceFromPlayer <= detectionDistance) 
        {
            MoveTowards();
        }
       // enemy detects player in range
       
    }
   

    private void SpawnEnemy()
    {
        //spawn enemy at random vector3 postition
       
    }
    private void MoveTowards()
    {
        // move player towards player
        rigidBody.MovePosition(transform.position + (player.transform.position - transform.position) * movementSpeed * Time.fixedDeltaTime);
        //work from week 5 class content
    }

    private void TakeDamage()
    {

        //check what type of damage
        

        // healthAmount =- weapondamage
        EnemyKilled();
    }
   private void EnemyKilled()
    { 
        //checks if health is 0 or below
        if (healthAmount > 0) 
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
