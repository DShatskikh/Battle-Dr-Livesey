using UnityEngine.Events;

namespace Game
{
    public class OpenPanelSellShopCommand : Command
    {
        public override void Execute(UnityAction onCompleted)
        {
            GameData.GetInstance().UIPanelStateController.SetPanelState<SellShopUIPanelState>();
        }
    }
}