using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tritan 
{
    public class PointPickerListener : MonoBehaviour
    {
        [SerializeField] private Point _pointToListenOnPick;

        private void OnEnable() => _pointToListenOnPick.OnPick += OnCollectiblePick;

        private void OnDisable() => _pointToListenOnPick.OnPick -= OnCollectiblePick;

        private void OnCollectiblePick(Collectible collectible)
        {
            Point point = collectible as Point;

            ScoreManager.Instance.AddScore(point.PointAmountToGive);
        }
    }
}