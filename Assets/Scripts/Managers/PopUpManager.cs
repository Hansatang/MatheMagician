using TMPro;
using UI;
using UnityEngine;

namespace Managers
{
    public class PopUpManager : MonoBehaviour
    {
        [SerializeField] private PopUp popUpObject;

        public void ShowDamagePopUp(string value, Vector3 target)
        {
            PopUp popUp = Instantiate(popUpObject, transform);
            popUp.GetComponent<TextMeshPro>().text = value;
            popUp.transform.position = target;
        }
    }
}