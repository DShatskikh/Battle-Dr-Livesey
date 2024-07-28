using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    public abstract class AttackBase : MonoBehaviour
    {
        public abstract IEnumerator Execute();

        public abstract IEnumerator Cancel();
    }
}