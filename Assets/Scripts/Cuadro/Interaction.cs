using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    public float interactionDistance = 1f;
    public Text interactionText; // Referencia al texto de interacción (Inspeccionar/Usar)
    private Camera playerCamera;

    void Start()
    {
        playerCamera = Camera.main;
        interactionText.gameObject.SetActive(false); // Asegúrate de que el texto esté inicialmente desactivado
    }

    void Update()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();

            if (interactable != null)
            {
                interactionText.gameObject.SetActive(true); // Mostrar texto
                interactionText.text = interactable.interactionText; // Actualizar el texto

                if (Input.GetMouseButtonUp(0)) // Presiona MB0 para interactuar
                {
                    interactable.Interact();
                    interactionText.gameObject.SetActive(false); // Ocultar texto al interactuar
                }
            }
            else
            {
                interactionText.gameObject.SetActive(false); // Ocultar texto si no está mirando un objeto interactivo
            }
        }
        else
        {
            interactionText.gameObject.SetActive(false); // Ocultar texto si no está mirando ningún objeto
        }
    }
}
