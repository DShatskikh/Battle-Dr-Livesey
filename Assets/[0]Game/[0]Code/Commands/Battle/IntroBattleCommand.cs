using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    public class IntroBattleCommand : Command
    {
        private readonly Enemy[] _enemies;

        private const float SpeedPlacement = 3;
        
        public IntroBattleCommand(Enemy[] enemies)
        {
            _enemies = enemies;
        }
        
        public override void Execute(UnityAction onCompleted)
        {
            var data = GameData.GetInstance();
            
            data.Battle.gameObject.SetActive(true);
            data.Character.enabled = false;
            data.MusicPlayer.Stop();

            var battle = data.Battle;
            
            var pairs = new List<TargetPointPair>();
            pairs.Add(new TargetPointPair(data.Character.transform, battle.CharacterPoint.position));
            
            for (int i = 0; i < _enemies.Length; i++)
                pairs.Add(new TargetPointPair(_enemies[i].transform, battle.EnemyPoints[i].position));

            GameData.GetInstance().CoroutineRunner.StartCoroutine(AwaitMove(onCompleted, pairs));
        }

        private IEnumerator AwaitMove(UnityAction onCompleted, List<TargetPointPair> pairs)
        {
            var characterPoint = GameData.GetInstance().Battle.CharacterPoint;
            var progress = 0f;

            while (progress < 1f)
            {
                foreach (var pair in pairs) 
                    pair.Target.position = Vector2.Lerp(pair.Start, pair.Finish, progress);

                yield return null;
                progress += Time.deltaTime * SpeedPlacement;
            }
            
            onCompleted.Invoke();
        }
        
        private struct TargetPointPair
        {
            public Transform Target;
            public Vector2 Start;
            public Vector2 Finish;

            public TargetPointPair(Transform target, Vector2 finish)
            {
                Target = target;
                Start = target.position;
                Finish = finish;
            }
        }
    }
}