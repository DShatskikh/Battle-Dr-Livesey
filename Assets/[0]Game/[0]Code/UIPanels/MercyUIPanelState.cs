using UnityEngine;

namespace Game
{
    public class MercyUIPanelState : UIPanelState
    {
        private void Start()
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
                    GameData.GetInstance().Battle.SelectedEnemy.Mercy(MercyOptionType.Run);
                    //_panelStateController.SetPanelState<UIPanelStateBag>();
                    break;
            }
        }

        public override void OnCancel()
        {
            _panelStateController.SetPanelState<MercySelectUIPanelState>();
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