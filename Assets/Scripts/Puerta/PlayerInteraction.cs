using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance = 1f;
    public Text interactionText; // Referencia al texto de interacción (Usar)
    private Camera playerCamera;

    void Start()
    {
        playerCamera = Camera.main;
        interactionText.gameObject.SetActive(false); // Asegúrate de que el texto esté inicialmente desactivado
    }

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            Keypad keypad = hit.collider.GetComponent<Keypad> ();
            if (keypad != null)
            {
                interactionText.gameObject.SetActive(true); // Mostrar texto "Usar"
                interactionText.text = "(E) Usar"; // Actualizar el texto

                if (Input.GetKeyDown(KeyCode.E)) // Presiona E para interactuar
                {
                    keypad.ShowKeypad();
                    interactionText.gameObject.SetActive(false); // Ocultar texto al interactuar
                }
            }
            else
            {
                interactionText.gameObject.SetActive(false); // Ocultar texto si no está mirando un objeto usable
            }
        }
        else
        {
            interactionText.gameObject.SetActive(false); // Ocultar texto si no está mirando ningún objeto
        }
    }
}