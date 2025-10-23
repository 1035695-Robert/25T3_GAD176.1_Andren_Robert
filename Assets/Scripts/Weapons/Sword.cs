using JetBrains.Annotations;
using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;



public class Sword : Weapon
{
   // [SerializeField] private int attackPower;
   
    [SerializeField] private GameObject swordRotationOigin;
    [SerializeField] float swingSword;
    [SerializeField] DamageMultiplier damageScript;

   
    public override void AttackEnemy()

    {  //attacks enemy if colision hits
        if (canAttack == true)
        {
            StartCoroutine(SwordSwing()); 
        }
    }
    public IEnumerator SwordSwing()
    {
        float attackTimer = coolDownDuration;
        //transform: can edit interface transform X,Y,Z were as vector3 can only effects position
        swordRotationOigin.transform.localRotation = Quaternion.Euler(90f, 0, 0);  //localRotation effects the rotation of the object it is attached to on the (X,Y,Z) axis.

        while (attackTimer >= 0)
        {
            attackTimer -= Time.deltaTime;
            //Gizmos.color = Color.red;
            //Gizmos.DrawCube(Vector3.zero, Vector3.one);
            //wazs going to add gismos to show hit box in game engine but i never got around to adding this because the sword was working.
            yield return null;

        }
        swordRotationOigin.transform.localRotation = Quaternion.Euler(30f, 0, 0); //this will set the sword rotation back to before attack letting the player can attack again.
        yield break;
    }
}
      
