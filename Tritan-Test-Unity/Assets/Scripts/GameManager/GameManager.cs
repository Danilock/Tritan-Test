using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tritan.Utils;
using UnityEngine.SceneManagement;
using System;

namespace Tritan
{
    public class GameManager : Singleton<GameManager>
    {
        public void LoadScene(string sceneName, Action OnSceneLoadComplete)
        {
            StartCoroutine(LoadScene_Async(sceneName, () => OnSceneLoadComplete?.Invoke())) ;
        }

        private IEnumerator LoadScene_Async(string sceneName, Action action)
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

            while (!asyncLoad.isDone)
            {
                yield return null;
            }

            action?.Invoke();
        }

        public void RestartCurrentScene(Action OnSceneLoadComplete)
        {
            LoadScene(SceneManager.GetActiveScene().name, () => OnSceneLoadComplete?.Invoke());
        }
    }
}