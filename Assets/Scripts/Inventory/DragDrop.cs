using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private RectTransform rectTransform;
    private Canvas canvas;
    private RectTransform dropZone;
    private Vector2 initialPosition;
    public string validDropZoneTag = "inventorySlot";
    public bool isEnabled = false;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();

        // Store the initial position of the object
        initialPosition = rectTransform.anchoredPosition;

        dropZone = FindDropZoneObject();
    }

    private RectTransform FindDropZoneObject()
    {
        RectTransform[] dropZones = GameObject.FindObjectsOfType<RectTransform>();

        foreach (RectTransform zone in dropZones)
        {
            if (zone.CompareTag(validDropZoneTag))
            {
                return zone;
            }
        }

        return null;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!isEnabled)
            return;

        // Disable raycasts on the draggable object
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isEnabled)
            return;

        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!isEnabled)
            return;

        // Enable raycasts on the draggable object
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        if (IsDropZoneValid(eventData.position))
        {
            if (dropZone != null)
            {
                // Convert the draggable object's position to the drop zone's local space
                Vector2 localPosition = Vector2.zero;
                RectTransformUtility.ScreenPointToLocalPointInRectangle(dropZone, eventData.position, canvas.worldCamera, out localPosition);

                // Adjust the local position based on the pivot and size of the draggable object
                Vector2 draggablePivot = rectTransform.pivot;
                Vector2 draggableSize = rectTransform.sizeDelta;
                localPosition -= new Vector2(draggablePivot.x * draggableSize.x, (1 - draggablePivot.y) * draggableSize.y);

                // Adjust the local position from top-left to bottom-left coordinate system
                localPosition += new Vector2(0, dropZone.sizeDelta.y);

                // Set the anchored position of the draggable object to the calculated local position
                rectTransform.anchoredPosition = localPosition;
            }
        }
        else
        {
            rectTransform.anchoredPosition = initialPosition; // Reset the object's position
        }
    }


    private bool IsDropZoneValid(Vector2 position)
    {
        if (dropZone != null)
        {
            return dropZone.CompareTag(validDropZoneTag);
        }
        else
        {
            Debug.LogWarning("No drop zone object assigned");
            return false;
        }
    }
}