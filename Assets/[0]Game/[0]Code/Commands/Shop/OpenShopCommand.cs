using UnityEngine.Events;

namespace Game
{
    public class OpenShopCommand : Command
    {
        public override void Execute(UnityAction onCompleted)
        {
            GameData.GetInstance().Shop.Open();
        }
    }
}