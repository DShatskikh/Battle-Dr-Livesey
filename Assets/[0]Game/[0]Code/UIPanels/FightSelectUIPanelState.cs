using UnityEngine;

namespace Game
{
    public class FightSelectUIPanelState : UIPanelState
    {
        private void Start()
        {
            var assetProvider = GameData.GetInstance().AssetProvider;
            var battle = GameData.GetInstance().Battle;
            var enemies = battle.Enemies;

            for (int i = 0; i < enemies.Length; i++)
            {
                var model = new FightSlotModel(enemies[i]);
                var slot = Instantiate(assetProvider.FightSlotPrefab, transform);
                slot.Model = model;
                int rowIndex = enemies.Length - i - 1;
                int columnIndex = 0;
                _slots.Add(new Vector2(columnIndex, rowIndex), slot);
            }
            
            _currentIndex = new Vector2(0, enemies.Length - 1);
            _slots[_currentIndex].SetSelected(true);
        }
        
        public override void OnSubmit()
        {
            print("Выбор удара");
            GameData.GetInstance().Battle.SelectedEnemy = ((FightSlotController)_currentSlot).Model.Enemy;
            _panelStateController.SetPanelState<FightUIPanelState>();
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