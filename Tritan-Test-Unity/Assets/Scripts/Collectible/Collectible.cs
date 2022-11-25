using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Tritan
{   
    /// <summary>
    /// Base class for Pickeable objects.
    /// </summary>
    public class Collectible : MonoBehaviour
    {
        public event UnityAction<Collectible> OnPick;

        public virtual void Pick()
        {
            OnPick?.Invoke(this);
        }
    }
}