using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using SAE.GAD176.Shoot;
using System;



public class Slingshot : Weapon
{
    [SerializeField] private Shoot shootScript;


    public override void AttackEnemy()
    {
            shootScript = gameObject.GetComponent<Shoot>();

            shootScript.SetSeedType();
        
    }

}



