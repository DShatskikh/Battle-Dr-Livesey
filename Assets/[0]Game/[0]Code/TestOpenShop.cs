using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class TestOpenShop : MonoBehaviour
    {
        [SerializeField]
        private List<Item> _items;
        
        private IEnumerator Start()
        {
            yield return null;
            var openShop = new OpenShopCommand();
            GameData.GetInstance().CommandManager.StartCommands(new List<Command>() {openShop});
            
            GameData.GetInstance().Character.Model.Items = _items;
        }
    }
}