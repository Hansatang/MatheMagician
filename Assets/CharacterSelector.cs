using UnityEngine;
using UnityEngine.Events;

public class CharacterSelector : MonoBehaviour
{
    [SerializeField] private CharacterData[] characterDatas;
    [SerializeField] private CharacterDisplay characterDisplay;
    public UnityEvent<CharacterData> selectedCharacterData;
    private int _currentIndex;

    private void Awake()
    {
        ChangeDisplayedCharacterData(0);
    }

    public void NavigateLeft()
    {
        _currentIndex -= 1;
        if (_currentIndex < 0)
        {
            _currentIndex = characterDatas.Length - 1;
            ChangeDisplayedCharacterData(_currentIndex);
        }
        else
        {
            ChangeDisplayedCharacterData(_currentIndex);
        }
    }

    public void NavigateRight()
    {
        _currentIndex += 1;
        if (_currentIndex > characterDatas.Length - 1)
        {
            _currentIndex = 0;
            ChangeDisplayedCharacterData(_currentIndex);
        }
        else
        {
            ChangeDisplayedCharacterData(_currentIndex);
        }
    }

    private void ChangeDisplayedCharacterData(int index)
    {
        characterDisplay.DisplayCharacter(characterDatas[index]);
    }

    public void SelectCharacter()
    {
        selectedCharacterData.Invoke(characterDatas[_currentIndex]);
    }
}