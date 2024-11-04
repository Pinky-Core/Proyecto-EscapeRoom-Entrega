using UnityEngine;
using UnityEngine.UI;

public class PasswordPanel : MonoBehaviour
{
    public InputField passwordInputField; // El campo de entrada para la contraseña
    public DoorController doorController; // La referencia al controlador de la puerta

    public void OnSubmit()
    {
        string inputPassword = passwordInputField.text;
        doorController.CheckPassword(inputPassword);
    }
}