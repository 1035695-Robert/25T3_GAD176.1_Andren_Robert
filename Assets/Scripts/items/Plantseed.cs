using JetBrains.Annotations;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Plantseed : Projectile
{
    public override void DamageSet()
    {
       damage = 2;
       base.DamageSet();
    }

    
    
}
