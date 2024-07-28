using UnityEngine.Events;

namespace Game
{
    public class OpenPanelSelectTaskShopCommand : Command
    {
        public override void Execute(UnityAction onCompleted)
        {
            GameData.GetInstance().UIPanelStateController.SetPanelState<SelectTalkShopUIPanelState>();
        }
    }
}