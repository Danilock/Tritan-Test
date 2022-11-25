using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tritan
{
    public class Point : Collectible
    {
        [SerializeField] private int _pointAmountToGive = 1;

        public int PointAmountToGive => _pointAmountToGive;

        public override void Pick()
        {
            base.Pick();
        
            this.gameObject.SetActive(false);
        }

        private void OnMouseDown()
        {
            Pick();
        }
    }
}