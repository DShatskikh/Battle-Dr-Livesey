using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    public class IntroBattleCommand : Command
    {
        private readonly Enemy _enemy;
        private readonly Transform _characterPoint;
        private readonly Transform _enemyPoint;

        private const float SpeedPlacement = 3;
        
        public IntroBattleCommand(Enemy enemy, Transform characterPoint, Transform enemyPoint)
        {
            _enemy = enemy;
            _characterPoint = characterPoint;
            _enemyPoint = enemyPoint;
        }
        
        public override void Execute(UnityAction onCompleted)
        {
            Debug.Log("Execute");
            
            GameData.GetInstance().MusicPlayer.Stop();
            //GameData.GetInstance().EffectPlayer.Stop();
            //_startBattlePlaySound.Play();
            //GameData.Character.View.Idle();
            
            var characterTransform = GameData.GetInstance().Character.transform;
            var enemyTransform = _enemy.transform;
            
            var enemyStartPosition = enemyTransform.position;
            var normalWorldCharacterPosition = characterTransform.position;

            _enemy.StartCoroutine(AwaitMove(characterTransform, enemyTransform));
        }

        private IEnumerator AwaitMove(Transform characterTransform, Transform enemyTransform)
        {
            while (characterTransform.position !=_characterPoint.position || enemyTransform.position != _enemyPoint.position)
            {
                characterTransform.position = Vector2.MoveTowards(
                    characterTransform.position, _characterPoint.position, 
                    Time.deltaTime * SpeedPlacement);
                
                enemyTransform.position = Vector2.MoveTowards(
                    enemyTransform.position, _enemyPoint.position, 
                    Time.deltaTime * SpeedPlacement);
                
                yield return null;
            }
        }
    }
}