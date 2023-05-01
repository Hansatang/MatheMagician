using UnityEngine;

namespace Enemies
{
    public class AnimateEnemy : MonoBehaviour
    {
        private static readonly int Horizontal = Animator.StringToHash("Horizontal");
        private static readonly int Vertical = Animator.StringToHash("Vertical");
        private static readonly int IsAttacking = Animator.StringToHash("IsAttacking");
        public float hf;
        public float vf;
        private Animator _anim;

        private void Start()
        {
            _anim = GetComponent<Animator>();
        }


        public void LookAt(Vector2 lookAtVector)
        {
            //Logic for getting the distance between this GameObject and player and transforming it into
            //the Vertical and Horizontal Axis values (between -1 an 1)
            hf = (Mathf.InverseLerp(-10, 10, transform.position.x - lookAtVector.x) -
                  0.5f) *
                 -2.0f;
            vf = (Mathf.InverseLerp(-10, 10, transform.position.y - lookAtVector.y) -
                  0.5f) *
                 -2.0f;

            _anim.SetFloat(Horizontal, hf);
            _anim.SetFloat(Vertical, vf);
        }

        public void SetAttackingState(bool attacking)
        {
            _anim.SetBool(IsAttacking, attacking);
        }
    }
}