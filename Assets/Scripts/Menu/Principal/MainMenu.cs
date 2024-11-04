using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    public string mapSceneName = "Phsiquiatra";
    public string mainMenuSceneName = "MainMenu";

    public Animator fadeAnimator; // Referencia al Animator del efecto de fade out
    public float fadeDuration = 2.0f; // Duración del fade out

    public GameObject mainMenuUI;
    public GameObject optionsMenuUI;
    public GameObject quitMenuUI;

    public Camera menuCamera;

    [SerializeField] private AudioSource playAudioSource; // Referencia al AudioSource de la puerta
    [SerializeField] private AudioClip playSound; // Sonido de apertura de la puerta

    void Start()
    {
        menuCamera = Camera.main;
        mainMenuUI.SetActive(true);
        optionsMenuUI.SetActive(false);
        quitMenuUI.SetActive(false);
        Cursor.lockState = CursorLockMode.None; // Liberar el cursor
        Cursor.visible = true; // Hacer el cursor visible   
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ConfirmQuit();
        }
    }

    public void Play()
    {
        playAudioSource.PlayOneShot(playSound);

        fadeAnimator.SetBool("FadeOut", true);
        // mainMenuUI.SetActive(false);
        Time.timeScale = 1f;
        StartCoroutine(FadeOutAndLoadScene(mapSceneName)); // Iniciar la corrutina de fade out y carga de escena
    }

    IEnumerator FadeOutAndLoadScene(string sceneName)
    {
        yield return new WaitForSeconds(fadeDuration); // Esperar la duración del fade out
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single); // Cargar la escena del juego
    }

    public void Options()
    {
        mainMenuUI.SetActive(false);
        optionsMenuUI.SetActive(true);
    }

    public void Confirm()
    {
        optionsMenuUI.SetActive(false);
        mainMenuUI.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ConfirmQuit()
    {
        quitMenuUI.SetActive(true);
    }

    public void CancelQuit()
    {
        quitMenuUI.SetActive(false);
    }

    public void ReturnMainMenu()
    {
        Time.timeScale = 1f;
        StartCoroutine(FadeOutAndLoadScene(mainMenuSceneName)); // Iniciar la corrutina de fade out y carga de escena
    }
}


