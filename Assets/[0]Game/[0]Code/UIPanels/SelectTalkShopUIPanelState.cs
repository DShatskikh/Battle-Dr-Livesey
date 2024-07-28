using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class SelectTalkShopUIPanelState : UIPanelState
    {
        [SerializeField]
        private Transform _container;

        private void OnEnable()
        {
            var assetProvider = GameData.GetInstance().AssetProvider;
            var talks = GameData.GetInstance().Shop.Talks;

            for (int i = 0; i < talks.Length; i++)
            {
                var model = new SelectTalkShopSlotModel(talks[i]);
                var slot = Instantiate(assetProvider.SelectTalkShopSlotPrefab, _container);
                slot.Model = model;
                int rowIndex = talks.Length - i - 1;
                int columnIndex = 0;
                _slots.Add(new Vector2(columnIndex, rowIndex), slot);
            }
            
            _currentIndex = new Vector2(0, talks.Length - 1);
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
            var model = ((SelectTalkShopSlotController)_currentSlot).Model;
            var config = model.Config;
            var commands = new List<Command>();

            GameData.GetInstance().UIPanelStateController.ResetCurrentPanelState();
            commands.Add(new ShopMessageCommand(config.Message));
            commands.Add(new OpenPanelSelectTaskShopCommand());
            GameData.GetInstance().CommandManager.StartCommands(commands);
        }

        public override void OnCancel()
        {
            _panelStateController.SetPanelState<ShopUIPanelState>();
        }
    }
}