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
            BombSlot bOne = bombBag.GetSlot(0);
            BombSlot bTwo = bombBag.GetSlot(1);
            
            bombOneNameText.text = bOne.Bomb.bombName;
            bombTwoNameText.text = bTwo.Bomb.bombName;

            if (bOne.Bomb.isLimited)
                bombOneCounterText.text = bOne.held.ToString();
            else
            {
                bombOneCounterText.text = "∞";
            }
            
            if (bTwo.Bomb.isLimited)
                bombTwoCounterText.text = bTwo.held.ToString();
            else
            {
                bombTwoCounterText.text = "∞";
            }
        }
    }
}
