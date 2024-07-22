using UnityEngine;

namespace Game
{
    public class ActUIPanelState : UIPanelState
    {
        private void Start()
        {
            var assetProvider = GameData.GetInstance().AssetProvider;

            for (int i = 0; i < 4; i++)
            {
                var model = new ActSlotModel("Act" + (i + 1));
                var slot = Instantiate(assetProvider.ActSlotPrefab, transform);
                slot.Model = model;
                int rowIndex = (4 - i - 1) / 2;
                int columnIndex = i % 2;
                _slots.Add(new Vector2(columnIndex, rowIndex), slot);
            }
            
            _currentIndex = new Vector2(0, (4 - 1) / 2);
            _slots[_currentIndex].SetSelected(true);
        }
        
        public override void OnSubmit()
        {
            print("Действие");
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