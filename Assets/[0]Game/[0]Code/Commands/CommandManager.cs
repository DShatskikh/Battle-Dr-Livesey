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
        
        private readonly MonoBehaviour _coroutineRunner;

        public CommandManager(MonoBehaviour coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }
        
        public void StartCommands(List<Command> commands)
        {
            Debug.Log("StartCommands");
            
            if (_coroutine != null)
                _coroutineRunner.StopCoroutine(_coroutine);
            
            _coroutine = _coroutineRunner.StartCoroutine(AwaitCommandsProcess(commands));
        }

        private IEnumerator AwaitCommandsProcess(List<Command> commands)
        {
            Debug.Log("AwaitCommandsProcess");
            
            foreach (var command in commands)
            {
                _currentCommand = command;
                
                bool isComplete = false;
                command.Execute(new UnityAction(() => isComplete = true));
                
                Debug.Log("Execute");
                
                yield return new WaitUntil(() => isComplete);
                
                Debug.Log("End");
            }
        }

    }
}