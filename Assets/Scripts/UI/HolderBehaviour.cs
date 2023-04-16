using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Weapons;

namespace GameManager
{
    public class HolderBehaviour : MonoBehaviour
    {
        public Image image;
        public TextMeshProUGUI text;
        private UpgradeData _upgrade;
        public UnityEvent<int> selectEvent;


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