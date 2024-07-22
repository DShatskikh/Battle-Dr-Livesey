using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    public class NotIntroBattleCommand : Command
    {
        private readonly Enemy _enemy;

        public NotIntroBattleCommand(Enemy enemy)
        {
            _enemy = enemy;
        }
        
        public override void Execute(UnityAction onCompleted)
        {
            Camera.main.GetComponent<CinemachineBrain>().CustomBlends =
                GameData.GetInstance().AssetProvider.NotBlender;
            GameData.GetInstance().Battle.Enemy = _enemy;
            GameData.GetInstance().Battle.gameObject.SetActive(true);
            GameData.GetInstance().Character.enabled = false;
            GameData.GetInstance().MusicPlayer.Stop();

            var characterTransform = GameData.GetInstance().Character.transform;
            var enemyTransform = _enemy.transform;
            
            var characterPoint = GameData.GetInstance().Battle.CharacterPoint;
            var enemyPoint = GameData.GetInstance().Battle.EnemyPoint;

            characterTransform.position = characterPoint.position;
            enemyTransform.position = enemyPoint.position;

            onCompleted.Invoke();
        }
    }
}