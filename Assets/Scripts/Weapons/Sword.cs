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

    internal static void SetActive(bool v)
    {
        throw new NotImplementedException();
    }

    public override void AttackEnemy()

    {  //attacks enemy if colision hits
        if (canAttack == true)
        {
            StartCoroutine(SwordSwing());
        }
    }
    public IEnumerator SwordSwing()
    { float attackTimer = coolDownDuration;
        //transform: can edit interface transform X,Y,Z were as vector3 can only effects position
        swordRotationOigin.transform.localRotation = Quaternion.Euler(90f, 0, 0);  //localRotation effects the rotation of the object it is attached to on the (X,Y,Z) axis.

        while (attackTimer >= 0)
        {
            attackTimer -= Time.deltaTime;
            //Gizmos.color = Color.red;
            //Gizmos.DrawCube(Vector3.zero, Vector3.one);
            yield return null;

        }
        swordRotationOigin.transform.localRotation = Quaternion.Euler(30f, 0, 0);
        yield break;
    }
    




}
      
