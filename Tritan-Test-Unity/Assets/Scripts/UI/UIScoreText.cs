using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

namespace Tritan
{
    public class UIScoreText : MonoBehaviour, IEventListener<OnScorePoint>
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

        private void OnEnable() => this.StartListening<OnScorePoint>();

        private void OnDisable() => this.StopListening<OnScorePoint>();

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
    }
}