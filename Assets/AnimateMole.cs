using UnityEngine;

public class AnimateMole : MonoBehaviour
{
    private MoleBehaviour _moleBehaviour;
    public Animator anim;
    public float hf;
    public float vf;
    private static readonly int Horizontal = Animator.StringToHash("Horizontal");
    private static readonly int Vertical = Animator.StringToHash("Vertical");

    void Start()
    {
        anim = GetComponent<Animator>();
        _moleBehaviour = GetComponentInParent<MoleBehaviour>();
    }

    void Update()
    {
        //Logic for getting the distance between this GameObject and player and transforming it into the Vertical and Horizontal Axis values (between -1 an 1)
        hf = (Mathf.InverseLerp(-10, 10, _moleBehaviour.MolePosition().x - _moleBehaviour.TargetPosition().x) - 0.5f) *
             -2.0f;
        vf = (Mathf.InverseLerp(-10, 10, _moleBehaviour.MolePosition().y - _moleBehaviour.TargetPosition().y) - 0.5f) *
             -2.0f;

        anim.SetFloat(Horizontal, hf);
        anim.SetFloat(Vertical, vf);
    }
}