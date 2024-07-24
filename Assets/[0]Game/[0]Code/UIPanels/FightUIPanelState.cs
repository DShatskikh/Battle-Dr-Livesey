using System;
using System.Collections;
using UnityEngine;

namespace Game
{
    public class FightUIPanelState : UIPanelState
    {
        private const float Speed = 1;

        [SerializeField]
        private Transform _startPoint, _finishPoint;

        [SerializeField]
        private Transform _slash;

        private float _progress = 0;
        private Coroutine _moveCoroutine;
        private Coroutine _finishCoroutine;

        private void OnEnable()
        {
            _moveCoroutine = StartCoroutine(AwaitMove());
        }

        public override void OnSubmit()
        {
            if (_moveCoroutine != null)
            {
                StopCoroutine(_moveCoroutine);
                _finishCoroutine = StartCoroutine(AwaitFinish());
            }
        }

        public override void OnCancel()
        {
            
        }

        public override void OnSlotIndexChanged(Vector2 direction)
        {
            
        }

        private IEnumerator AwaitMove()
        {
            _progress = 0;
            var speed = 0f;
            
            while (_progress < 1)
            {
                var startPosition = _slash.transform.position;
                _slash.transform.position = 
                    Vector2.Lerp(_startPoint.position, _finishPoint.position, _progress);

                speed = Vector2.Distance(_slash.transform.position, startPosition) / Time.deltaTime;
                yield return null;
                _progress += Time.deltaTime * Speed;
            }

            _progress = 0;
            
            var timeMove = 0f;
            
            while (timeMove < 0.8f)
            {
                _slash.transform.position += (Vector3)Vector2.left * speed * Time.deltaTime;
                yield return null;
                timeMove += Time.deltaTime;
            }
            
            _finishCoroutine = StartCoroutine(AwaitFinish());
        }

        private IEnumerator AwaitFinish()
        {
            GameData.GetInstance().Battle.SelectedEnemy.TakeDamage((int)(Mathf.Ceil(_progress * 10)));
            yield return new WaitForSeconds(2);
            GameData.GetInstance().UIPanelStateController.ResetCurrentPanelState();
            GameData.GetInstance().Battle.Turn();
        }
    }
}