using UnityEngine;
using Weapons;

namespace SO_Definitions
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