using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class AIData : MonoBehaviour
    {
        public List<Transform> targets;
        public Collider2D[] obstacles;

        public Transform currentTarget;

        public int GetTargetsCount()
        {
            return targets?.Count ?? 0;
        }
    }
}