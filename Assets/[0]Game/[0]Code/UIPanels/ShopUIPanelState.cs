using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class ShopUIPanelState : UIPanelState
    {
        [SerializeField]
        private Transform _container;

        private bool _isInit;
        
        private void OnEnable()
        {
            var assetProvider = GameData.GetInstance().AssetProvider;
            var configs = assetProvider.ShopSlotConfigs;

            for (int i = 0; i < configs.Length; i++)
            {
                var model = new ShopSlotModel(configs[i]);
                var slot = Instantiate(assetProvider.ShopSlotPrefab, _container);
                slot.Model = model;
                int rowIndex = configs.Length - i - 1;
                int columnIndex = 0;
                _slots.Add(new Vector2(columnIndex, rowIndex), slot);
            }
            
            if (!_isInit)
                _currentIndex = new Vector2(0, configs.Length - 1);
            
            _slots[_currentIndex].SetSelected(true);
            _isInit = true;
        }
        
        private void OnDisable()
        {
            foreach (var slot in _slots) 
                Destroy(slot.Value.gameObject);

            _slots = new Dictionary<Vector2, BaseSlotController>();
        }
        
        public override void OnSubmit()
        {
            switch (((ShopSlotController)_currentSlot).Model.Config.ShopMenuOptionType)
            {
                case ShopMenuOptionType.Buy:
                    GameData.GetInstance().UIPanelStateController.SetPanelState<BuyShopUIPanelState>();
                    break;
                case ShopMenuOptionType.Sell:
                    if (GameData.GetInstance().Character.Model.Items.Count == 0)
                        return;
                    
                    GameData.GetInstance().UIPanelStateController.SetPanelState<SellShopUIPanelState>();
                    break;
                case ShopMenuOptionType.Talk:
                    GameData.GetInstance().UIPanelStateController.SetPanelState<SelectTalkShopUIPanelState>();
                    break;
                case ShopMenuOptionType.Exit:
                    GameData.GetInstance().Shop.Close();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override void OnCancel()
        {

        }

        public override void OnSlotIndexChanged(Vector2 direction)
        {
            var newIndex = _currentIndex + direction;
            
            if (_slots.TryGetValue(newIndex, out var controller))
            {
                if (controller != null)
                { 
                    controller.SetSelected(true);
                    var oldVM = _slots[_currentIndex];
                    oldVM.SetSelected(false);
                    _currentIndex = newIndex;
                }
            }
        }
    }
}