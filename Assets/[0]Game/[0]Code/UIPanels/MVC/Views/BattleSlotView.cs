using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class BattleSlotView : MonoBehaviour
    {
        [SerializeField]
        private Image _icon;

        [SerializeField]
        private TMP_Text _label;

        private Image _frame;

        private void Awake()
        {
            _frame = GetComponent<Image>();
        }

        public void UpdateView(BattleSlotModel model)
        {
            _label.text = model.Config.Label;

            if (model.IsSelected)
            {
                _label.gameObject.SetActive(true);
                _label.color = Color.yellow;
                _frame.color = Color.yellow;
                _icon.color = Color.white;
                _icon.sprite = GameData.GetInstance().AssetProvider.GetHeartSprite(GameData.GetInstance().Battle.HeartType);
            }
            else
            {
                _label.gameObject.SetActive(false);
                _label.color = new Color(1, 0.5f, 0);
                _frame.color = new Color(1, 0.5f, 0);
                _icon.color = new Color(1, 0.5f, 0);
                _icon.sprite = model.Config.Icon;
            }
            
            if (model.IsNotActive)
            {
                _label.color = Color.grey;
                _frame.color = Color.grey;
                _icon.color = Color.grey;
            }
        }
    }
}