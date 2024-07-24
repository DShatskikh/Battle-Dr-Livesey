using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    public class NotIntroBattleCommand : Command
    {
        private readonly Enemy[] _enemies;

        public NotIntroBattleCommand(Enemy[] enemies)
        {
            _enemies = enemies;
        }
        
        public override void Execute(UnityAction onCompleted)
        {
            Camera.main.GetComponent<CinemachineBrain>().CustomBlends =
                GameData.GetInstance().AssetProvider.NotBlender;
            GameData.GetInstance().Battle.Enemies = _enemies;
            GameData.GetInstance().Battle.gameObject.SetActive(true);
            GameData.GetInstance().Character.enabled = false;
            GameData.GetInstance().MusicPlayer.Stop();

            var characterTransform = GameData.GetInstance().Character.transform;
            var characterPoint = GameData.GetInstance().Battle.CharacterPoint;
            characterTransform.position = characterPoint.position;
            
            for (int i = 0; i < _enemies.Length; i++)
                _enemies[i].transform.position  = GameData.GetInstance().Battle.EnemyPoints[i].position;
            
            onCompleted.Invoke();
        }
    }
}