using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public string mainMenuSceneName = "MainMenu";
    public string inGameSceneName = "Phsiquiatra";

    public FirstPersonMovement movementScript; // Referencia al script de movimiento del jugador
    public FirstPersonLook lookScript; // Referencia al script de mirada del jugador
    public GameObject pauseMenuUI; // Referencia al objeto del Canvas que contiene el menú de pausa
    public Transform player; // Referencia al objeto del jugador
    public Camera playerCamera;

    public Rigidbody playerRigidbody;

    private bool isPaused = false;

    public RigidbodyConstraints originalConstraints;


    void Start()
    {
        playerCamera = Camera.main;
        pauseMenuUI.SetActive(false);
        originalConstraints = playerRigidbody.constraints;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
                Cursor.lockState = CursorLockMode.Locked; // Bloquear el cursor de nuevo
                Cursor.visible = false; // Ocultar el cursor
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // Reanudar el tiempo normal del juego
        isPaused = false;
        movementScript.enabled = true; // Reactivar el movimiento del jugador
        lookScript.enabled = true; // Reactivar la rotación de la cámara del jugador
        Cursor.lockState = CursorLockMode.Locked; // Bloquear el cursor de nuevo
        Cursor.visible = false; // Ocultar el cursor
        playerRigidbody.constraints = originalConstraints;
    }

    void Pause()
    {
        movementScript.enabled = false; // Desactivar el movimiento del jugador
        lookScript.enabled = false; // Desactivar la rotación de la cámara del jugador
        Cursor.lockState = CursorLockMode.None; // Liberar el cursor para inspección
        Cursor.visible = true; // Hacer el cursor visible
        playerRigidbody.constraints = RigidbodyConstraints.FreezeAll;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // Pausar el tiempo del juego
        isPaused = true;
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenuSceneName, LoadSceneMode.Single);
    }
}