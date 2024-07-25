namespace Game
{
    public class BattleSlotController : BaseSlotController
    {
        public BattleSlotModel Model;

        private BattleSlotView _view;

        private void Awake()
        {
            _view = GetComponent<BattleSlotView>();
        }

        private void Start()
        {
            if (Model.Config.MenuOptionType == MenuOptionType.Item && GameData.GetInstance().Character.Model.Items.Count == 0)
                Model.IsNotActive = true;
            
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