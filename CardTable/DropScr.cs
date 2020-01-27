using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DropScr : MonoBehaviour, IDropHandler/*, IPointerEnterHandler, IPointerExitHandler*/
{
    public FieldType Type;

    Transform PlayerF1, PlayerF2, PlayerF3, PlayerF4, PlayerF5, PlayerF6, PlayerF7, PlayerF8;

    public void OnDrop(PointerEventData eventData)
    {
        if (Type != FieldType.SELF_FIELD)
            return;

        CardMovementScr card = eventData.pointerDrag.GetComponent<CardMovementScr>();

        if (card&&card.GameManager.PlayerFieldCards.Count<8)
        {
            card.GameManager.PlayerHandCards.Remove(card.GetComponent<CardInfoScr>());
            card.GameManager.PlayerFieldCards.Add(card.GetComponent<CardInfoScr>());
           
            card.DefaultParent = transform;
        }

    }
    /*
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null||Type==FieldType.ENEMY_FIELD||Type==FieldType.ENEMY_HAND)
            return;

        CardMovementScr card = eventData.pointerDrag.GetComponent<CardMovementScr>();

        if (card)
            card.DefaultTempCardParent = transform;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;

        CardMovementScr card = eventData.pointerDrag.GetComponent<CardMovementScr>();

        if (card && card.DefaultTempCardParent == transform)
            card.DefaultTempCardParent = card.DefaultParent;
    }*/
}
