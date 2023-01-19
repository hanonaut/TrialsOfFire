using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    [SerializeField] private Animator fadeAnimator; // for fading in and out of scenes.
    public bool paused = false;
    public bool mainMenu = false;
    [SerializeField] private Animator pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        StartCoroutine(IEFadeSceneLoad());
        
        pauseMenu.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (!mainMenu && Input.GetKeyDown(KeyCode.Escape))
        {
            if(paused) UnPauseGame();
            else PauseGame();
        }
    }

    public void FreezeGame()
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        //lock the player.
    }

    public void UnFreezeGame()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        //unlcok the player
    }

    public void PauseGame()
    {
        paused = true;
        pauseMenu.gameObject.SetActive(true);
        FreezeGame();
        pauseMenu.SetTrigger("FadeOut");
        StartCoroutine(SetCanvas());
    }

    IEnumerator SetCanvas()
    {
        yield return new WaitForSecondsRealtime(0.4f);
        pauseMenu.GetComponent<CanvasGroup>().alpha = 1f;
    }
    public void UnPauseGame()
    {
        StartCoroutine(IEUnPauseGame());
    }

    IEnumerator IEUnPauseGame()
    {
        pauseMenu.SetTrigger("FadeIn");
        yield return new WaitForSecondsRealtime(0.4f);
        paused = false;
        pauseMenu.gameObject.SetActive(false);
        UnFreezeGame();
    }


    public void LoadScene(int buildIndex)
    {
        StartCoroutine(IELoadSceneWithFade(buildIndex));
    }

    public void ReloadScene()
    {
        LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public IEnumerator IEFadeSceneLoad()
    {
        fadeAnimator.gameObject.SetActive(true);
        fadeAnimator.SetTrigger("FadeIn");
        yield return new WaitForSecondsRealtime(0.44f);
        fadeAnimator.gameObject.SetActive(false);
    }

    public IEnumerator IELoadSceneWithFade(int buildIndex)
    {
        fadeAnimator.gameObject.SetActive(true);
        fadeAnimator.SetTrigger("FadeOut");
        yield return new WaitForSecondsRealtime(0.44f);
        SceneManager.LoadScene(buildIndex);

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
