using Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    /// <summary>
    ///    Class responsible for displaying the character in character selection
    /// </summary>
    public class CharacterDisplay : MonoBehaviour
    {
        [SerializeField] public TextMeshProUGUI characterName;
        [SerializeField] public TextMeshProUGUI characterSpeed;
        [SerializeField] public TextMeshProUGUI characterHealth;
        [SerializeField] public TextMeshProUGUI characterWeapon;
        [SerializeField] public Image characterSprite;

        public void DisplayCharacter(CharacterData characterData)
        {
            characterName.text = characterData.characterName;
            characterSpeed.text = characterData.characterSpeed.ToString();
            characterHealth.text = characterData.characterHealth.ToString();
            characterWeapon.text = characterData.startingWeapon.upgradeName;
            characterSprite.sprite = characterData.characterSprite;
        }
    }
}