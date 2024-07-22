using UnityEngine.Events;

namespace Game
{
    public class StartCharacterTurn : Command
    {
        public override void Execute(UnityAction onCompleted)
        {
            GameData.GetInstance().Battle.Canvas.SetActive(true);
            GameData.GetInstance().UIPanelStateController.SetPanelState<MainUIPanelState>();
        }
    }
}