using Misc;
using UnityEngine;

namespace Enemies.Treant_Boss
{
    public class BossEnemy : Enemy
    {
        public Portal portal;

        public void SpawnPortal()
        {
            Instantiate(portal, transform.position, Quaternion.identity);
        }
    }
}