using UnityEngine;

namespace UI
{
    public class HearthIconAnimationController : MonoBehaviour
    {
        private static readonly int Health = Animator.StringToHash("Health");
        private Animator _anim;
        private PlayerHealthBar _playerHealthBar;
        
        private void Start()
        {
            _anim = GetComponent<Animator>();
            _playerHealthBar = GetComponentInParent<PlayerHealthBar>();
        }

        private void Update()
        {
            _anim.SetFloat(Health, _playerHealthBar.GetHealth());
        }
    }
}