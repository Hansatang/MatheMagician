using Misc;
using SO_Definitions;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    /// <summary>
    ///    Class responsible for setting the player statistics after awakening, and for player death
    /// </summary>
    public class PlayerCharacter : MonoBehaviour
    {
        public UnityEvent<int> startingWeaponIndex;
        private CharacterData _characterData;
        public UnityEvent defeatEvent;

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

        public void PlayerDeath()
        {
            defeatEvent?.Invoke();
        }
    }
}