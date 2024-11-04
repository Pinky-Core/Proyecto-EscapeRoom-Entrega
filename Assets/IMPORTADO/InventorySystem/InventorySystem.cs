using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    public List<GameObject> inventory = new List<GameObject>();
    public Transform inventoryUIParent;
    public GameObject inventorySlotPrefab;

    public void AddToInventory(GameObject item)
    {
        inventory.Add(item);

        // Actualiza la UI del inventario
        GameObject slot = Instantiate(inventorySlotPrefab, inventoryUIParent);

        MeshRenderer meshRenderer = item.GetComponent<MeshRenderer>();
        if (meshRenderer != null)
        {
            Texture texture = meshRenderer.material.mainTexture;
            RawImage rawImage = slot.GetComponent<RawImage>();
            rawImage.texture = texture;

            // Mantener la proporción de la textura
            RectTransform rectTransform = rawImage.GetComponent<RectTransform>();
            float aspectRatio = (float)texture.width / texture.height;
            rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.y * aspectRatio, rectTransform.sizeDelta.y);
        }

        slot.GetComponent<Button>().onClick.AddListener(() => InspectItem(item));
    }

    public void InspectItem(GameObject item)
    {
        // Lógica para inspeccionar el objeto desde el inventario
    }
}   