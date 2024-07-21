using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

namespace Game
{
    public class StartBattleTrigger : MonoBehaviour
    {
        [SerializeField]
        private Enemy _enemy;
        
        [SerializeField]
        private Transform _characterPoint, _enemyPoint;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("OnTriggerEnter2D");
            if (!other.TryGetComponent(out CharacterController character))
                return;
            
            Debug.Log("!");
            var introBattleCommand = new IntroBattleCommand(_enemy, _characterPoint, _enemyPoint);
            GameData.GetInstance().CommandManager.StartCommands(new List<Command>() {introBattleCommand});
        }
    }
}