using UnityEngine;

namespace Player
{
    public class AnimatePlayer : MonoBehaviour
    {
        private static readonly int Horizontal = Animator.StringToHash("Horizontal");
        private static readonly int Vertical = Animator.StringToHash("Vertical");
        private static readonly int HorizontalX = Animator.StringToHash("LastMoveX");
        private static readonly int VerticalY = Animator.StringToHash("LastMoveY");
        private Animator _anim;
        private bool _isMoving;

        // Start is called before the first frame update
        private void Start()
        {
            _anim = GetComponent<Animator>();
            GetComponentInParent<PlayerInput>().movementEvent.AddListener(IsMoving);
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
    }
}