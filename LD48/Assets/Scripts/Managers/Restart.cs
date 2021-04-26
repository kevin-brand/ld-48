using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class Restart : MonoBehaviour
    {
        public void OnResetButtonClick()
        {
            SceneManager.LoadScene("Main");
        }
    }
}
