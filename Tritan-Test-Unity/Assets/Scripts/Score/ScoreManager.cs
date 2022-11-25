using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tritan.Utils;

namespace Tritan
{
    public class ScoreManager : Singleton<ScoreManager> 
    {
        private int _score;

        public int Score => _score;

        public void AddScore(int amount)
        {
            _score += amount;

            EventManager.TriggerEvent(new OnScorePoint(Score));
        }
    }
}