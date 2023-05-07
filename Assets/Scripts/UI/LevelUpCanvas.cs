using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
    /// <summary>
    ///    Class responsible for populating the upgrade holders and invoking the upgrade selection
    /// </summary>
    public class LevelUpCanvas : MonoBehaviour
    {
        public List<LevelUpOptionHolder> levelUpOptionHolders = new(3);

        public UnityEvent<int> upgradeSelectionEvent;

        public void PopulateUI(List<ScriptableObject> scriptableObjects)
        {
            for (int i = 0; i < levelUpOptionHolders.Count; i++)
            {
                levelUpOptionHolders[i].Populate(scriptableObjects[i]);
            }
        }

        public void AddUpgrade(int upgradeDataIndex)
        {
            upgradeSelectionEvent.Invoke(upgradeDataIndex);
        }
    }
}