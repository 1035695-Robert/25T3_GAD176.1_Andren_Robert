using UnityEngine;
namespace SAE.GAD176.SlimeBall.Healing
{
    public class SlimeBall : Items
    {
        public int healingAmount;
        [SerializeField] GameObject slimeEnemy;
        public MeleeSlime slimeScript;
        private void Start()
        {
          
        }
        private void OnCollisionEnter(Collision collision)
        {
            slimeScript = slimeEnemy.GetComponent<MeleeSlime>();
        //heals melee slime on trigger
            slimeScript.AbsorbHeal();
            //Destroy(this.gameObject);
        }
    }
}
