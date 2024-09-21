using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class DragDropHandler : MonoBehaviour //IBeginDragHandler, IDragHandler, IEndDragHandler
{
  /*  private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public Canvas canvas; // Reference to the Canvas
    private PlayerInput playerInput; // Reference to the PlayerInput component
    private InputAction dragAction;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();

        // Get the PlayerInput component and the drag action
        playerInput = GetComponent<PlayerInput>();
        dragAction = playerInput.actions["Game"]; // "Drag" should match the name of the action in your Input Actions asset
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Use the input action directly
        Vector2 pointerDelta = dragAction.ReadValue<Vector2>();
        rectTransform.anchoredPosition += pointerDelta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }*/
}
