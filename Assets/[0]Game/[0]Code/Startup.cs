using System;
using UnityEngine;

namespace Game
{
    public class Startup : MonoBehaviour
    {
        [SerializeField]
        private CharacterController _characterController;

        [SerializeField]
        private AudioSource _musicPlayer;

        private void Awake()
        {
            GameData.GetInstance().CommandManager = new CommandManager(this);
            GameData.GetInstance().Character = _characterController;
            GameData.GetInstance().MusicPlayer = _musicPlayer;
        }
    }
}