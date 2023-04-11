using UnityEngine;
using UnityEngine.Events;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public UnityEvent<int> startingWeaponIndex;
    private void Awake()
    {
        LoadPlayer();
    }

    private void LoadPlayer()
    {
        if (SelectedCharacter.selectedCharacter != null)
        {
            CharacterData character = SelectedCharacter.selectedCharacter;
            Instantiate(character.characterObject, player.transform);
            startingWeaponIndex.Invoke(character.startingWeapon.upgradeIndex);
        }
      
    }
}
