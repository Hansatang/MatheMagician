using Misc;
using UnityEngine;

namespace Enemies.Base
{
    public class MoleEnemy : Enemy
    {
        public ExpOrb experienceOrb;

        public void SpawnExpOrb()
        {
            var instantiatedObject = Instantiate(experienceOrb, transform.position, Quaternion.identity);
            instantiatedObject.SetWorth(enemyData.experience);
        }
    }
}