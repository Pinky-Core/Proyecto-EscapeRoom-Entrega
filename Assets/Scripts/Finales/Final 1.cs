using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Final1 : MonoBehaviour
{
    public float interactionDistance = 1f;
    public string escapeSceneName = "EscapeScene"; // Nombre de la escena de escape
    public Animator doorAnimator; // Asigna el Animator de la puerta en el inspector
    public string doorOpenAnimationName = "ExitDoorOpen"; // Nombre de la animación de apertura de la puerta

    private bool hasCard = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteract();
        }
    }

    void TryInteract()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            if (hit.collider.CompareTag("Card"))
            {
                CollectCard(hit.collider.gameObject);
            }
            else if (hit.collider.CompareTag("ExitKeypad"))
            {
                TryOpenDoor(hit.collider.gameObject);
            }
        }
    }

    void CollectCard(GameObject card)
    {
        // Realiza la acción de recoger la tarjeta
        hasCard = true;
        Destroy(card); // Eliminar la tarjeta del juego
    }

    void TryOpenDoor(GameObject keypad)
    {
        if (hasCard)
        {
            // Reproduce la animación de apertura de la puerta
            if (doorAnimator != null)
            {
                doorAnimator.Play(doorOpenAnimationName);
                StartCoroutine(WaitForDoorToOpen());
            }
            else
            {
                Debug.LogError("Animator de la puerta no asignado.");
            }
        }
        else
        {
            Debug.Log("Necesitas una tarjeta para abrir esta puerta.");
        }
    }

    IEnumerator WaitForDoorToOpen()
    {
        // Espera hasta que la animación termine (ajusta el tiempo según la duración de la animación)
        yield return new WaitForSeconds(doorAnimator.GetCurrentAnimatorStateInfo(0).length);
        // Cambia a la escena de escape
        SceneManager.LoadScene(escapeSceneName, LoadSceneMode.Single);
    }
}