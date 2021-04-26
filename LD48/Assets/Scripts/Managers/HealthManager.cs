using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class HealthManager : MonoBehaviour
    {
        public ScoreManager ScoreManager;
        public Image Heart1, Heart2, Heart3;
        public Sprite Full, Half, Empty;
        public Character.CharacterHealth Player;
        public GameObject gameOverScreen;
        public TMPro.TMP_Text[] scores;

        private int _lastHealth = 6;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (_lastHealth != Player.Health)
            {
                _lastHealth = Player.Health;
                Heart1.sprite = (_lastHealth <= 0) ? Empty : (_lastHealth == 1) ? Half : Full;
                Heart2.sprite = (_lastHealth <= 2) ? Empty : (_lastHealth == 3) ? Half : Full;
                Heart3.sprite = (_lastHealth <= 4) ? Empty : (_lastHealth == 5) ? Half : Full;

                if (_lastHealth <= 0)
                {
                    _showGameOverScreen();
                }
            }
        }

        private void _showGameOverScreen()
        {
            gameOverScreen.SetActive(true);
            try
            {
                scores[0].text = ScoreManager.Instance.GetHighscore().ToString();
                scores[1].text = ScoreManager.Instance.GetEnemyScore().ToString();
                scores[2].text = ScoreManager.Instance.GetLootScore().ToString();
                scores[3].text = ScoreManager.Instance.GetDepthScore().ToString();
            } catch (System.NullReferenceException) { }
        }
    }
}
