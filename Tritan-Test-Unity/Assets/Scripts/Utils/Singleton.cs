using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tritan.Utils
{
    public class Singleton<T> : MonoBehaviour where T : Component
    {
        protected static T _instance;
        public static T Instance
        {
            get { return _instance; }
            protected set { _instance = value; }
        }

        [SerializeField] private bool _liveAcrossScenes = true;

        protected virtual void Awake()
        {
            if (_instance != null && _instance != this)
                Destroy(this.gameObject);
            else
            {
                _instance = this as T;

                if (_liveAcrossScenes) DontDestroyOnLoad(this.gameObject);
            }
        }
    }
}