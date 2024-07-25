using System.Collections.Generic;
using System.Linq;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    public class StartBattleNotIntroCommand : Command
    {
        private readonly Enemy[] _enemies;

        public StartBattleNotIntroCommand(Enemy[] enemies)
        {
            _enemies = enemies;
        }
        
        public override void Execute(UnityAction onCompleted)
        {
            Camera.main.GetComponent<CinemachineBrain>().CustomBlends =
                GameData.GetInstance().AssetProvider.NotBlender;
            GameData.GetInstance().Battle.Enemies = _enemies;
            GameData.GetInstance().Battle.AliveEnemies = _enemies.ToList();
            GameData.GetInstance().Battle.gameObject.SetActive(true);
            GameData.GetInstance().Character.enabled = false;
            GameData.GetInstance().MusicPlayer.Stop();

            var characterTransform = GameData.GetInstance().Character.transform;
            var characterPoint = GameData.GetInstance().Battle.CharacterPoint;
            characterTransform.position = characterPoint.position;
            
            for (int i = 0; i < _enemies.Length; i++)
                _enemies[i].transform.position  = GameData.GetInstance().Battle.EnemyPoints[i].position;
            
            var moveBattleDatas = new List<MoveBattleData>();
            moveBattleDatas.Add(new MoveBattleData(GameData.GetInstance().Character.transform, GameData.GetInstance().Battle.CharacterPoint.position));
            
            for (int i = 0; i < _enemies.Length; i++)
                moveBattleDatas.Add(new MoveBattleData(_enemies[i].transform, GameData.GetInstance().Battle.EnemyPoints[i].position));
            
            GameData.GetInstance().Battle.MoveBattleData = moveBattleDatas;
            onCompleted.Invoke();
        }
    }
}