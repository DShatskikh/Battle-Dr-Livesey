using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class ActUIPanelState : UIPanelState
    {
        private void OnEnable()
        {
            var assetProvider = GameData.GetInstance().AssetProvider;
            var acts = GameData.GetInstance().Battle.SelectedEnemy.GetActs();

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
        
        private void OnDisable()
        {
            foreach (var slot in _slots) 
                Destroy(slot.Value.gameObject);

            _slots = new Dictionary<Vector2, BaseSlotController>();
        }
        
        public override void OnSubmit()
        {
            print("Действие");
            GameData.GetInstance().Battle.SelectedEnemy.Act(((ActSlotController)_currentSlot).Model.Act);
            _panelStateController.ResetCurrentPanelState();
        }

        public override void OnCancel()
        {
            if (GameData.GetInstance().Battle.Enemies.Length != 1)
                _panelStateController.SetPanelState<ActSelectUIPanelState>();
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