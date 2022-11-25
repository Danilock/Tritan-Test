using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tritan.Utils;
using UnityEngine.Events;

namespace Tritan.Player
{
    public class PlayerInput : Singleton<PlayerInput>
    {

        private Vector3 _lastValidPosition;
    
        public Vector3 GetWorldHitPoint(LayerMask layers)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, 1000, layers))
            {
                _lastValidPosition = hit.point;

                return hit.point;
            }

            return _lastValidPosition;
        }        
    }
}