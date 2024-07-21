using UnityEngine;

namespace Game
{
    public class GameData : Singleton<GameData>
    {
        public CommandManager CommandManager;
        public CharacterController Character;
        public AudioSource MusicPlayer;
    }
}