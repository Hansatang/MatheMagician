using UnityEngine;

namespace Enemies
{
    /// <summary>
    /// ScriptableObject used for storing Enemy data
    /// </summary>
    [CreateAssetMenu(fileName = "New Enemy", menuName = "Scriptable Objects/Enemies")]
    public class EnemyData : ScriptableObject
    {
        public float health;
        public float speed;
    }
}