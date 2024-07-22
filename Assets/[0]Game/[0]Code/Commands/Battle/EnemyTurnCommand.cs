using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    public class EnemyTurnCommand : Command
    {
        public override void Execute(UnityAction onCompleted)
        {
            Debug.Log("Ход противника");
            GameData.GetInstance().Battle.Canvas.SetActive(false);
            GameData.GetInstance().CoroutineRunner.StartCoroutine(AwaitTurn(onCompleted));
        }

        private IEnumerator AwaitTurn(UnityAction onCompleted)
        {
            yield return new WaitForSeconds(1);
            onCompleted.Invoke();
        }
    }
}