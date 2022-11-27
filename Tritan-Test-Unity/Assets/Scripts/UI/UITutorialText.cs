using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

namespace Tritan
{
    public class UITutorialText : MonoBehaviour
    {
        [Header("Tutorial Texte Dependencies")]
        [SerializeField, TextArea] private string _textToShow;
        [SerializeField] private TMP_Text _tutorialTMP;
        [SerializeField] private float _secondsBetweenLetter = .2f;

        [SerializeField] private Transform _endPosition;

        private Vector3 _startPosition;

        private void Start()
        {
            _startPosition = transform.position;

            StartCoroutine(ShowText_CO());
        }

        private IEnumerator ShowText_CO()
        {
            yield return new WaitForSeconds(2f);

            transform.DOMove(_endPosition.position, .5f);

            yield return new WaitForSecondsRealtime(6f);

            transform.DOMove(_startPosition, .5f);
        }
    }
}