using UnityEngine;

public class IWeaponSystem : MonoBehaviour
{
    public int WeaponId;

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