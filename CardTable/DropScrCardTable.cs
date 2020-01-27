using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class DropScrCardTable : MonoBehaviour, IDropHandler
{
    public FieldType Type;

    

    public void OnDrop(PointerEventData eventData)
    {
        if (Type != FieldType.PLAYER_TABLE)
            return;

        
        CardMovementScr card = eventData.pointerDrag.GetComponent<CardMovementScr>();
       
        if (card)
        {
            card.CreateCardH.TemporaryListCards.Remove(card.GetComponent<CardInfoScr>().SelfCard);

            card.CreateCardH.TableAllCards.Add(card.GetComponent<CardInfoScr>().SelfCard);

            card.DefaultParent = transform;
        }

    }

}
