using UnityEngine;

public class ExpOrb : MonoBehaviour
{
    private int worth;

    public void SetWorth(int value)
    {
        worth = value;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerExperience>().AwardExperience(worth);
            Destroy(gameObject);
        }
    }
    
}
