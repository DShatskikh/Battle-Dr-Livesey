using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class TestStartupBattle : MonoBehaviour
    {
        [SerializeField] 
        private Enemy _enemy;
        
        private IEnumerator Start()
        {
            yield return null;
            var introBattleCommand = new NotIntroBattleCommand(_enemy);
            var startBattleCommand = new StartBattleCommand(_enemy);
            GameData.GetInstance().CommandManager.StartCommands(new List<Command>() {introBattleCommand, startBattleCommand});
        }
    }
}