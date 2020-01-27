using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour {

    public GameObject Sword;

    public void attack(GameObject weapon, Transform field)
    {
        GameObject weap = Instantiate(weapon, field, false);
       // Destroy(weap);
    }
}
