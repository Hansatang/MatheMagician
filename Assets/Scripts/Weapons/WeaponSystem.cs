using System;
using UnityEngine;

namespace Weapons
{
    /// <summary>
    ///    Baseline responsible for manipulating the weapon launchers
    /// </summary>
    public abstract class WeaponSystem : MonoBehaviour
    {
        public int weaponId;
        public float initialSpeed;
        public float initialArea;
        public int initialPower;
        public float speedEnhanced;
        public float areaEnhanced;
        public int powerEnhanced;

        public virtual void Arm()
        {
        }

        public virtual void Stop()
        {
            Destroy(gameObject);
        }

        public virtual void UpgradeAll(float speedEnhancements, float powerEnhancements, float areaEnhancements)
        {
            speedEnhanced = initialSpeed * speedEnhancements;
            powerEnhanced = (int) Math.Ceiling(initialPower * powerEnhancements);
            areaEnhanced = initialArea * areaEnhancements;
        }

        public void SetEnhancedStats(float speed, float area, float power)
        {
            initialSpeed = speed;
            initialPower = (int) Math.Ceiling(power);
            initialArea = area;
        }
    }
}