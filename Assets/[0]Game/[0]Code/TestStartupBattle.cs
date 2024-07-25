using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class TestStartupBattle : MonoBehaviour
    {
        [SerializeField] 
        private Enemy[] _enemies;

        [SerializeField]
        private List<Item> _items;

        private IEnumerator Start()
        {
            yield return null;
            var introBattleCommand = new StartBattleNotIntroCommand(_enemies);
            var startBattleCommand = new StartBattleCommand(_enemies);
            GameData.GetInstance().CommandManager.StartCommands(new List<Command>() {introBattleCommand, startBattleCommand});

            GameData.GetInstance().Character.Model.Items = _items;
        }
    }
}