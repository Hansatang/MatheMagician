using UnityEngine;

namespace Weapons
{
    public abstract class WeaponSystem : MonoBehaviour
    {
        public int weaponId;

        public virtual void Arm(float speedEnhancements, float powerEnhancements, float areaEnhancements)
        {
        }

        public virtual void Stop()
        {
        }

        public virtual void UpgradeAll(float speedEnhancements, float powerEnhancements, float areaEnhancements)
        {
        }
    }
}