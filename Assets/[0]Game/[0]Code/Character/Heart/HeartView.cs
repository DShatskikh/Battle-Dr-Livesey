using UnityEngine;

namespace Game
{
    public class HeartView : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _shield;
        
        private HeartModel _model;
        private SpriteRenderer _spriteRenderer;

        public void SetModel(HeartModel model)
        {
            _model = model;
            _model.HeartTypeChanged += OnHeartTypeChanged;
            _model.IsShieldChanged += OnIsShieldChanged;

            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void OnHeartTypeChanged()
        {
            _spriteRenderer.sprite = GameData.GetInstance().AssetProvider.GetHeartSprite(GameData.GetInstance().Battle.HeartType);
        }

        private void OnIsShieldChanged(bool isActive)
        {
            _shield.gameObject.SetActive(isActive);
        }
    }
}