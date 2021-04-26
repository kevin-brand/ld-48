using System;
using Bombs;
using TMPro;
using UnityEngine;

namespace Managers
{
    public class BombDisplayManager : MonoBehaviour
    {
        public BombBag bombBag;
        public TMP_Text bombOneNameText;
        public TMP_Text bombTwoNameText;
        
        public TMP_Text bombOneCounterText;
        public TMP_Text bombTwoCounterText;
        
        private void Start()
        {
            if (bombBag == null)
                Debug.LogError("THERE'S NO BOMB BAG REFERENCE IN THE INSPECTOR!");
        }

        private void FixedUpdate()
        {
            bombOneNameText.text = bombBag.GetSlot(0).Bomb.bombName;
            bombTwoNameText.text = bombBag.GetSlot(1).Bomb.bombName;

            bombOneCounterText.text = bombBag.GetSlot(0).held.ToString();
            bombTwoCounterText.text = bombBag.GetSlot(1).held.ToString();
        }
    }
}
