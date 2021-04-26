using System;
using Bombs;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Managers
{
    public class BombDisplayManager : MonoBehaviour
    {
        public BombBag bombBag;
        public TMP_Text bombOneNameText;
        public TMP_Text bombTwoNameText;
        public UnityEvent updatedBomb1;
        public UnityEvent updatedBomb2;

        public TMP_Text bombOneCounterText;
        public TMP_Text bombTwoCounterText;
        
        private void Start()
        {
            if (bombBag == null)
                Debug.LogError("THERE'S NO BOMB BAG REFERENCE IN THE INSPECTOR!");
        }

        private void Update()
        {
            BombSlot bOne = bombBag.GetSlot(0);
            BombSlot bTwo = bombBag.GetSlot(1);
            
            bombOneNameText.text = bOne.Bomb.bombName;
            bombTwoNameText.text = bTwo.Bomb.bombName;

            if (bOne.Bomb.isLimited)
            {
                if (bombOneCounterText.text != bOne.held.ToString())
                {
                    updatedBomb1.Invoke();
                }
                bombOneCounterText.text = bOne.held.ToString();
            }
            else
            {
                bombOneCounterText.text = "∞";
            }
            
            if (bTwo.Bomb.isLimited)
            {
                if (bombTwoCounterText.text != bTwo.held.ToString())
                {
                    updatedBomb2.Invoke();
                }
                bombTwoCounterText.text = bTwo.held.ToString();
            }
            else
            {
                bombTwoCounterText.text = "∞";
            }


        }
    }
}
