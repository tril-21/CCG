using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CreateCardHand : MonoBehaviour {

    public Transform PlayerAllField, PlayerCreateTroop;
    public GameObject cardpref;
    public List<Card> TableAllCards = new List<Card>();
    public List<Card> TemporaryListCards = new List<Card>();

    

    public Button Save;

    int i;
    public int proverka = 1;

    void Start () {
        GetComponent<CardManagerScr>().MyAllCard(GetComponent<ShowPlayerData>().ReadFile("mycard.txt"));
        GetComponent<CardManagerScr>().MyTroopeOneCard(GetComponent<ShowPlayerData>().ReadFile("troopeone.txt"));
        CreateCards();
        Debug.Log(TemporaryListCards.Count);
        Save.enabled = false;
	}


    public void CreateCards()
    {
        for(i=0; i<CardManager.MyAllCards.Count; i++)
        {
            Card card1 = CardManager.MyAllCards[i];
            GameObject CardGo = Instantiate(cardpref, PlayerAllField, false);
            CardGo.GetComponent<CardInfoScr>().ShowCardInfo(card1);
            TableAllCards.Add(card1);
        }
        for(i=0; i < CardManager.TroopeOne.Count; i++)
        {
            Card card1 = CardManager.TroopeOne[i];
            GameObject CardGo = Instantiate(cardpref, PlayerCreateTroop, false);
            CardGo.GetComponent<CardInfoScr>().ShowCardInfo(card1);
            TemporaryListCards.Add(card1);
        }
        
    }
    
    public void ToGiveDeck()
    {
        if (TemporaryListCards.Count < 8)
            return;
        string sqlDelete = "DELETE FROM "+ GetComponent<ShowPlayerData>().ReadFile("troopeone.txt");
        GetComponent<CardManagerScr>().DeleteAll(sqlDelete);
        string sql = "INSERT INTO "+ GetComponent<ShowPlayerData>().ReadFile("troopeone.txt") + " (NameCard, RarityCard, PreparationCard, AttackCard, DefenseCard, Skills, ImgName)" +
            "VALUES (@nameCard, @rarityCard, @preparationCard, @attackCard, @defenseCard, @scills, @imgName);";
        for (int i = 0; i < 8; i++)
        {
            GetComponent<CardManagerScr>().MyCardSave(TemporaryListCards[i], sql);
        }
        
        string sqlDeleteCard = "DELETE FROM "+ GetComponent<ShowPlayerData>().ReadFile("mycard.txt") + " " + "WHERE NameCard = @nameCard " + "LIMIT 1";
        for (int i = 0; i < 8; i++)
        {
            GetComponent<CardManagerScr>().DeleteCardSql(TemporaryListCards[i], sqlDeleteCard);
        }
        Save.enabled = false;
    }
    
}
