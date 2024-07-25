using System;
using System.Collections;
using System.Collections.Generic;
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

        private void OnEnable()
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

        private void OnDisable()
        {
            foreach (var slot in _slots) 
                Destroy(slot.Value.gameObject);

            _slots = new Dictionary<Vector2, BaseSlotController>();
        }

        public override void OnSubmit()
        {
            switch (((BattleSlotController)_currentSlot).Model.Config.MenuOptionType)
            {
                case MenuOptionType.Fight:
                    _panelStateController.SetPanelState<FightSelectUIPanelState>();
                    break;
                case MenuOptionType.Act:
                    if (GameData.GetInstance().Battle.Enemies.Length != 1)
                    {
                        _panelStateController.SetPanelState<ActSelectUIPanelState>();   
                    }
                    else
                    {
                        GameData.GetInstance().Battle.SelectedEnemy = GameData.GetInstance().Battle.Enemies[0];
                        _panelStateController.SetPanelState<ActUIPanelState>();
                    }
                    break;
                case MenuOptionType.Item:
                    _panelStateController.SetPanelState<ItemsUIPanelState>();
                    break;
                case MenuOptionType.Mercy:
                    if (GameData.GetInstance().Battle.Enemies.Length != 1)
                    {
                        _panelStateController.SetPanelState<MercySelectUIPanelState>();   
                    }
                    else
                    {
                        GameData.GetInstance().Battle.SelectedEnemy = GameData.GetInstance().Battle.Enemies[0];
                        _panelStateController.SetPanelState<MercyUIPanelState>();
                    }
                    break;
            }
        }

        public override void OnCancel() { }

        public override void OnSlotIndexChanged(Vector2 direction)
        {
            var newIndex = _currentIndex + direction;
            
            if (_slots.TryGetValue(newIndex, out var controller) && controller != null)
            {
                if (((BattleSlotController)controller).Model.IsNotActive)
                {
                    newIndex = _currentIndex + direction * 2;

                    if (_slots.TryGetValue(newIndex, out var controller1) && controller1 != null)
                    {
                        controller1.SetSelected(true);
                        var oldVM = _slots[_currentIndex];
                        oldVM.SetSelected(false);
                        _currentIndex = newIndex;
                    }
                }
                else
                {
                    controller.SetSelected(true);
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