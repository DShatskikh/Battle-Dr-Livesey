using System.Collections;
using UnityEngine.Events;

namespace Game
{
    public abstract class Command
    {
        public abstract void Execute(UnityAction onCompleted);
    }
}