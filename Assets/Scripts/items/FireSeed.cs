using UnityEngine;

public class FireSeed : Projectile
{
    private float BurnDuration;


    public override void DamageSet()
    {
        damage = 2;
        base.DamageSet();
    }

   

    void Burn()
    {

        //adds burn damage duration
        //takes damage in intivals over burnduration period
    }

}
