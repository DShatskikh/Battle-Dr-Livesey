namespace Game
{
    public class ItemSlotController : BaseSlotController
    {
        public ItemSlotModel Model;

        private ItemSlotView _view;

        private void Awake()
        {
            _view = GetComponent<ItemSlotView>();
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