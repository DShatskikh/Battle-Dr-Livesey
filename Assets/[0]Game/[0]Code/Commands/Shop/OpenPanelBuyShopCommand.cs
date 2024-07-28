using UnityEngine.Events;

namespace Game
{
    public class OpenPanelBuyShopCommand : Command
    {
        public override void Execute(UnityAction onCompleted)
        {
            GameData.GetInstance().UIPanelStateController.SetPanelState<BuyShopUIPanelState>();
        }
    }
}