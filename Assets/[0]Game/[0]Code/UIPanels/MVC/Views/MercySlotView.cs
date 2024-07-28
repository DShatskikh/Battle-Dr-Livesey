using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class MercySlotView : MonoBehaviour
    {
        [SerializeField]
        private Image _icon;

        [SerializeField]
        private TMP_Text _label;

        public void UpdateView(MercySlotModel model)
        {
            _label.text = model.Config.Name;
            _label.color = model.IsMercy ? Color.yellow : Color.white;

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