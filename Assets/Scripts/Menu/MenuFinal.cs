using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuFinal : MonoBehaviour
{
    public string mainMenuSceneName = "MainMenu";



    public GameObject finalMenuUI;

    public Camera menuCamera;


    void Start()
    {
        menuCamera = Camera.main;
        finalMenuUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None; // Liberar el cursor
        Cursor.visible = true; // Hacer el cursor visible   
    }

    void Update()
    {

    }

    public void ReturnMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenuSceneName, LoadSceneMode.Single);
    }
}


