using UnityEngine;

namespace Enemies.Mole
{
    public class MoleBehaviour : Enemy
    {
        public void Move(Vector2 moveDirection)
        {
            EnemyBody.velocity = moveDirection * Speed;
        }
    }
}