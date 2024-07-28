using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class BuyShopSlotView : MonoBehaviour
    {
        [SerializeField]
        private Image _icon;

        [SerializeField]
        private TMP_Text _label;

        public void UpdateView(BuyShopSlotModel model)
        {
            var item = model.Config.Item;

            if (model.Config.IsSold)
            {
                _label.color = Color.grey;
                _label.text = "(Пусто)";
            }
            else
            {
                _label.color = Color.white;
                _label.text = $"{item.Price}G-{item.Name}";
            }

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