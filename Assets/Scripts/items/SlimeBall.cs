using UnityEngine;
namespace SAE.GAD176.SlimeBall.Healing
{
    public class SlimeBall : DropItems
    {
        [SerializeField]public float healingAmount = 3.0f;
        
        [SerializeField]private MeleeSlime slimeScript;

        private void Awake()
        {
           slimeScript.healAmount = healingAmount;
        }
    }
}
