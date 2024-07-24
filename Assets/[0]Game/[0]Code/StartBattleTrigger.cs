using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class StartBattleTrigger : MonoBehaviour
    {
        [SerializeField]
        private Enemy[] _enemies;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent(out CharacterController character))
                return;
            
            var introBattleCommand = new IntroBattleCommand(_enemies);
            var startBattleCommand = new StartBattleCommand(_enemies);
            GameData.GetInstance().CommandManager.StartCommands(new List<Command>() {introBattleCommand, startBattleCommand});
        }
    }
}