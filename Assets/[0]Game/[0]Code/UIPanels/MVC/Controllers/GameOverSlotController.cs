namespace Game
{
    public class GameOverSlotController : BaseSlotController
    {
        public GameOverSlotModel Model;

        private GameOverSlotView _view;

        private void Awake()
        {
            _view = GetComponent<GameOverSlotView>();
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