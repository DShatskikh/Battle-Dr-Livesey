using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    public class StartBattleCommand : Command
    {
        private readonly Enemy _enemy;

        public StartBattleCommand(Enemy enemy)
        {
            _enemy = enemy;
        }

        public override void Execute(UnityAction onCompleted)
        {
            GameData.GetInstance().Battle.Canvas.SetActive(true);
            GameData.GetInstance().UIPanelStateController.SetPanelState<MainUIPanelState>();
            GameData.GetInstance().Battle.Enemy = _enemy;
            onCompleted?.Invoke();
        }
    }
}