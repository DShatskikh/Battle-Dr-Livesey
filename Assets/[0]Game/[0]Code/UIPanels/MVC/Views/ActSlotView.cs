﻿using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class ActSlotView : MonoBehaviour
    {
        [SerializeField]
        private Image _icon;

        [SerializeField]
        private TMP_Text _label;

        public void UpdateView(ActSlotModel model)
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