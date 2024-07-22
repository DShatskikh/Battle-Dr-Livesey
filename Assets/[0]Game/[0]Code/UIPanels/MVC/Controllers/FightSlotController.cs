using System;
using UnityEngine;

namespace Game
{
    public class FightSlotController : BaseSlotController
    {
        public FightSlotModel Model;

        private FightSlotView _view;

        private void Awake()
        {
            _view = GetComponent<FightSlotView>();
        }

        private void Start()
        {
            UpdateView();
        }

        public override void SetSelected(bool isSelected)
        {
            Model.IsSelected = isSelected;
            UpdateView();
        }
        
        private void UpdateView()
        {
            _view.UpdateView(Model);
        }
    }
}