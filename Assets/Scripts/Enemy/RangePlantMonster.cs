using UnityEngine;

public class RangePlantMonster : EnemyAI
{
    private string projectile;
   [SerializeField] private float fleeingDistance;
    [SerializeField] private float fleeingSpeed;
    [SerializeField]private float shootRange;
    [SerializeField] private float safeDistance;

    private void Update()
    {
        if (distanceFromPlayer > fleeingDistance)
        {
            RunAway();
        }

        if (shootRange == safeDistance)
        {
            

        }
    }
    private void RunAway()
    {

        rigidBody.MovePosition(transform.position - (player.transform.position - transform.position) * fleeingSpeed * Time.fixedDeltaTime);
        

    }

    public void Shoot()
    {
      
        //if plant is in range of player
        //instantiate selected projectile ammunition type in intervals

    } 
}
/*namespace SAE.GAD176.damageMultiplier.RangePlant
{
    public class RangePlantMonster : EnemyAI
    {

        public override void SetResistance()
        {
            DamageType resistance1 = DamageType.Slash;
            DamageType resistance2 = DamageType.None;
            base.SetResistance();
        }
        public override vo

            DamageType weakness1 = DamageType.Blunt;
            DamageType weakness2 = DamageType.None;

            base.SetWeakness();
        }

    }
}*/
