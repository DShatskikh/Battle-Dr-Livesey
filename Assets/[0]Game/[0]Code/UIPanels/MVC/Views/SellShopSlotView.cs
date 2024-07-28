using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class SellShopSlotView : MonoBehaviour
    {
        [SerializeField]
        private Image _icon;

        [SerializeField]
        private TMP_Text _label;

        public void UpdateView(SellShopSlotModel model)
        {
            _label.text = model.Item.Name;

            if (model.IsSelected)
            {
                _icon.gameObject.SetActive(true);
                _icon.sprite = GameData.GetInstance().AssetProvider.GetHeartSprite(HeartType.Red);
            }
            else
            {
                _icon.gameObject.SetActive(false);
            }
        }
    }
}