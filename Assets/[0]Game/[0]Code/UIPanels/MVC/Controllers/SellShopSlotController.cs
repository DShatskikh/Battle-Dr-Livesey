namespace Game
{
    public class SellShopSlotController : BaseSlotController
    {
        public SellShopSlotModel Model;

        private SellShopSlotView _view;

        private void Awake()
        {
            _view = GetComponent<SellShopSlotView>();
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