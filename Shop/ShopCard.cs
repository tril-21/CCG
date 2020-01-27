using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopCard : MonoBehaviour {

    public GameObject Bground, Bgroundopen;

    public GameObject cardpref;

    GameObject Card1, Card2, Card3, Card4, Card5, Card6;
    Card card1, card2, card3, card4, card5, card6;

    public Transform CardField1, CardField2, CardField3, CardField4, CardField5, CardField6;

    public List<Card> TempCard;

    public void Start()
    {
        GetComponent<ShowPlayerData>().ShowMoney(GetComponent<ShowPlayerData>().ReadFile("username.txt"));
    }

    public void Open()
    {
        GetComponent<CardManagerScr>().Box1();
        Bground.SetActive(false);
        Bgroundopen.SetActive(true);

        TempCard = new List<Card>();

        for(int i=0; i<6; i++)
        {
            TempCard.Add(CardManager.AllCards[Random.Range(0, CardManager.AllCards.Count)]);
        }

        //card1 = CardManager.AllCards[Random.Range(0, CardManager.AllCards.Count)];
        card1 = TempCard[0];
        Card1 = Instantiate(cardpref, CardField1, false);
        Card1.GetComponent<CardInfoScr>().ShowCardInfo(card1);
        // GetComponent<SaveScript>().CollectionCardTemp.Add(card1);

        //  Debug.Log(GetComponent<SaveScript>().sv.CollectionCard.Count);

        //card2 = CardManager.AllCards[Random.Range(0, CardManager.AllCards.Count)];
        card2 = TempCard[1];
        Card2 = Instantiate(cardpref, CardField2, false);
        Card2.GetComponent<CardInfoScr>().ShowCardInfo(card2);
        // GetComponent<SaveScript>().CollectionCardTemp.Add(card2);

        //card3 = CardManager.AllCards[Random.Range(0, CardManager.AllCards.Count)];
        card3 = TempCard[2];
        Card3 = Instantiate(cardpref, CardField3, false);
        Card3.GetComponent<CardInfoScr>().ShowCardInfo(card3);
        //  GetComponent<SaveScript>().CollectionCardTemp.Add(card3);

        //card4 = CardManager.AllCards[Random.Range(0, CardManager.AllCards.Count)];
        card4 = TempCard[3];
        Card4 = Instantiate(cardpref, CardField4, false);
        Card4.GetComponent<CardInfoScr>().ShowCardInfo(card4);
        // GetComponent<SaveScript>().CollectionCardTemp.Add(card4);

        //card5 = CardManager.AllCards[Random.Range(0, CardManager.AllCards.Count)];
        card5 = TempCard[4];
        Card5 = Instantiate(cardpref, CardField5, false);
        Card5.GetComponent<CardInfoScr>().ShowCardInfo(card5);
        // GetComponent<SaveScript>().CollectionCardTemp.Add(card5);

        //card6 = CardManager.AllCards[Random.Range(0, CardManager.AllCards.Count)];
        card6 = TempCard[5];
        Card6 = Instantiate(cardpref, CardField6, false);
        Card6.GetComponent<CardInfoScr>().ShowCardInfo(card6);
       // GetComponent<SaveScript>().CollectionCardTemp.Add(card6);

       // GetComponent<SaveScript>().SaveData();
    }

    public void BoxOne()
    {
        int price = 100;
        GetComponent<ShowPlayerData>().BuyCard(price, GetComponent<ShowPlayerData>().ReadFile("username.txt"));
    }

    public void Close()
    {
        Destroy(Card1);
        Destroy(Card2);
        Destroy(Card3);
        Destroy(Card4);
        Destroy(Card5);
        Destroy(Card6);
        string sql = "INSERT INTO "+GetComponent<ShowPlayerData>().ReadFile("mycard.txt")+" ( NameCard, RarityCard, PreparationCard, AttackCard, DefenseCard, Skills, ImgName)" +
            "VALUES (@nameCard, @rarityCard, @preparationCard, @attackCard, @defenseCard, @scills, @imgName);";
        for (int i=0; i<6; i++)
        {
            GetComponent<CardManagerScr>().MyCardSave(TempCard[i], sql);
        }
        Bgroundopen.SetActive(false);
        Bground.SetActive(true);
        GetComponent<ShowPlayerData>().ShowMoney(GetComponent<ShowPlayerData>().ReadFile("username.txt"));
    }

}
