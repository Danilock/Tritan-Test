using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tritan.Player;
using DG.Tweening;
using UnityEngine.EventSystems;

namespace Tritan.UI
{
    public class UISpeedButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private float _amount;

        [Header("Tween")]
        [SerializeField] private Vector3 _scaleOnTouchPress;
        [SerializeField] private Vector3 _scaleOnTouchRelease;
        [SerializeField] private float _duration;

        public void IncreaseSpeed() => PlayerController.Instance.IncreaseSpeed(_amount);
        public void DecreaseSpeed() => PlayerController.Instance.DecreaseSpeed(_amount);

        public void OnPointerEnter(PointerEventData eventData)
        {
            transform.DOScale(_scaleOnTouchPress, _duration);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            transform.DOScale(_scaleOnTouchRelease, _duration);
        }
    }
}
