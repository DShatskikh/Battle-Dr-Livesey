using UnityEngine;

namespace Game
{
    public class ItemsUIPanelState : UIPanelState
    {
        private void Start()
        {
            var assetProvider = GameData.GetInstance().AssetProvider;

            for (int i = 0; i < 8; i++)
            {
                var model = new ItemSlotModel("Item" + (i + 1));
                var slot = Instantiate(assetProvider.ItemSlotPrefab, transform);
                slot.Model = model;
                int rowIndex = (8 - i - 1) / 4;
                int columnIndex = i % 4;
                _slots.Add(new Vector2(columnIndex, rowIndex), slot);
            }
            
            _currentIndex = new Vector2(0, (8 - 1) / 4);
            _slots[_currentIndex].SetSelected(true);
        }
        
        public override void OnSubmit()
        {
            print("Предмет");
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