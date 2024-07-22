using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class FightSlotView : MonoBehaviour
    {
        [SerializeField]
        private Image _icon;

        [SerializeField]
        private TMP_Text _label;

        public void UpdateView(FightSlotModel model)
        {
            _label.text = model.Enemy.Name;

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