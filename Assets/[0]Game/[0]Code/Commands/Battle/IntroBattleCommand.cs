using System.Collections;
using System.Collections.Generic;
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
            
            var moveBattleDatas = new List<MoveBattleData>();
            moveBattleDatas.Add(new MoveBattleData(data.Character.transform, battle.CharacterPoint.position));
            
            for (int i = 0; i < _enemies.Length; i++)
                moveBattleDatas.Add(new MoveBattleData(_enemies[i].transform, battle.EnemyPoints[i].position));

            data.Battle.MoveBattleData = moveBattleDatas;
            GameData.GetInstance().CoroutineRunner.StartCoroutine(AwaitMove(onCompleted, moveBattleDatas));
        }

        private IEnumerator AwaitMove(UnityAction onCompleted, List<MoveBattleData> moveBattleDatas)
        {
            var progress = 0f;

            while (progress < 1f)
            {
                foreach (var pair in moveBattleDatas) 
                    pair.Target.position = Vector2.Lerp(pair.WorldPoint, pair.ArenaPoint, progress);

                yield return null;
                progress += Time.deltaTime * SpeedPlacement;
            }
            
            onCompleted.Invoke();
        }
    }
}