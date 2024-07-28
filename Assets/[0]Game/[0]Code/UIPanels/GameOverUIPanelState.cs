using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class GameOverUIPanelState : UIPanelState
    {
        private void OnEnable()
        {
            var assetProvider = GameData.GetInstance().AssetProvider;
            var data = assetProvider.GameOverButtonConfigs;
            
            for (int i = 0; i < data.Length; i++)
            {
                var model = new GameOverSlotModel(data[i]);
                var slot = Instantiate(assetProvider.GameOverSlotPrefab, transform);
                slot.Model = model;
                int rowIndex = data.Length - i - 1;
                int columnIndex = i;
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
            switch (((GameOverSlotController)_currentSlot).Model.Config.OptionType)
            {
                case GameOverOptionType.Restart:
                    print("Restart");
                    break;
                case GameOverOptionType.Continue:
                    print("Continue");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override void OnCancel()
        {
            
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