using UnityEngine;

namespace Game
{
    public class FightUIPanelState : UIPanelState
    {
        private void Start()
        {
            var assetProvider = GameData.GetInstance().AssetProvider;
            var battle = GameData.GetInstance().Battle;

            for (int i = 0; i < 1; i++)
            {
                var model = new FightSlotModel(battle.Enemy);
                var slot = Instantiate(assetProvider.FightSlotPrefab, transform);
                slot.Model = model;
                int rowIndex = i;
                int columnIndex = 0;
                _slots.Add(new Vector2(columnIndex, rowIndex), slot);
            }
            
            _currentIndex = new Vector2(0, 0);
            _slots[_currentIndex].SetSelected(true);
        }
        
        public override void OnSubmit()
        {
            print("Удар");
            ((FightSlotController)_currentSlot).Model.Enemy.TakeDamage(10);
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