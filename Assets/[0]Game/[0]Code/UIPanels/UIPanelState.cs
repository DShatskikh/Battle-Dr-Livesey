using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game
{
    public abstract class UIPanelState : MonoBehaviour
    {
        private PlayerInput _input;
        private InputAction _submitAction;
        private InputAction _cancelAction;
        private InputAction _moveAction;

        protected Dictionary<Vector2, BaseSlotController> _slots = new Dictionary<Vector2, BaseSlotController>();
        protected Vector2 _currentIndex;
        protected UIPanelStateController _panelStateController;
        
        protected BaseSlotController _currentSlot => _slots[_currentIndex];

        private void Awake()
        {
            _input = GameData.GetInstance().PlayerInput;
            _submitAction = _input.actions["Submit"];
            _cancelAction = _input.actions["Cancel"];
            _moveAction = _input.actions["Move"];

            _panelStateController = GameData.GetInstance().UIPanelStateController;
        }

        public virtual void Activate(bool isActive)
        {
            if (isActive)
            {
                gameObject.SetActive(true);
                Subscribe();
            }
            else
            {
                gameObject.SetActive(false);
                Unsubscribe();
            }
        }
        
        private void Subscribe()
        {
            _submitAction.performed += Submit;
            _cancelAction.performed += Cancel;
            _moveAction.performed += OnSlotIndexChanged;
        }

        private void Unsubscribe()
        {
            _submitAction.performed -= Submit;
            _cancelAction.performed -= Cancel;
            _moveAction.performed -= OnSlotIndexChanged;
        }

        private void Submit(InputAction.CallbackContext context) => OnSubmit();
        private void Cancel(InputAction.CallbackContext context) => OnCancel();
        private void OnSlotIndexChanged(InputAction.CallbackContext context) => OnSlotIndexChanged(context.ReadValue<Vector2>());

        public abstract void OnSubmit();
        public abstract void OnCancel();

        public virtual void OnSlotIndexChanged(Vector2 direction)
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