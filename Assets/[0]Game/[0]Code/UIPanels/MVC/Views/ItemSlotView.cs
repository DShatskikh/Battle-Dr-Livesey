using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class ItemSlotView : MonoBehaviour
    {
        [SerializeField]
        private Image _icon;

        [SerializeField]
        private TMP_Text _label;

        public void UpdateView(ItemSlotModel model)
        {
            _label.text = model.Name;

            if (model.IsSelected)
            {
                _icon.gameObject.SetActive(true);
                _icon.sprite = GameData.GetInstance().Battle.GetHeartSprite();
            }
            else
            {
                _icon.gameObject.SetActive(false);
            }
        }
    }
}