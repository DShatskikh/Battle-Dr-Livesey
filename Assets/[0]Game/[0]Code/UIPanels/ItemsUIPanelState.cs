using UnityEngine;

namespace Game
{
    public class ItemsUIPanelState : UIPanelState
    {
        private void Start()
        {
            var assetProvider = GameData.GetInstance().AssetProvider;
            var items = GameData.GetInstance().Character.Model.Items;

            for (int i = 0; i < items.Count; i++)
            {
                var model = new ItemSlotModel(items[i]);
                var slot = Instantiate(assetProvider.ItemSlotPrefab, transform);
                slot.Model = model;
                int rowIndex = (items.Count - i - 1) / 4;
                int columnIndex = i % 4;
                _slots.Add(new Vector2(columnIndex, rowIndex), slot);
            }
            
            _currentIndex = new Vector2(0, (items.Count - 1) / 4);
            _slots[_currentIndex].SetSelected(true);
        }
        
        public override void OnSubmit()
        {
            print("Предмет");
            _panelStateController.ResetCurrentPanelState();
            
            var commands = ((ItemSlotController)_currentSlot).Model.Item.Execute();
            GameData.GetInstance().Battle.Turn(commands);
        }

        public override void OnCancel()
        {
            _panelStateController.SetPanelState<MainUIPanelState>();
        }

        public override void OnSlotIndexChanged(Vector2 direction)
        {
            var newIndex = _currentIndex + direction;
            
            if (_slots.TryGetValue(newIndex, out var model))
            {
                if (model != null)
                {
                    model.SetSelected(true);
                    var oldVM = _slots[_currentIndex];
                    oldVM.SetSelected(false);
                    _currentIndex = newIndex;
                }
            }
        }
    }
}