using UnityEngine;

public class DoorController : MonoBehaviour
{
    public string correctPassword = "123456"; // La contraseña correcta
    public Animator doorAnimator; // El animator para abrir la puerta
    public GameObject passwordPanel; // El panel de la UI para ingresar la contraseña

    private bool isUnlocked = false;

    // Método para ser llamado cuando se presione el botón de la UI
    public void CheckPassword(string inputPassword)
    {
        if (inputPassword == correctPassword)
        {
            UnlockDoor();
        }
        else
        {
            Debug.Log("Contraseña incorrecta");
        }
    }

    private void UnlockDoor()
    {
        isUnlocked = true;
        doorAnimator.SetTrigger("OpenDoor"); // Asumiendo que tienes una animación llamada "OpenDoor"
        passwordPanel.SetActive(false); // Ocultar el panel de la contraseña
    }

    // Método para interactuar con la puerta
    public void Interact()
    {
        if (!isUnlocked)
        {
            passwordPanel.SetActive(true); // Mostrar el panel de la contraseña
        }
    }
}
