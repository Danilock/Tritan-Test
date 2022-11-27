using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

namespace Tritan
{
    public class UIScoreText : MonoBehaviour, IEventListener<OnScorePoint>, IEventListener<OnLevelRestart>
    {
        [SerializeField] private TMP_Text _scoreTMP;

        [Header("Tween/Jump")]
        [SerializeField] private float _jumpPower = 10f;
        [SerializeField] private int _numJumps = 2;

        [Header("Tween/PunchScale")]
        [SerializeField] private Vector3 _punchScale;
        [SerializeField] private float _duration;

        private bool _canTriggerTween = true;

        private Tween PunchTween;

        private void OnEnable()
        {
            this.StartListening<OnScorePoint>();
            this.StartListening<OnLevelRestart>();
        }

        private void OnDisable()
        {
            this.StopListening<OnScorePoint>();
            this.StopListening<OnLevelRestart>();
        }

        public void OnTriggerEvent(OnScorePoint data)
        {
            _scoreTMP.text = data.CurrentScore.ToString();

            DOTweenSequence();
        }

        private void DOTweenSequence()
        {
            if (PunchTween != null)
            {
                if (PunchTween.IsPlaying())
                {
                    PunchTween.Complete();
                }
            }

            PunchTween = transform.DOPunchScale(_punchScale, _duration);
        }

        public void OnTriggerEvent(OnLevelRestart data)
        {
            _scoreTMP.text = "0";
        }
    }
}