using UnityEngine;
namespace SAE.GAD176.SlimeBall.Healing
{
    public class SlimeBall : Items
    {
        public int healingAmount;

        public void healSlime(MeleeSlime meleeSlime)
        {

            //heals melee slime on trigger
            meleeSlime.AbsorbHeal();
        }

    }
}
