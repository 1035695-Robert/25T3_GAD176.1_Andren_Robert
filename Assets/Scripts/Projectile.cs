using Unity.Collections;
using UnityEngine;
using SAE.GAD176.SlingShot;

public class Projectile : Items
{

    protected int damage;
    protected int maxAmount;
    public float projectileVelocity;

    public void velocityPower(Slingshot slingshot)
    {
        projectileVelocity = slingshot.firePower;
        Debug.Log("projectileVelocity: " + projectileVelocity);
    }


    private void OnImpact()
    {
        //if projectile makes contact with TARGET (enemy or player) it deals damage.
    }
    public virtual void DamageSet()
    {
        damage = 0;
    }
    public virtual void AmmunitionAmoutSet()
    {
        maxAmount = 0;
    }
}
