using UnityEngine;

public class MoleBehaviour : MonoBehaviour
{
    private GameObject _player;
    private float _speed = 2.0f;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(MolePosition(), TargetPosition(), _speed * Time.deltaTime);
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