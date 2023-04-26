using UnityEngine;

namespace Enemies.Mole
{
    public class MoleBehaviour : Enemy
    {
        private GameObject _player;

        void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
        }

        private void FixedUpdate()
        {
            //  = (TargetPosition() - MolePosition()).normalized * Speed;
        }

        public void Move(Vector2 moveDirection)
        {
            EnemyBody.velocity = moveDirection * Speed;
        }


        public Vector3 MolePosition()
        {
            return transform.position;
        }

        public Vector3 TargetPosition()
        {
            return _player.transform.position;
        }
    }
}