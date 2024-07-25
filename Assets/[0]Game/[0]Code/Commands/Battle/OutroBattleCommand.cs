using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    public class OutroBattleCommand : Command
    {
        private const float SpeedPlacement = 3;
        
        public OutroBattleCommand()
        {
            
        }
        
        public override void Execute(UnityAction onCompleted)
        {
            GameData.GetInstance().Battle.gameObject.SetActive(false);
            GameData.GetInstance().CoroutineRunner.StartCoroutine(AwaitMove(onCompleted));
        }
        
        private IEnumerator AwaitMove(UnityAction onCompleted)
        {
            var progress = 0f;

            while (progress < 1f)
            {
                foreach (var pair in GameData.GetInstance().Battle.MoveBattleData) 
                    pair.Target.position = Vector2.Lerp(pair.ArenaPoint, pair.WorldPoint, progress);

                yield return null;
                progress += Time.deltaTime * SpeedPlacement;
            }

            GameData.GetInstance().Character.enabled = true;
            onCompleted.Invoke();
        }
    }
}