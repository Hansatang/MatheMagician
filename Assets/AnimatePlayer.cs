using UnityEngine;

public class AnimatePlayer : MonoBehaviour
{
    private PlayerInput _playerInput;
    private Animator _anim;
    public float hf;
    public float vf;
    private static readonly int Horizontal = Animator.StringToHash("Horizontal");
    private static readonly int Vertical = Animator.StringToHash("Vertical");
    private static readonly int HorizontalX = Animator.StringToHash("LastMoveX");
    private static readonly int VerticalY = Animator.StringToHash("LastMoveY");

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _playerInput = GetComponentInParent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        hf = _playerInput.Horizontal;
        vf = _playerInput.Vertical;


        if (hf is >= 0.2f or <= -0.2f || vf is >= 0.2f or <= -0.2f)
        {
            _anim.SetFloat(HorizontalX, hf);
            _anim.SetFloat(VerticalY, vf);
        }

        _anim.SetFloat(Horizontal, hf);
        _anim.SetFloat(Vertical, vf);
    }
}