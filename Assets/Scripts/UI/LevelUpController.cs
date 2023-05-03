using UnityEngine;
using UnityEngine.Events;

namespace UI
{
    /// <summary>
    ///    Class responsible for populating the upgrade holders and invoking the upgrade selection
    /// </summary>
    public class LevelUpController : MonoBehaviour
    {
        public HolderBehaviour firstHolder;
        public HolderBehaviour secondHolder;
        public HolderBehaviour thirdHolder;
        public UnityEvent<int> upgradeSelectionEvent;

        public void PopulateUI(ScriptableObject sOb1, ScriptableObject sOb2, ScriptableObject sOb3)
        {
            firstHolder.Populate(sOb1);
            secondHolder.Populate(sOb2);
            thirdHolder.Populate(sOb3);
        }

        public void AddUpgrade(int upgradeDataIndex)
        {
            upgradeSelectionEvent.Invoke(upgradeDataIndex);
        }
    }
}