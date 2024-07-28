using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Game
{
    public class ItemsUIPanelState : UIPanelState
    {
        [SerializeField]
        private Transform _container;

        [SerializeField]
        private TMP_Text _descriptionLabel;
        
        private void OnEnable()
        {
            var assetProvider = GameData.GetInstance().AssetProvider;
            var items = GameData.GetInstance().Character.Model.Items;

            for (int i = 0; i < items.Count; i++)
            {
                var model = new ItemSlotModel(items[i]);
                var slot = Instantiate(assetProvider.ItemSlotPrefab, _container);
                slot.Model = model;
                int rowIndex = (items.Count - i - 1) / 2;
                int columnIndex = i % 2;
                _slots.Add(new Vector2(columnIndex, rowIndex), slot);
            }
            
            _currentIndex = new Vector2(0, (items.Count - 1) / 2);
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
            print("Предмет");
            var commands = ((ItemSlotController)_currentSlot).Model.Item.Execute();
            GameData.GetInstance().Battle.Turn(commands);
            _panelStateController.ResetCurrentPanelState();
        }

        public override void OnCancel()
        {
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

                    _descriptionLabel.text = ((ItemSlotController)controller).Model.Item.Description;
                }
            }
        }
    }
}