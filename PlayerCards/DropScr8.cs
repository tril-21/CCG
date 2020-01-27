using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class DropScr8 : MonoBehaviour, IDropHandler
{
    public FieldType Type;

    Transform PlayerF1, PlayerF2, PlayerF3, PlayerF4, PlayerF5, PlayerF6, PlayerF7, PlayerF8;

    public void OnDrop(PointerEventData eventData)
    {
        if (Type != FieldType.SELF_FIELD)
            return;

        CardMovementScr card = eventData.pointerDrag.GetComponent<CardMovementScr>();

        if (card&&card.GameManager.PlayerFieldCard8.Count==0 && card.GetComponent<CardInfoScr>().SelfCard.Preparation==0 && card.GameManager.IsPlayerTurn)
        {
            card.GameManager.PlayerHandCards.Remove(card.GetComponent<CardInfoScr>());
            
            card.GameManager.PlayerFieldCard8.Add(card.GetComponent<CardInfoScr>());
            card.GameManager.PlayerFieldCards.Add(card.GetComponent<CardInfoScr>());
           
            card.DefaultParent = transform;
        }

    }
}
