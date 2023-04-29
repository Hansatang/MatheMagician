using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class PlayerCharacter : MonoBehaviour
    {
        public UnityEvent<int> startingWeaponIndex;
        private CharacterData _characterData;

        private void Awake()
        {
            if (SelectedCharacter.selectedCharacter != null)
            {
                _characterData = SelectedCharacter.selectedCharacter;
                Instantiate(_characterData.characterObject, gameObject.transform);
                startingWeaponIndex.Invoke(_characterData.startingWeapon.upgradeIndex);
                GetComponentInParent<EntityHealth>().SetHealth(_characterData.characterHealth);
                GetComponentInParent<PlayerMovement>().SetSpeed(_characterData.characterSpeed);
            }
        }
    }
}