namespace Game
{
    public class MercySlotController : BaseSlotController
    {
        public MercySlotModel Model;

        private MercySlotView _view;

        private void Awake()
        {
            _view = GetComponent<MercySlotView>();
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