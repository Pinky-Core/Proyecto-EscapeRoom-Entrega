using UnityEngine;

public class PlaceObjectTrigger : MonoBehaviour
{

    [SerializeField] private AudioSource doorAudioSource; // Referencia al AudioSource de la puerta
    [SerializeField] private AudioClip doorOpenSound; // Sonido de apertura de la puerta

    public Animator PaintAnimator; // Referencia al Animator de la puerta
    public string requiredTag = "Liftable"; // Tag que debe tener el objeto para ser colocado
    private bool isTriggered = false;
    private bool doorOpen = false;


    void OnTriggerEnter(Collider other)
    {
        if (!isTriggered && other.CompareTag(requiredTag))
        {
     
            isTriggered = true;
            doorAudioSource.PlayOneShot(doorOpenSound);
            PaintAnimator.SetBool("Open", true); // Iniciar animación de la puerta
        }
    }
}   