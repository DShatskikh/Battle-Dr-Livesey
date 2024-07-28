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
            var battle = GameData.GetInstance().Battle;
            battle.Arena.gameObject.SetActive(true);

            while (battle.HeartController.Model.Progress < 100)
            {
                var attackPrefab = battle.SelectedEnemy.GetAttack();
                var attack = Object.Instantiate(attackPrefab, battle.Arena.transform);
                yield return attack.Execute();
                yield return attack.Cancel();
                yield return new WaitForSeconds(1);
            }
            
            yield return new WaitForSeconds(3);
            GameData.GetInstance().Battle.Arena.gameObject.SetActive(false);
            onCompleted.Invoke();
        }
    }
}