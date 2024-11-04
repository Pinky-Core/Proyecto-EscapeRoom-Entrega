using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public string interactionText = "Interactuar"; // Texto por defecto para interactuar

    public abstract void Interact();
}