using UnityEngine;

namespace Enemies.Mole
{
    public class MoleBehaviour : Enemy
    {
        private GameObject _player;
        [SerializeField] public EnemyData enemyData;
        
        void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
            Speed = enemyData.speed;
            Health = enemyData.health;
        }

        void Update()
        {
            transform.position = Vector2.MoveTowards(MolePosition(), TargetPosition(), Speed * Time.deltaTime);
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