using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour //IDropHandler
{
    /*public CardManager cardManager;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            RectTransform draggedRectTransform = eventData.pointerDrag.GetComponent<RectTransform>();
            draggedRectTransform.anchoredPosition = GetComponent<RectTransform>().anchoredPosition;

            // Increment the filled boxes counter
            cardManager.filledBoxes++;

            // Check the order of the cards if all boxes are filled
            if (cardManager.AreAllBoxesFilled())
            {
                if (cardManager.CheckOrder())
                {
                    Debug.Log("Cards are in the correct order!");
                }
                else
                {
                    Debug.Log("Cards are not in the correct order.");
                }
            }
        }
    }*/
}
