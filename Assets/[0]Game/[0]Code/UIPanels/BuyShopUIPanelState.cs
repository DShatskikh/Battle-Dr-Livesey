using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class BuyShopUIPanelState : UIPanelState
    {
        [SerializeField]
        private Transform _container;

        private bool _isInit;
        
        private void OnEnable()
        {
            var assetProvider = GameData.GetInstance().AssetProvider;
            var configs = GameData.GetInstance().Shop.Configs;

            for (int i = 0; i < configs.Count; i++)
            {
                var model = new BuyShopSlotModel(configs[i]);
                var slot = Instantiate(assetProvider.BuyShopSlotPrefab, _container);
                slot.Model = model;
                int rowIndex = (configs.Count - i - 1) / 2;
                int columnIndex = i % 2;
                _slots.Add(new Vector2(columnIndex, rowIndex), slot);
            }
            
            if (!_isInit)
                _currentIndex = new Vector2(0, (configs.Count - 1) / 2);
            
            _slots[_currentIndex].SetSelected(true);
            _isInit = true;
        }

        private void OnDisable()
        {
            GameData.GetInstance().Shop.Configs = new List<BuyShopConfig>();

            foreach (var slot in _slots)
            {
                GameData.GetInstance().Shop.Configs.Add(((BuyShopSlotController)slot.Value).Model.Config);
                Destroy(slot.Value.gameObject);
            }

            _slots = new Dictionary<Vector2, BaseSlotController>();
        }
        
        public override void OnSubmit()
        {
            var model = ((BuyShopSlotController)_currentSlot).Model;
            var config = model.Config;
            
            if (config.IsSold)
                return;
            
            var item = config.Item;
            var commands = new List<Command>();

            if (GameData.GetInstance().Character.Model.Money >= item.Price)
            {
                GameData.GetInstance().Character.Model.Money -= item.Price;
                model.Config.IsSold = true;

                commands.Add(new ShopMessageCommand("Вы купили что-то"));
            }
            else
            {
                commands.Add(new ShopMessageCommand("У вас недостаточно денег"));
            }
            
            GameData.GetInstance().UIPanelStateController.ResetCurrentPanelState();
            commands.Add(new OpenPanelBuyShopCommand());
            GameData.GetInstance().CommandManager.StartCommands(commands);
        }

        public override void OnCancel()
        {
            _panelStateController.SetPanelState<ShopUIPanelState>();
        }
    }
}