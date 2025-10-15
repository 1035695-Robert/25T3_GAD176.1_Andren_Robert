using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Sword : Weapon
{
    private int attackPower;
    private int attackrange = 5; 

    
    private void attack()
    {  //attacks enemy if colision hits
        if (canAttack == true)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawCube(Vector3.zero, Vector3.one); 
            
            canAttack = false;
            
            NextAttack();
        }
      
    }
    
}
