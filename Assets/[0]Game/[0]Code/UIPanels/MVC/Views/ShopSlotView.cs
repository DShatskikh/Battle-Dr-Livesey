using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class ShopSlotView : MonoBehaviour
    {
        [SerializeField]
        private Image _icon;

        [SerializeField]
        private TMP_Text _label;

        public void UpdateView(ShopSlotModel model)
        {
            _label.text = model.Config.Name;

            if (model.Config.ShopMenuOptionType == ShopMenuOptionType.Sell &&
                GameData.GetInstance().Character.Model.Items.Count == 0)
            {
                _label.color = Color.gray;
            }
            else
            {
                _label.color = Color.white;
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