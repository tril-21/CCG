using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WinOrLose : MonoBehaviour {

    public TextMeshProUGUI MoneyNum, XP;

    public void PanelWinChange(int money, int xp)
    {

        MoneyNum.text = money.ToString();
        XP.text = xp.ToString();
        GetComponent<ShowPlayerData>().ChangeXP(xp, GetComponent<ShowPlayerData>().ReadFile("username.txt"));
        GetComponent<ShowPlayerData>().ChangeMoney(money, GetComponent<ShowPlayerData>().ReadFile("username.txt"));

    }
    
}
