using UI;
using UnityEngine;

public class HearthIconAnimationController : MonoBehaviour
{
    private PlayerHealthBar _playerHealthBar;
    private Animator _anim;
    private static readonly int Health = Animator.StringToHash("Health");


    void Start()
    {
        _anim = GetComponent<Animator>();
        _playerHealthBar = GetComponentInParent<PlayerHealthBar>();
    }
    
    void Update()
    {
        _anim.SetFloat(Health, _playerHealthBar.GetHealth());
    }
}