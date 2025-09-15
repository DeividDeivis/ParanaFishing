using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugController : MonoBehaviour
{
    [SerializeField] private float pressTime = 2f;
    private Coroutine counter;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InputManager._.StartReadInput("Reload", ReloadGame);
#if UNITY_STANDALONE_WIN
        InputManager._.StartReadInput("Quit", ExitGame);
#endif
    }

    private void ReloadGame(bool press) 
    {
        if (press)
            counter = StartCoroutine(Count(ReloadGameScene));
        else
            StopCoroutine(counter);    
    }

    private void ExitGame(bool press)
    {
        if (press)
            counter = StartCoroutine(Count(() => Application.Quit()));
        else
            StopCoroutine(counter);
    }

    private IEnumerator Count(Action onComplete) 
    {
        float currentTime = 0;
        while (currentTime < pressTime) 
        {
            currentTime += Time.deltaTime;
            yield return null;
        }
        onComplete?.Invoke();
    }

    private void ReloadGameScene() 
    {
        InputManager._.StopReadAllInput();
        AudioManager.instance.StopBGMusic();
        StartCoroutine(ReloadAsyncScene());
    }

    private IEnumerator ReloadAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(0);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
