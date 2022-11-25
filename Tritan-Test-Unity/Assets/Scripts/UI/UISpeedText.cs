using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Tritan.Player;
using DG.Tweening;

namespace Tritan
{
    public class UISpeedText : MonoBehaviour, IEventListener<SpeedIncrease>, IEventListener<SpeedDecrease>
    {
        [SerializeField] private TMP_Text _speedTMP;
        [SerializeField] private TMP_Text _speedTMPShadow;

        [Header("Tween")]
        [SerializeField] private Vector3 _punchScale;
        [SerializeField] private Vector3 _moveOffset;
        [SerializeField] private float _duration;
        private Vector3 _initialPosition;
        private bool _canExecuteTween = true;

        private void Start()
        {
            _speedTMP.text = PlayerController.Instance.InitialWalkSpeed.ToString();

            _initialPosition = _speedTMPShadow.transform.position;
        }

        private void OnEnable()
        {
            this.StartListening<SpeedIncrease>();
            this.StartListening<SpeedDecrease>();
        }

        private void OnDisable()
        {

            this.StopListening<SpeedIncrease>();
            this.StopListening<SpeedDecrease>();
        }

        public void OnTriggerEvent(SpeedIncrease data)
        {
            InitText(
                data.AmountIncreased.ToString(),
                data.CurrentSpeed.ToString(),
                Color.green);
        }

        public void OnTriggerEvent(SpeedDecrease data)
        {
            InitText(
                data.AmountDecreased.ToString(),
                data.CurrentSpeed.ToString(),
                Color.red);
        }

        private void InitText(string increasedSpeed, string currentSpeed, Color color)
        {
            if (!_canExecuteTween) return;

            _canExecuteTween = false;

            _speedTMP.text = currentSpeed;
            _speedTMP.transform.DOScale(_punchScale, _duration);

            _speedTMPShadow.text = increasedSpeed;
            _speedTMPShadow.color = color;
            _speedTMPShadow.transform.position = _initialPosition;
            _speedTMPShadow.DOFade(1f, 0f);
            _speedTMPShadow.transform.DOMoveY(_speedTMPShadow.transform.position.y + _moveOffset.y, _duration);
            _speedTMPShadow.DOFade(0f, _duration).OnComplete(() =>
            {
                _canExecuteTween = true;
            });
            
        }
    }
}