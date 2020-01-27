using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardMovementScr : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    Camera MainCamera;
    Vector3 offset;
    public Transform DefaultParent;
    public GameManagerScr GameManager;
    public CreateCardHand CreateCardH;
    public bool IsDraggable;

    void Awake()
    {
        MainCamera = Camera.allCameras[0];
       
        GameManager = FindObjectOfType<GameManagerScr>();
        CreateCardH = FindObjectOfType<CreateCardHand>();
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        offset = transform.position - MainCamera.ScreenToWorldPoint(eventData.position);

        DefaultParent= transform.parent;


        IsDraggable = ((DefaultParent.GetComponent<TypeField>().Type == FieldType.SELF_HAND && GameManager.IsPlayerTurn)||(DefaultParent.GetComponent<TypeField>().Type==FieldType.PLAYER_TABLE)|| (DefaultParent.GetComponent<TypeField>().Type == FieldType.PLAYER_CREATE_TROOP));
        if (!IsDraggable)
            return;



        

        transform.SetParent(DefaultParent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    
    public void OnDrag(PointerEventData eventData)
    {
       if (!IsDraggable)
            return;
        Vector3 newPos = MainCamera.ScreenToWorldPoint(eventData.position);
        transform.position = newPos + offset;

    
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        if (!IsDraggable)
            return;
   
            transform.SetParent(DefaultParent);
            GetComponent<CanvasGroup>().blocksRaycasts = true;

     
        
    }
}
