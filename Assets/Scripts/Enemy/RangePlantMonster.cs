using UnityEngine;

public class RangePlantMonster : EnemyAI
{
    private string projectile;


    private void RunAway()
    {
        //opposite of move towards in the enemyAI script

        //if player is in set range 
        //moves out of range




    }
    private void Shoot()
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
        public override void SetWeakness()
        {
            DamageType weakness1 = DamageType.Blunt;
            DamageType weakness2 = DamageType.None;

            base.SetWeakness();
        }

    }
}*/
