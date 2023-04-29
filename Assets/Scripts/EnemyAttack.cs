using Player;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")) other.gameObject.GetComponent<PlayerHealth>().TakeDamage(1);
    }
}