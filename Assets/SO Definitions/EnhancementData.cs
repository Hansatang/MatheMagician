using UnityEngine;

namespace Weapons
{
    /// <summary>
    ///    ScriptableObject responsible for holding the enhancement statistics
    /// </summary>
    [CreateAssetMenu(fileName = "New Enhancement", menuName = "Scriptable Objects/Upgrade/Enhancement")]
    public class EnhancementData : UpgradeData
    {
        public EnhancementTypes enhancementType;
        public float enhancementMultiplier;
    }
}