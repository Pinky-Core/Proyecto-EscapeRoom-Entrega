//You are free to use this script in Free or Commercial projects
//sharpcoderblog.com @2019

using UnityEngine;

public class SC_PickItem : MonoBehaviour
{
    public string itemName = "Some Item"; //Each item must have an unique name
    public Texture itemPreview;

    void Start()
    {
        //Change item tag to Respawn to detect when we look at it
        gameObject.tag = "Respawn";
    }

    public void PickItem()
    {
        Destroy(gameObject);
    }
}