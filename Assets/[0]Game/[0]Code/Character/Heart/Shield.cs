using System.Collections;
using UnityEngine;

namespace Game
{
    public class Shield
    {
        private const float ShowDelayUse = 0.2f;
        private const float PauseDelayUse = 0.05f;

        private readonly HeartModel _model;

        private Coroutine _coroutine;

        public Shield(HeartModel model)
        {
            _model = model;
        }

        public void Execute(Vector2 position)
        {
            if (_coroutine == null)
            {
                if (IsShel(Physics2D.OverlapCircleAll(position, 0.55f)))
                    _coroutine = GameData.GetInstance().CoroutineRunner.StartCoroutine(Use());
            }
        }

        private bool IsShel(Collider2D[] colliders)
        {
            foreach (var collider in colliders)
            {
                if (collider.TryGetComponent(out Shell shell))
                    return true;
            }

            return false;
        }

        private IEnumerator Use()
        {
            _model.AddTurnProgress(10);
            _model.SetIsShield(true);
            yield return new WaitForSeconds(ShowDelayUse);
            _model.SetIsShield(false);
            yield return new WaitForSeconds(PauseDelayUse);
            _coroutine = null;
        }
    }
}