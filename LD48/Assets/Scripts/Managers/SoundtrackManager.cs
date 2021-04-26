using UnityEngine;

namespace Managers
{
    public class SoundtrackManager : MonoBehaviour
    {
        public AudioClip A1;
        public AudioClip A2;
        public AudioClip AB;
        public AudioClip B1;
        public AudioClip B2;

        private AudioSource _source;
        private int _lastAudioIndex;

        // Start is called before the first frame update
        void Start()
        {
            _source = GetComponent<AudioSource>();
            _lastAudioIndex = 0;
        }

        // Update is called once per frame
        void Update()
        {
            if (_source.isPlaying == false)
            {
                int r = Random.Range(0, 2);
                Debug.Log(r);
                switch (_lastAudioIndex)
                {
                    case 0:
                        _source.clip = A1;
                        _source.Play();
                        _lastAudioIndex = 1;
                        break;
                    case 1:
                        if (ScoreManager.Instance.GetDepthScore() >= 50)
                        {
                            r = 2;                            
                        }
                        _source.clip = (r == 0) ? A1 : (r == 1) ? A2 : AB;
                        _source.Play();
                        _lastAudioIndex = r + 1;
                        break;
                    case 2:
                        _source.clip = A1;
                        _source.Play();
                        _lastAudioIndex = 1;
                        break;
                    case 3:
                        _source.clip = B1;
                        _source.Play();
                        _lastAudioIndex = 4;
                        break;
                    case 4:
                        _source.clip = (r == 0) ? B1 : B2;
                        _source.Play();
                        _lastAudioIndex = r + 4;
                        break;
                    case 5:
                        _source.clip = (r == 0) ? B1 : B2;
                        _source.Play();
                        _lastAudioIndex = r + 4;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
