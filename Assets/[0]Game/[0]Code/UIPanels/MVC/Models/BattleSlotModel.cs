using Unity.VisualScripting;

namespace Game
{
    public class BattleSlotModel
    {
        public BattleSlotConfig Config => _config;
        
        private BattleSlotConfig _config;
        
        public BattleSlotModel(BattleSlotConfig config)
        {
            _config = config;
        }
        
        public bool IsSelected { get; set; }
    }
}