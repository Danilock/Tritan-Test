using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tritan.Utils;

namespace Tritan
{
    public class ScoreManager : Singleton<ScoreManager>
    {
        [SerializeField] private int _pointsRequiredToWin;

        private int _score;

        public int Score => _score;

        public void AddScore(int amount)
        {
            _score += amount;

            if (Score == _pointsRequiredToWin)
                EndGame();

            EventManager.TriggerEvent(new OnScorePoint(Score));
        }

        private void EndGame()
        {
            EventManager.TriggerEvent(new OnWinMatch());
        }
    }
}