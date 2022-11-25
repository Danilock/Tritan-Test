using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tritan
{
    public interface IEventListener<T>
    {
        public void OnTriggerEvent(T data);
    }
}