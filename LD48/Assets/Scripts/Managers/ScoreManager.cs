using System;
using UnityEngine;

namespace Managers
{
    public class ScoreManager : MonoBehaviour
    {
        private int _killedEnemies, _maxDepth, _lootCollected, _enemyMulti, _depthMulti, _lootMulti;
        public Transform player;

        private static ScoreManager _instance;

        public static ScoreManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<ScoreManager>();
                    if (_instance == null)
                    {
                        _instance = new GameObject().AddComponent<ScoreManager>();
                    }
                }
                return _instance;
            }
        }

        private void Awake()
        {
            if (_instance != null) Destroy(this);

        }
        // Start is called before the first frame update
        void Start()
        {
            _killedEnemies = 0;
            _maxDepth = 0;
            _lootCollected = 0;
            _enemyMulti = 5;
            _depthMulti = 1;
            _lootMulti = 10;
        }

        public int GetHighscore()
        {
            return (_enemyMulti * _killedEnemies) + (_depthMulti * _maxDepth) + (_lootMulti * _lootCollected);
        }

        public int GetEnemyScore()
        {
            return (_enemyMulti * _killedEnemies);
        }

        public int GetDepthScore()
        {
            return (_depthMulti * _maxDepth);
        }

        public int GetLootScore()
        {
            return (_lootMulti * _lootCollected);
        }

        public void AddEnemyScore(int i)
        {
            _killedEnemies += i;
        }

        public void AddLootScore(int i)
        {
            _lootCollected += i;
        }


        // Update is called once per frame
        void Update()
        {
            _maxDepth = Math.Max(_maxDepth, (int)-player.position.y);
        }
    }
}
