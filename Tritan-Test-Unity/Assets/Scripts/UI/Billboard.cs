using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tritan
{
    public class Billboard : MonoBehaviour
    {
        [SerializeField] private Transform _mainCamera;

        private void LateUpdate()
        {
            transform.LookAt(transform.position + _mainCamera.forward);
        }
    }
}