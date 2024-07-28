namespace Game
{
    public class SelectTalkShopSlotController : BaseSlotController
    {
        public SelectTalkShopSlotModel Model;

        private SelectTalkShopSlotView _view;

        private void Awake()
        {
            _view = GetComponent<SelectTalkShopSlotView>();
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