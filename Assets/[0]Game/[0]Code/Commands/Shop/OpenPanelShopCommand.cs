using UnityEngine.Events;

namespace Game
{
    public class OpenPanelShopCommand : Command
    {
        public override void Execute(UnityAction onCompleted)
        {
            GameData.GetInstance().UIPanelStateController.SetPanelState<ShopUIPanelState>();
        }
    }
}