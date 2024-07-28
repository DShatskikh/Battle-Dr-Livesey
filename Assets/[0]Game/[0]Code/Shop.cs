using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Shop : MonoBehaviour
    {
        public List<BuyShopConfig> Configs;
        public MessageBox MessageBox;
        public ShopTalkConfig[] Talks;

        public void Open()
        {
            gameObject.SetActive(true);
            GameData.GetInstance().UIPanelStateController.SetPanelState<ShopUIPanelState>();
        }

        public void Close()
        {
            GameData.GetInstance().UIPanelStateController.ResetCurrentPanelState();
            gameObject.SetActive(false);
        }
    }
}