using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class GameOverSlotView : MonoBehaviour
    {
        [SerializeField]
        private Image _icon;

        [SerializeField]
        private TMP_Text _label;

        public void UpdateView(GameOverSlotModel model)
        {
            _label.text = model.Config.Name;

            if (model.IsSelected)
            {
                _icon.gameObject.SetActive(true);
                _icon.sprite = GameData.GetInstance().AssetProvider.GetHeartSprite(GameData.GetInstance().Battle.HeartType);
            }
            else
            {
                _icon.gameObject.SetActive(false);
            }
        }
    }
}