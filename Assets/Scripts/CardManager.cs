using UnityEngine;
using DG.Tweening;
using UnityEngine.InputSystem.Interactions;

/// <summary>
/// Handles card selection logic
/// Functions : Card movement into slots and removal of cards
/// </summary>

public class CardManager : MonoBehaviour
{
    public GameObject cardObject;  // active card selected
    public GameObject cardSlots;
   
    
    [HideInInspector]
    public GameObject cardInstance;


/// <summary>
/// Handles the logic when a card is selected
/// - loops through each card slot and performs the duplicate card logic
/// </summary>
    public void HandleCardSelected()  
    {
        for (int i =0; i < cardSlots.transform.childCount; i++)  // loop through the card slots transforms
        {
            CardSlot slot = cardSlots.transform.GetChild(i).GetComponent<CardSlot>();

            if (!slot) return;

            if (!slot.isOccupied)
            {
                cardInstance = Instantiate(cardObject, cardObject.GetComponent<Card>().originalPosition);  

                MoveToPosition(slot.transform.position);
                
                cardInstance.transform.localPosition = Vector3.zero;   // ensure its centered properly

                slot.GetComponent<CardSlot>().isOccupied = true;
                
                cardInstance.GetComponent<Card>().isDuplicate = true;
                cardInstance.transform.SetParent(slot.transform);

                GameEvents.OnCardEntered?.Invoke();
                break;
            }
        }
    }
    
/// <summary>
/// Duplicate card animation logic
/// </summary>
    public void MoveToPosition(Vector3 targetPosition)
    {
        cardInstance.transform.DOMove(targetPosition, 0.3f);
    }

/// <summary>
/// Clears card slots for new session
/// </summary>
    public void ResetCardSlots()   // to clear the slots on new game
    {
        foreach (Transform slot in cardSlots.transform)  // loop through children
        {
            CardSlot slotComponent = slot.GetComponent<CardSlot>();

            if (slotComponent.isOccupied == true)
            {
                foreach (Transform card in slot)  // loop through children
                {
                    Destroy(card.gameObject);
                }

                slotComponent.isOccupied = false;
            }
        }
    }
}