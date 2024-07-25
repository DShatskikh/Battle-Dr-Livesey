using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class MercyUIPanelState : UIPanelState
    {
        private void OnEnable()
        {
            var assetProvider = GameData.GetInstance().AssetProvider;
            var data = assetProvider.MercySlotConfigs;

            for (int i = 0; i < data.Length; i++)
            {
                var model = new MercySlotModel(data[i]);
                var slot = Instantiate(assetProvider.MercySlotPrefab, transform);
                slot.Model = model;
                int rowIndex = data.Length - i - 1;
                int columnIndex = 0;
                _slots.Add(new Vector2(columnIndex, rowIndex), slot);
            }

            _currentIndex = new Vector2(0, data.Length - 1);
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
            switch (((MercySlotController)_currentSlot).Model.Config.OptionType)
            {
                case MercyOptionType.Mercy:
                    print("Mercy");
                    _panelStateController.ResetCurrentPanelState();
                    GameData.GetInstance().Battle.SelectedEnemy.Mercy(MercyOptionType.Mercy);
                    break;
                case MercyOptionType.Run:
                    print("Run");
                    _panelStateController.ResetCurrentPanelState();
                    GameData.GetInstance().Battle.SelectedEnemy.Mercy(MercyOptionType.Run);
                    break;
            }
        }

        public override void OnCancel()
        {
            if (GameData.GetInstance().Battle.Enemies.Length != 1)
                _panelStateController.SetPanelState<MercySelectUIPanelState>();
            else
                _panelStateController.SetPanelState<MainUIPanelState>();
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