using UnityEngine;

namespace Player
{
    /// <summary>
    ///    Class responsible for animating the player
    /// </summary>
    public class AnimatePlayer : MonoBehaviour
    {
        private static readonly int Horizontal = Animator.StringToHash("Horizontal");
        private static readonly int Vertical = Animator.StringToHash("Vertical");
        private static readonly int HorizontalX = Animator.StringToHash("LastMoveX");
        private static readonly int VerticalY = Animator.StringToHash("LastMoveY");
        private static readonly int DeadState = Animator.StringToHash("IsDead");
        private Animator _anim;
        private bool _isMoving;

        private void Start()
        {
            _anim = GetComponent<Animator>();
            GetComponentInParent<PlayerInput>().movementEvent.AddListener(IsMoving);
            GetComponentInParent<PlayerHealth>().deathEvent.AddListener(IsDead);
            GetComponentInParent<PlayerHealth>().invincibilityEvent.AddListener(ScaleModelTo);
        }

        private void IsMoving(bool moving, Vector2 movementVector)
        {
            _isMoving = moving;

            if (_isMoving)
            {
                _anim.SetFloat(HorizontalX, movementVector.x);
                _anim.SetFloat(VerticalY, movementVector.y);
            }

            _anim.SetFloat(Horizontal, movementVector.x);
            _anim.SetFloat(Vertical, movementVector.y);
        }

        private void IsDead()
        {
            GetComponentInParent<PlayerInput>().DenyInput();
            _anim.SetBool(DeadState, true);
        }

        public void DeathAnimationFinished()
        {
            GetComponentInParent<PlayerCharacter>().PlayerDeath();
        }

        private void ScaleModelTo(Vector3 scale)
        {
            if (scale == Vector3.one)
            {
                transform.localScale = scale;
            }
            else if (transform.localScale == Vector3.one)
            {
                transform.localScale = Vector3.zero;
            }
            else if (transform.localScale == Vector3.zero)
            {
                transform.localScale = Vector3.one;
            }
          
        }
    }
}