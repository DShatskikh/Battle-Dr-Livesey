using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class MainUIPanelState : UIPanelState
    {
        public override void Activate(bool isActive)
        {
            var textMessage = GameData.GetInstance().Battle.TextMessage;

            if (isActive)
                textMessage.StartTyping("Начался тестовый бой");
            else
                textMessage.StopTyping();

            base.Activate(isActive);
        }

        private void Start()
        {
            var assetProvider = GameData.GetInstance().AssetProvider;
            var data = assetProvider.BattleButtonConfigs;
            
            for (int i = 0; i < data.Length; i++)
            {
                var model = new BattleSlotModel(data[i]);
                var slot = Instantiate(assetProvider.BattleSlotPrefab, transform);
                slot.Model = model;
                int rowIndex = 0;
                int columnIndex = i;
                _slots.Add(new Vector2(columnIndex, rowIndex), slot);
            }
            
            _slots[_currentIndex].SetSelected(true);
        }
        
        public override void OnSubmit()
        {
            print("OnSubmit");
            
            switch (((BattleSlotController)_currentSlot).Model.Config.MenuOptionType)
            {
                case MenuOptionType.Fight:
                    print("Fight");
                    _panelStateController.SetPanelState<FightUIPanelState>();
                    break;
                case MenuOptionType.Act:
                    print("Act");
                    _panelStateController.SetPanelState<ActUIPanelState>();
                    break;
                case MenuOptionType.Item:
                    print("Item");
                    _panelStateController.SetPanelState<ItemsUIPanelState>();
                    break;
                case MenuOptionType.Mercy:
                    print("Mercy");
                    _panelStateController.SetPanelState<MercyUIPanelState>();
                    break;
            }
        }

        public override void OnCancel()
        {
            print("OnCancel");

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

            Renderer();
        }

        private void Renderer()
        { 
            GetComponent<Image>().SetAllDirty();
            Canvas.ForceUpdateCanvases();
            StartCoroutine(AwaitRenderer());
        }

        private IEnumerator AwaitRenderer()
        {
            GetComponent<Image>().SetAllDirty();
            Canvas.ForceUpdateCanvases();
            yield return null;
        }
    }
}