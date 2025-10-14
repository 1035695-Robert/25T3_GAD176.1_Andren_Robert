using Unity.Collections;
using UnityEngine;

public class Weapon : Items
{
    private string[] attackType = {"blunt", "range", "slash", "fire" };
    private int damage;
    private float coolDownDuration;
    private bool canAttack = true;


    private void Attack()
    {  
      //if can attack is true
        //attacks enemy if colision hits
        //canAttack = false
        //NextAttack();
        
    }
    private void NextAttack()
    {
        //override cooldown durtation time

        //wait set duration time till next attack
    }
}
