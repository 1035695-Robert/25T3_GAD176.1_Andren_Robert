using UnityEngine;
namespace SAE.GAD176.SlimeBall.Healing
{
    public class SlimeBall : DropItems
    {
        [SerializeField]public float healingAmount = 3.0f;
        
        [SerializeField]private MeleeSlime slimeScript;

        private void Awake()
        {
           slimeScript.healAmount = healingAmount;  //when slimeball is picked up by slime this will tell the slime script that it can heal this much.
        }
    }
}
