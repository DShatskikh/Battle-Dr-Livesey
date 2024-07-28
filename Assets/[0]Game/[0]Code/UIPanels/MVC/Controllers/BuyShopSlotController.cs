namespace Game
{
    public class BuyShopSlotController : BaseSlotController
    {
        public BuyShopSlotModel Model;

        private BuyShopSlotView _view;

        private void Awake()
        {
            _view = GetComponent<BuyShopSlotView>();
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