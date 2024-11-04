using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : MonoBehaviour
{
    [SerializeField] private Text Ans;
    [SerializeField] private Animator Door;
    [SerializeField] private GameObject keypadCanvas; // Referencia al canvas del keypad
    [SerializeField] private FirstPersonMovement movementScript; // Referencia al script de movimiento del jugador
    [SerializeField] private FirstPersonLook lookScript; // Referencia al script de mirada del jugador
    [SerializeField] private AudioSource doorAudioSource; // Referencia al AudioSource de la puerta
    [SerializeField] private AudioClip doorOpenSound; // Sonido de apertura de la puerta
    [SerializeField] private Transform player; // Referencia al transform del jugador

    public Text interactionText; // Referencia al texto de interacción (Usar)

    private RigidbodyConstraints originalConstraints;
    private string Answer = "929571";
    private bool doorOpen = false;
    private Rigidbody playerRigidbody;

    void Start()
    {
        keypadCanvas.SetActive(false); // Asegúrate de que el canvas esté desactivado al inicio
        playerRigidbody = player.GetComponent<Rigidbody>(); // Obtener el Rigidbody del jugador
        originalConstraints = playerRigidbody.constraints;
    }

    public void Number(int number)
    {
        Ans.text += number.ToString();
    }

    public void Execute()
    {
        if (Ans.text == Answer)
        {
            Ans.text = "Correct";
            Door.SetBool("Open", true);
            doorOpen = true;
            doorAudioSource.PlayOneShot(doorOpenSound); // Reproducir el sonido de apertura de la puerta
            StartCoroutine(OpenDoorAndHideKeypad());
        }
        else
        {
            Ans.text = "Invalid";
            StartCoroutine(ClearText());
        }
    }

    IEnumerator ClearText()
    {
        yield return new WaitForSeconds(1f);
        Ans.text = "";
    }

    IEnumerator OpenDoorAndHideKeypad()
    {
        yield return new WaitForSeconds(0.5f); // Tiempo para que la puerta comience a abrirse
        HideKeypad();
    }

    // Método para mostrar el canvas del keypad
    public void ShowKeypad()
    {
        keypadCanvas.SetActive(true);
        Ans.text = ""; // Limpiar el campo de texto al mostrar el canvas
        Cursor.lockState = CursorLockMode.None; // Desbloquear el cursor para inspección
        Cursor.visible = true; // Hacer visible el cursor
        movementScript.enabled = false; // Desactivar el movimiento del jugador
        lookScript.enabled = false; // Desactivar la rotación de la cámara

        interactionText.gameObject.SetActive(false);

        // Congelar el Rigidbody del jugador
        playerRigidbody.constraints = RigidbodyConstraints.FreezeAll;
    }

    // Método para ocultar el canvas del keypad
    public void HideKeypad()
    {
        keypadCanvas.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked; // Bloquear el cursor de nuevo
        Cursor.visible = false; // Ocultar el cursor
        movementScript.enabled = true; // Reactivar el movimiento del jugador
        lookScript.enabled = true; // Reactivar la rotación de la cámara

        // Liberar las restricciones del Rigidbody del jugador, solo congelar rotación y posición Z
        playerRigidbody.constraints = originalConstraints;
    }

    // Método para cancelar la interacción con el keypad
    public void Cancel()
    {
        HideKeypad();
    }
}