using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public enum FieldType
{
    SELF_HAND,
    SELF_FIELD,
    ENEMY_HAND,
    ENEMY_FIELD,
    PLAYER_TABLE,
    PLAYER_CREATE_TROOP

}


public class TypeField : MonoBehaviour {

    public FieldType Type;
}
