namespace Game
{
    public class ShopSlotController : BaseSlotController
    {
        public ShopSlotModel Model;

        private ShopSlotView _view;

        private void Awake()
        {
            _view = GetComponent<ShopSlotView>();
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