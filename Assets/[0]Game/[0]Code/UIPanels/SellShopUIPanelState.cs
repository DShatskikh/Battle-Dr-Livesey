using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class SellShopUIPanelState : UIPanelState
    {
        [SerializeField]
        private Transform _container;
        
        private void OnEnable()
        {
            var assetProvider = GameData.GetInstance().AssetProvider;
            var items = GameData.GetInstance().Character.Model.Items;

            for (int i = 0; i < items.Count; i++)
            {
                var model = new SellShopSlotModel(items[i]);
                var slot = Instantiate(assetProvider.SellShopSlotPrefab, _container);
                slot.Model = model;
                int rowIndex = items.Count - i - 1;
                int columnIndex = 0;
                _slots.Add(new Vector2(columnIndex, rowIndex), slot);
            }
            
            _currentIndex = new Vector2(0, items.Count - 1);
            _slots[_currentIndex].SetSelected(true);
        }
        
        private void OnDisable()
        {
            foreach (var slot in _slots) 
                Destroy(slot.Value.gameObject);

            _slots = new Dictionary<Vector2, BaseSlotController>();
        }
        
        public override void OnSubmit()
        {
            var model = ((SellShopSlotController)_currentSlot).Model;
            var item = model.Item;
            var commands = new List<Command>();

            GameData.GetInstance().Character.Model.Money += item.Price;
            GameData.GetInstance().Character.Model.Items.Remove(item);

            commands.Add(new ShopMessageCommand($"Вы продали {item.Name} за {item.Price}G"));
            
            GameData.GetInstance().UIPanelStateController.ResetCurrentPanelState();
            commands.Add(new OpenPanelShopCommand());
            GameData.GetInstance().CommandManager.StartCommands(commands);
        }

        public override void OnCancel()
        {
            _panelStateController.SetPanelState<ShopUIPanelState>();
        }
    }
}