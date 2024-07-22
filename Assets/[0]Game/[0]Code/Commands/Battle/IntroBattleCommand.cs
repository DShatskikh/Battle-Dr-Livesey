using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    public class IntroBattleCommand : Command
    {
        private readonly Enemy _enemy;

        private const float SpeedPlacement = 3;
        
        public IntroBattleCommand(Enemy enemy)
        {
            _enemy = enemy;
        }
        
        public override void Execute(UnityAction onCompleted)
        {
            GameData.GetInstance().Battle.gameObject.SetActive(true);
            GameData.GetInstance().Character.enabled = false;
            GameData.GetInstance().MusicPlayer.Stop();

            var characterTransform = GameData.GetInstance().Character.transform;
            var enemyTransform = _enemy.transform;

            _enemy.StartCoroutine(AwaitMove(onCompleted, characterTransform, enemyTransform));
        }

        private IEnumerator AwaitMove(UnityAction onCompleted, Transform characterTransform, Transform enemyTransform)
        {
            var characterPoint = GameData.GetInstance().Battle.CharacterPoint;
            var enemyPoint = GameData.GetInstance().Battle.EnemyPoint;
            
            while (characterTransform.position !=characterPoint.position || enemyTransform.position != enemyPoint.position)
            {
                characterTransform.position = Vector2.MoveTowards(
                    characterTransform.position, characterPoint.position, 
                    Time.deltaTime * SpeedPlacement);
                
                enemyTransform.position = Vector2.MoveTowards(
                    enemyTransform.position, enemyPoint.position, 
                    Time.deltaTime * SpeedPlacement);
                
                yield return null;
            }
            
            onCompleted.Invoke();
        }
    }
}