using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    public class StartBattleCommand : Command
    {
        private readonly Enemy[] _enemies;

        public StartBattleCommand(Enemy[] enemies)
        {
            _enemies = enemies;
        }

        public override void Execute(UnityAction onCompleted)
        {
            GameData.GetInstance().Battle.Canvas.SetActive(true);
            GameData.GetInstance().UIPanelStateController.SetPanelState<MainUIPanelState>();
            GameData.GetInstance().Battle.Enemies = _enemies;
            onCompleted?.Invoke();
        }
    }
}