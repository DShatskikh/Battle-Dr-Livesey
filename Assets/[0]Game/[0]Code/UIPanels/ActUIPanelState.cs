using UnityEngine;

namespace Game
{
    public class ActUIPanelState : UIPanelState
    {
        private void Start()
        {
            var assetProvider = GameData.GetInstance().AssetProvider;
            var acts = GameData.GetInstance().Battle.Enemy.GetActs();

            for (int i = 0; i < acts.Length; i++)
            {
                var model = new ActSlotModel(acts[i]);
                var slot = Instantiate(assetProvider.ActSlotPrefab, transform);
                slot.Model = model;
                int rowIndex = (acts.Length - i - 1) / 2;
                int columnIndex = i % 2;
                _slots.Add(new Vector2(columnIndex, rowIndex), slot);
            }
            
            _currentIndex = new Vector2(0, (acts.Length - 1) / 2);
            _slots[_currentIndex].SetSelected(true);
        }
        
        public override void OnSubmit()
        {
            print("Действие");
            _panelStateController.ResetCurrentPanelState();
            GameData.GetInstance().Battle.Enemy.Act(((ActSlotController)_currentSlot).Model.Act);
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