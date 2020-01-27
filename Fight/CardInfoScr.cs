using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class CardInfoScr : MonoBehaviour {

    public Card SelfCard;
    public Image Logo;
    public TextMeshProUGUI Name, Attack, Defense, Preparation;
    public GameObject HideObj;

    public void HideCardInfo(Card card)
    {
        SelfCard = card;
        HideObj.SetActive(true);
        Preparation.text = "";
    }

    public void ShowCardInfo(Card card)
    {
        HideObj.SetActive(false);
        SelfCard = card;

        Logo.sprite = card.Logo;
        Logo.preserveAspect = true;
        Name.text = card.Name;

        RefreshData();
    }

    public void RefreshData()
    {
        Attack.text = SelfCard.Attack.ToString();
        Defense.text = SelfCard.Defense.ToString();
        Preparation.text = SelfCard.Preparation.ToString();
    }

    private void Start()
    {
       // ShowCardInfo(CardManager.AllCards[transform.GetSiblingIndex()]);

    }
}
