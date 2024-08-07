﻿namespace Game
{
    public class ActSlotController : BaseSlotController
    {
        public ActSlotModel Model;

        private ActSlotView _view;

        private void Awake()
        {
            _view = GetComponent<ActSlotView>();
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