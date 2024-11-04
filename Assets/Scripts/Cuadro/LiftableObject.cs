using UnityEngine;

public class LiftableObject : Interactable
{


    public Transform player; // Referencia al jugador
    public Transform carryPosition; // Posición donde el objeto será llevado
    private bool isBeingCarried = false;

    void Start()
    {
        interactionText = "Agarrar"; // Texto específico para este objeto
    }

    void Update()
    {
        if (isBeingCarried && Input.GetMouseButtonUp(0)) // Soltar el objeto al soltar el botón izquierdo del ratón
        {
            isBeingCarried = false;
            transform.parent = null;
        }

        if (isBeingCarried)
        {
            transform.position = carryPosition.position;
        }
    }

    public override void Interact()
    {
        if (!isBeingCarried)
        {
            isBeingCarried = true;
            transform.parent = carryPosition; // Hacer que el objeto siga la posición de carryPosition
        }
    }
}
