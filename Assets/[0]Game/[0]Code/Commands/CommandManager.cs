using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    public class CommandManager
    {
        private Coroutine _coroutine;
        private Command _currentCommand;
        
        public void StartCommands(List<Command> commands)
        {
            if (_coroutine != null)
                GameData.GetInstance().CoroutineRunner.StopCoroutine(_coroutine);
            
            _coroutine = GameData.GetInstance().CoroutineRunner.StartCoroutine(AwaitCommandsProcess(commands));
        }

        private IEnumerator AwaitCommandsProcess(List<Command> commands)
        {
            foreach (var command in commands)
            {
                _currentCommand = command;
                
                bool isComplete = false;
                command.Execute(new UnityAction(() => isComplete = true));
                yield return new WaitUntil(() => isComplete);
            }
        }

    }
}