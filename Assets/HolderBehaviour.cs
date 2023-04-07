using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[Serializable]
public class SelectEvent : UnityEvent<GameObject>
{
}

public class HolderBehaviour : MonoBehaviour
{
    public Image image;
    public TextMeshProUGUI text;
    private WeaponData _weapon;
    public SelectEvent selectEvent;

    public void Populate(ScriptableObject serializableObject)
    {
        _weapon = (WeaponData) serializableObject;
        image.sprite = _weapon.weaponImage;
        text.text = _weapon.weaponDescription;
    }

    public void AddUpgrade()
    {
        selectEvent.Invoke(_weapon.weaponObject);
    }
}