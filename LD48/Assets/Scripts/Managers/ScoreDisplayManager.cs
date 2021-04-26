using UnityEngine;
using UnityEngine.Events;

namespace Managers
{
    public class ScoreDisplayManager : MonoBehaviour
    {
        public ScoreManager ScoreManager;
        public TMPro.TMP_Text textMeshProGUI;

        public UnityEvent scoreIncreased;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            if (textMeshProGUI.text != ScoreManager.Instance.GetHighscore().ToString())
            {
                scoreIncreased.Invoke();
            }
            textMeshProGUI.text = ScoreManager.Instance.GetHighscore().ToString();
        }
    }
}
