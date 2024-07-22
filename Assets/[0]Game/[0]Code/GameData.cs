using UnityEngine;
using UnityEngine.InputSystem;

namespace Game
{
    public class GameData : Singleton<GameData>
    {
        public CommandManager CommandManager;
        public CharacterController Character;
        public AudioSource MusicPlayer;
        public PlayerInput PlayerInput;
        public AssetProvider AssetProvider;
        public UIPanelStateController UIPanelStateController;
        public Battle Battle;
        public MonoBehaviour CoroutineRunner;
    }
}