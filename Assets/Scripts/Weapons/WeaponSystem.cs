using System;
using UnityEngine;

namespace Weapons
{
    public abstract class WeaponSystem : MonoBehaviour
    {
        public int weaponId;
        public float speed;
        public float area;
        public int power;

        public virtual void Arm()
        {
        }

        public virtual void Stop()
        {
            Destroy(gameObject);
        }

        public virtual void UpgradeAll(float speedEnhancements, float powerEnhancements, float areaEnhancements)
        {
            speed = (float) Math.Ceiling(speed * speedEnhancements);
            power = (int) Math.Ceiling(power * powerEnhancements);
            area = (float) Math.Ceiling(area * areaEnhancements);
        }
    }
}