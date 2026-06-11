using UnityEngine;
using DG.Tweening;
using UnityEngine.InputSystem.Interactions;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Handles card selection logic
/// Functions : Card movement into slots and removal of cards
/// </summary>

public class CardManager : MonoBehaviour
{
    [Header("Card Items")]
    public GameObject cardObject;  // active card selected
    public GameObject cardSlots;
    public GameObject opponentCard;
    public List<GameObject> cards = new List<GameObject>();

    [Header("Anchor Points")]
    public Transform deckMidPoint;
    public Transform deckOffsetPoint;
    
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
                CardTapBounce(cardObject);
                GameEvents.OnCardTapped?.Invoke();
                
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

    public void CardTapBounce(GameObject card)
    {
        Vector3 newScale = card.transform.localScale / 2;
        card.transform.DOPunchScale(newScale, 0.1f, 1, 1);
    }

/// <summary>
/// Card animation sequence at the start of every new game
/// </summary>
    public void NewGameCardSequence()
    {
        if (opponentCard == null || deckMidPoint == null || deckOffsetPoint == null) return;

        Vector3 oppCardPosition = opponentCard.transform.position;
        Vector3 oppCardOffset = new Vector3 (oppCardPosition.x, oppCardPosition.y + 700, oppCardPosition.z);

        Vector3 deckPosition = deckMidPoint.transform.position;
        Vector3 deckOffset = deckOffsetPoint.transform.position;

        opponentCard.transform.position = oppCardOffset;
        
        foreach (GameObject card in cards)
        {
            Vector3 originalPosition = card.transform.position;

            card.transform.position = deckOffset;
            card.transform.DOMove(deckPosition, 0.3f)
              .SetEase(Ease.OutBack);

            card.transform.DOMove(originalPosition, 0.3f)
              .SetDelay(0.8f)
              .SetEase(Ease.OutBack);
        }

        opponentCard.transform.DOMove(oppCardPosition, 0.3f)
          .SetDelay(1.5f)
          .SetEase(Ease.OutBack);
          
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