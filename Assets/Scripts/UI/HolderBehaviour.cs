using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Weapons;

namespace UI
{
    /// <summary>
    ///    Class responsible for presenting the data about possible upgrade to player
    /// </summary>
    public class HolderBehaviour : MonoBehaviour
    {
        public Image image;
        public TextMeshProUGUI text;
        public UnityEvent<int> selectEvent;
        private UpgradeData _upgrade;


        public void Populate(ScriptableObject serializableObject)
        {
            _upgrade = (UpgradeData) serializableObject;
            image.sprite = _upgrade.upgradeImage;
            text.text = _upgrade.upgradeDescription;
        }

        public void AddUpgrade()
        {
            selectEvent.Invoke(_upgrade.upgradeIndex);
        }
    }
}