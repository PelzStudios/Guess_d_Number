using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // get card value from card and store it
    // Drag and drop functionality

    [Header("Card Info")]
    public CardDeck cardNumber;
    public int cardValue;

    [Header("Drag and Drop")]
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    private Canvas canvas;
    private Vector3 startPosition;
    private bool isDroppedInSlot = false;
    
    void Awake()
    {
        startPosition = rectTransform.anchoredPosition;
        isDroppedInSlot = false;

        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.6f; 
        canvasGroup.blocksRaycasts = false;
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
       rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        if (!isDroppedInSlot)
        {
            rectTransform.anchoredPosition = startPosition;
        }
    }
    
    
    public void GetCardValue()
    {
        cardValue = (int)cardNumber;  // convert enum value to int
    }

}