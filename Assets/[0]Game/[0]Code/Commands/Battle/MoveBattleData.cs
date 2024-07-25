using UnityEngine;

namespace Game
{
    public struct MoveBattleData
    {
        public Transform Target;
        public Vector2 WorldPoint;
        public Vector2 ArenaPoint;

        public MoveBattleData(Transform target, Vector2 arenaPoint)
        {
            Target = target;
            WorldPoint = target.position;
            ArenaPoint = arenaPoint;
        }
    }
}