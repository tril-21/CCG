using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadFunc : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<ShowPlayerData>().ShowXP(GetComponent<ShowPlayerData>().ReadFile("username.txt"));
        GetComponent<ShowPlayerData>().ShowMoney(GetComponent<ShowPlayerData>().ReadFile("username.txt"));

    }


}
