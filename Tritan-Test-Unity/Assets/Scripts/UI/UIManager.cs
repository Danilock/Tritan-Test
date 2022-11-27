using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;
using Tritan.Utils;

namespace Tritan
{
    public class UIManager : Singleton<UIManager>, IEventListener<OnWinMatch>
    {
        [SerializeField] private CanvasGroup _mainHUDCanvasGroup, _winScreenCanvasGroup;
        [SerializeField] private Transform _winPanelTransform;
        [SerializeField] private Transform _winPanelEndPosition;

        [Header("Fade")]
        [SerializeField] private Image FadeScreen;

        private Vector3 _winPanelStartPosition;

        private void Start()
        {
            _winPanelStartPosition = _winPanelTransform.position;
        }

        private void OnEnable()
        {
            this.StartListening<OnWinMatch>();
        }

        private void OnDisable()
        {
            this.StopListening<OnWinMatch>();
        }

        public void OnTriggerEvent(OnWinMatch data)
        {
            HideMainHUD();
        }

        private void HideMainHUD()
        {
            _mainHUDCanvasGroup.DOFade(0f, 1f).SetUpdate(true).OnComplete(() =>
            {
                ShowWinScreen();
            });
        }

        private void ShowWinScreen()
        {
            _winScreenCanvasGroup.DOFade(1f, 1f).SetUpdate(true).OnComplete(() =>
            {
                _winPanelTransform.DOMove(_winPanelEndPosition.position, 1f).SetUpdate(true);
            });

            _winScreenCanvasGroup.blocksRaycasts = true;
            _mainHUDCanvasGroup.blocksRaycasts = false;
        }

        public void RestartScene()
        {
            _winScreenCanvasGroup.DOFade(0f, 1f).SetUpdate(true).OnComplete(() =>
            {
                DoFade(0f, 1f, Color.black, 1f, () =>
                {
                    GameManager.Instance.RestartCurrentScene(() => DoFade(1f, 0f, Color.black, 1f, () =>
                    {
                        _mainHUDCanvasGroup.DOFade(1f, 1f).SetUpdate(true).OnComplete(() =>
                        {
                            Time.timeScale = 1f;
                            _mainHUDCanvasGroup.blocksRaycasts = true;
                            _winScreenCanvasGroup.blocksRaycasts = false;
                        });
                    }));
                });
            });

            EventManager.TriggerEvent(new OnLevelRestart());
        }

        public void QuitGame()
        {
            DoFade(0f, 1f, Color.black, 1f, () => Application.Quit());
        }

        public void DoFade(float from, float to, Color color, float duration = 1f, Action OnFadeComplete = null)
        {
            FadeScreen.color = color;

            FadeScreen.DOFade(from, 0f).SetUpdate(true);

            FadeScreen.DOFade(to, duration).SetUpdate(true).OnComplete(() => OnFadeComplete?.Invoke());
        }
    }
}