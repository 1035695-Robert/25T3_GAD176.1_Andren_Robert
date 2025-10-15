using System.Collections;
using Unity.Collections;
using UnityEngine;

public class Weapon : Items
{
    public enum Damagetype
    {
        None,
        Slash,
        Blunt,
        Fire,
    }

    private int coolDownDuration;
    protected bool canAttack = true;

  
       protected void NextAttack()
    {
        if (canAttack == false)
        {
            StartCoroutine(CoolDown());
        }
        //override cooldown durtation time

        //wait set duration time till next attack
    }
    IEnumerator CoolDown()
    {
         float coolDownTime = coolDownDuration;
        while (coolDownTime > 0)
        {
            coolDownTime -= Time.deltaTime;
            yield return null;
        }
        canAttack = true;
        yield break;
    }
}
