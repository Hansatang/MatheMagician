using UnityEngine;

namespace Weapons
{
    [CreateAssetMenu(fileName = "New Enhancement", menuName = "Scriptable Objects/Upgrade/Enhancement")]
    public class EnhancementData : UpgradeData
    {
        public EnhancementTypes enhancementType;
        public float enhancementMultiplier;
    }
}