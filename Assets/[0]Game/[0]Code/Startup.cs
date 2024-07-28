using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game
{
    public class Startup : MonoBehaviour
    {
        [SerializeField]
        private CharacterController _characterController;

        [SerializeField]
        private AudioSource _musicPlayer;

        [SerializeField]
        private PlayerInput _playerInput;
        
        [SerializeField]
        private AssetProvider _assetProvider;
                
        [SerializeField]
        private UIPanelStateController _uiPanelStateController;

        [SerializeField]
        private Battle _battle;
        
        [SerializeField]
        private Shop _shop;
        
        private void Awake()
        {
            GameData.GetInstance().CommandManager = new CommandManager();
            GameData.GetInstance().Character = _characterController;
            GameData.GetInstance().MusicPlayer = _musicPlayer;
            GameData.GetInstance().PlayerInput = _playerInput;
            GameData.GetInstance().AssetProvider = _assetProvider;
            GameData.GetInstance().UIPanelStateController = _uiPanelStateController;
            GameData.GetInstance().Battle = _battle;
            GameData.GetInstance().CoroutineRunner = this;
            GameData.GetInstance().Shop = _shop;
        }

        private void Start()
        {
            //_uiPanelStateController.SetPanelState<MainUIPanelState>();
        }
    }
}