using UnityEngine.Events;

namespace Game
{
    public class StartCharacterTurnCommand : Command
    {
        public override void Execute(UnityAction onCompleted)
        {
            GameData.GetInstance().Battle.Canvas.SetActive(true);
            GameData.GetInstance().UIPanelStateController.SetPanelState<MainUIPanelState>();
        }
    }
}