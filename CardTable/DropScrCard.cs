using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class DropScrCard : MonoBehaviour, IDropHandler
{
    public FieldType Type;

    

    public void OnDrop(PointerEventData eventData)
    {
        if (Type != FieldType.PLAYER_CREATE_TROOP)
            return;

        
        CardMovementScr card = eventData.pointerDrag.GetComponent<CardMovementScr>();


        if (card&& card.CreateCardH.TemporaryListCards.Count<8)
        {
            card.CreateCardH.TemporaryListCards.Add(card.GetComponent<CardInfoScr>().SelfCard);
         
            card.CreateCardH.TableAllCards.Remove(card.GetComponent<CardInfoScr>().SelfCard);
            
            Debug.Log(card.CreateCardH.TemporaryListCards.Count);
            card.DefaultParent = transform;
           
        }
        if (card.CreateCardH.TemporaryListCards.Count == 8)
            card.CreateCardH.Save.enabled = true;

    }

}
