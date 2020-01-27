using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game
{
    public List<Card>   EnemyDeck, PlayerDeck;

    public Game()
    {
        EnemyDeck = GiveDeckCardEnemy();
        PlayerDeck = GiveDeckCardPlayer();

    }

    List<Card> GiveDeckCardPlayer()
    {
        List<Card> list = new List<Card>();
        for (int i = 0; i < 8; i++)
        {
            //list.Add(CardTroop.CardsTroopOne[i]);
          //  CardManager.TroopeOne
          
            list.Add(CardManager.TroopeOne[i]);
        }
        return list;
    }
    List<Card> GiveDeckCardEnemy()
    {
        List<Card> list = new List<Card>();
        for (int i = 0; i < 8; i++)
        {
            //list.Add(CardTroop.CardsTroopOne[i]);
            //  CardManager.TroopeOne

            list.Add(CardManager.AllCards[Random.Range(1, 10)]);
        }
        return list;
    }
}

public class GameManagerScr : MonoBehaviour {

    public Game CurrentGame;
    public Transform EnemyHand, PlayerHand,
                        EnemyField1, EnemyField2, EnemyField3, EnemyField4, EnemyField5, EnemyField6, EnemyField7, EnemyField8,
                        PlayerField1, PlayerField2, PlayerField3, PlayerField4, PlayerField5, PlayerField6, PlayerField7, PlayerField8;
    public GameObject CardPref;
    int Turn, TurnTime = 30;
    public TextMeshProUGUI TurnTimeTxt;
    public Button EndTurnBtn;

    public int PlayerHP, EnemyHP;

    public GameObject ResultGO;
    public TextMeshProUGUI RezultTxt;

    public int PlayerManapool, EnemyManaPool;
    public TextMeshProUGUI PlayerHPTxt, EnemyHPTxt, PlayerManaPoolTxt, EnemyManaPoolTxt;

    public string chekWin;

    public List<CardInfoScr> PlayerHandCards = new List<CardInfoScr>(),
                                EnemyHandCards = new List<CardInfoScr>(),
                                PlayerFieldCards = new List<CardInfoScr>(),
                                PlayerFieldCard1 = new List<CardInfoScr>(), EnemyFieldCard1 = new List<CardInfoScr>(),
                                PlayerFieldCard2 = new List<CardInfoScr>(), EnemyFieldCard2 = new List<CardInfoScr>(),
                                PlayerFieldCard3 = new List<CardInfoScr>(), EnemyFieldCard3 = new List<CardInfoScr>(),
                                PlayerFieldCard4 = new List<CardInfoScr>(), EnemyFieldCard4 = new List<CardInfoScr>(),
                                PlayerFieldCard5 = new List<CardInfoScr>(), EnemyFieldCard5 = new List<CardInfoScr>(),
                                PlayerFieldCard6 = new List<CardInfoScr>(), EnemyFieldCard6 = new List<CardInfoScr>(),
                                PlayerFieldCard7 = new List<CardInfoScr>(), EnemyFieldCard7 = new List<CardInfoScr>(),
                                PlayerFieldCard8 = new List<CardInfoScr>(), EnemyFieldCard8 = new List<CardInfoScr>(),
                                EnemyFieldCards = new List<CardInfoScr>();

    

    public bool IsPlayerTurn
    {
        get
        {
            return Turn % 2 == 0;
        }
    }

	void Start () {
        Turn = 0;

        chekWin = "";

        CurrentGame = new Game();
        GiveHandCards(CurrentGame.EnemyDeck, EnemyHand);
        GiveHandCards(CurrentGame.PlayerDeck, PlayerHand);
        PlayerHP = EnemyHP = 30;
        ShowHP();
        PlayerManapool = EnemyManaPool = 10;
        ShowMana();

        StartCoroutine(TurnFunc());
    }

    void GiveHandCards(List<Card> deck, Transform hand)
    {
        int i = 0;
        while (i++ < 4)
            GiveCardToHand(deck, hand);
    }

    void GiveCardToHand(List<Card> deck, Transform hand)
    {
        if (deck.Count == 0 )
            return;

        Card card = deck[0];

        GameObject cardGO = Instantiate(CardPref, hand, false);

        if (hand == EnemyHand)
        {
            cardGO.GetComponent<CardInfoScr>().HideCardInfo(card);
            EnemyHandCards.Add(cardGO.GetComponent<CardInfoScr>());
        }
        else
        {
            cardGO.GetComponent<CardInfoScr>().ShowCardInfo(card);
            PlayerHandCards.Add(cardGO.GetComponent<CardInfoScr>());
        }
        deck.RemoveAt(0);
    }

    IEnumerator TurnFunc()
    {
        TurnTime = 30;
        TurnTimeTxt.text = TurnTime.ToString();

        if (IsPlayerTurn)
        {
            while (TurnTime-- > 0)
            {
                TurnTimeTxt.text = TurnTime.ToString();
                yield return new WaitForSeconds(1);
            }
            
        }
        else
        {
            while (TurnTime-- > 27)
            {
                TurnTimeTxt.text = TurnTime.ToString();
                yield return new WaitForSeconds(1);
            }

            if (EnemyHandCards.Count > 0)
                EnemyTurn(EnemyHandCards);
            CardsFight();

        }
        ChangeTurn();
    }

    void EnemyTurn(List<CardInfoScr> cards)
    {
        
        List<CardInfoScr> cardlist = cards.FindAll(x => x.SelfCard.Preparation == 0);
        //Debug.Log("count=" + cardlist.Count);



        int n = 1;

        for (int i=0; i<cardlist.Count; i++)
        {
            if (EnemyFieldCards.Count > 7)
            {
                return;
            }
            n = 1;
            while (n==1)
            {
                int j = Random.Range(1, 9);
                if (j == 1 && EnemyFieldCard1.Count==0)
                {
                    cardlist[i].ShowCardInfo(cardlist[i].SelfCard);
                    cardlist[i].transform.SetParent(EnemyField1);

                    
                    EnemyFieldCard1.Add(cardlist[i]);
                    EnemyFieldCards.Add(cardlist[i]);
                    EnemyHandCards.Remove(cardlist[i]);
                    
                  
                    n = 0;
                }
                if (j == 2 && EnemyFieldCard2.Count == 0)
                {
                    cardlist[i].ShowCardInfo(cardlist[i].SelfCard);
                    cardlist[i].transform.SetParent(EnemyField2);

                    EnemyFieldCard2.Add(cardlist[i]);
                    EnemyFieldCards.Add(cardlist[i]);
                    EnemyHandCards.Remove(cardlist[i]);
                    
                    
                    n = 0;
                }
                if (j == 3 && EnemyFieldCard3.Count == 0)
                {
                    cardlist[i].ShowCardInfo(cardlist[i].SelfCard);
                    cardlist[i].transform.SetParent(EnemyField3);

                    EnemyFieldCard3.Add(cardlist[i]);
                    EnemyFieldCards.Add(cardlist[i]);
                    EnemyHandCards.Remove(cardlist[i]);
                    
                    
                    n = 0;
                }
                if (j == 4 && EnemyFieldCard4.Count == 0)
                {
                    cardlist[i].ShowCardInfo(cardlist[i].SelfCard);
                    cardlist[i].transform.SetParent(EnemyField4);

                    EnemyFieldCard4.Add(cardlist[i]);
                    EnemyFieldCards.Add(cardlist[i]);
                    EnemyHandCards.Remove(cardlist[i]);
                    
                    
                    n = 0;
                }
                if (j == 5 && EnemyFieldCard5.Count == 0)
                {
                    cardlist[i].ShowCardInfo(cardlist[i].SelfCard);
                    cardlist[i].transform.SetParent(EnemyField5);

                    EnemyFieldCard5.Add(cardlist[i]);
                    EnemyFieldCards.Add(cardlist[i]);
                    EnemyHandCards.Remove(cardlist[i]);
                  
                    
                    n = 0;
                }
                if (j == 6 && EnemyFieldCard6.Count == 0)
                {
                    cardlist[i].ShowCardInfo(cardlist[i].SelfCard);
                    cardlist[i].transform.SetParent(EnemyField6);

                    EnemyFieldCard6.Add(cardlist[i]);
                    EnemyFieldCards.Add(cardlist[i]);
                    EnemyHandCards.Remove(cardlist[i]);
                    
                   
                    n = 0;
                }
                if (j == 7 && EnemyFieldCard7.Count == 0)
                {
                    cardlist[i].ShowCardInfo(cardlist[i].SelfCard);
                    cardlist[i].transform.SetParent(EnemyField7);

                    EnemyFieldCard7.Add(cardlist[i]);
                    EnemyFieldCards.Add(cardlist[i]);
                    EnemyHandCards.Remove(cardlist[i]);
                   
                    
                    n = 0;
                }
                if (j == 8 && EnemyFieldCard8.Count == 0)
                {
                    cardlist[i].ShowCardInfo(cardlist[i].SelfCard);
                    cardlist[i].transform.SetParent(EnemyField8);

                    EnemyFieldCard8.Add(cardlist[i]);
                    EnemyFieldCards.Add(cardlist[i]);
                    EnemyHandCards.Remove(cardlist[i]);
                    

                   
                    n = 0;
                }
            }
            
        }
        

    }

    public void ChangeTurn()
    {
        StopAllCoroutines();
        Turn++;

        EndTurnBtn.interactable = IsPlayerTurn;

        if (IsPlayerTurn)
        {
            foreach (CardInfoScr PrepCard in PlayerHandCards)
            {
                if (PrepCard.SelfCard.Preparation != 0)
                {
                    PrepCard.SelfCard.Preparation--;
                    PrepCard.RefreshData();
                }
            }
            
        }
        else
        {
            foreach (CardInfoScr PrepCard in EnemyHandCards)
            {
                if (PrepCard.SelfCard.Preparation != 0)
                {
                    PrepCard.SelfCard.Preparation--;
                }
            }
        }
        EnemyManaPool = PlayerManapool = 10;
        ShowMana();
        GiveNewCards(IsPlayerTurn);
        StartCoroutine(TurnFunc());
    }
    
    public void CardsFight()
    {
        
        if (IsPlayerTurn)
        {
            
            if (PlayerFieldCard1.Count==1 && EnemyFieldCard1.Count==1)
            {
                CardInfoScr cardP1 = PlayerFieldCard1[0].GetComponent<CardInfoScr>();
                CardInfoScr cardE1 = EnemyFieldCard1[0].GetComponent<CardInfoScr>();
            //    GetComponent<Animation>().attack(GetComponent<Animation>().Sword, PlayerField1);
                fight(cardP1, cardE1, 1);
                
            }
            else if(PlayerFieldCard1.Count == 1 && EnemyFieldCard1.Count == 0)
            {
                if (chekWin == "WIN" || chekWin == "Lose")
                    return;
                CardInfoScr cardP1 = PlayerFieldCard1[0].GetComponent<CardInfoScr>();
             //   GetComponent<Animation>().attack(GetComponent<Animation>().Sword, PlayerField1);
                DamageHero(cardP1);
                
            }

            if (PlayerFieldCard2.Count == 1 && EnemyFieldCard2.Count == 1)
            {
                CardInfoScr cardP2 = PlayerFieldCard2[0].GetComponent<CardInfoScr>();
                CardInfoScr cardE2 = EnemyFieldCard2[0].GetComponent<CardInfoScr>();
            //    GetComponent<Animation>().attack(GetComponent<Animation>().Sword, PlayerField2);
                fight(cardP2, cardE2, 2);
                
            }
            else if (PlayerFieldCard2.Count == 1 && EnemyFieldCard2.Count == 0)
            {
                if (chekWin == "WIN" || chekWin == "Lose")
                    return;
                CardInfoScr cardP2 = PlayerFieldCard2[0].GetComponent<CardInfoScr>();
            //    GetComponent<Animation>().attack(GetComponent<Animation>().Sword, PlayerField2);
                DamageHero(cardP2);
                
            }

            if (PlayerFieldCard3.Count == 1 && EnemyFieldCard3.Count == 1)
            {
                CardInfoScr cardP3 = PlayerFieldCard3[0].GetComponent<CardInfoScr>();
                CardInfoScr cardE3 = EnemyFieldCard3[0].GetComponent<CardInfoScr>();
            //    GetComponent<Animation>().attack(GetComponent<Animation>().Sword, PlayerField3);
                fight(cardP3, cardE3, 3);
                
            }
            else if (PlayerFieldCard3.Count == 1 && EnemyFieldCard3.Count == 0)
            {
                if (chekWin == "WIN" || chekWin == "Lose")
                    return;
                CardInfoScr cardP3 = PlayerFieldCard3[0].GetComponent<CardInfoScr>();
             //   GetComponent<Animation>().attack(GetComponent<Animation>().Sword, PlayerField3);
                DamageHero(cardP3);
                
            }

            if (PlayerFieldCard4.Count == 1 && EnemyFieldCard4.Count == 1)
            {
                CardInfoScr cardP4 = PlayerFieldCard4[0].GetComponent<CardInfoScr>();
                CardInfoScr cardE4 = EnemyFieldCard4[0].GetComponent<CardInfoScr>();
             //   GetComponent<Animation>().attack(GetComponent<Animation>().Sword, PlayerField4);
                fight(cardP4, cardE4, 4);
                
            }
            else if (PlayerFieldCard4.Count == 1 && EnemyFieldCard4.Count == 0)
            {
                if (chekWin == "WIN" || chekWin == "Lose")
                    return;
                CardInfoScr cardP4 = PlayerFieldCard4[0].GetComponent<CardInfoScr>();
             //   GetComponent<Animation>().attack(GetComponent<Animation>().Sword, PlayerField4);
                DamageHero(cardP4);
                
            }

            if (PlayerFieldCard5.Count == 1 && EnemyFieldCard5.Count == 1)
            {
                CardInfoScr cardP5 = PlayerFieldCard5[0].GetComponent<CardInfoScr>();
                CardInfoScr cardE5 = EnemyFieldCard5[0].GetComponent<CardInfoScr>();
             //   GetComponent<Animation>().attack(GetComponent<Animation>().Sword, PlayerField5);
                fight(cardP5, cardE5, 5);
            }
            else if (PlayerFieldCard5.Count == 1 && EnemyFieldCard5.Count == 0)
            {
                if (chekWin == "WIN" || chekWin == "Lose")
                    return;
                CardInfoScr cardP5 = PlayerFieldCard5[0].GetComponent<CardInfoScr>();
             //   GetComponent<Animation>().attack(GetComponent<Animation>().Sword, PlayerField5);
                DamageHero(cardP5);
            }

            if (PlayerFieldCard6.Count == 1 && EnemyFieldCard6.Count == 1)
            {
                CardInfoScr cardP6 = PlayerFieldCard6[0].GetComponent<CardInfoScr>();
                CardInfoScr cardE6 = EnemyFieldCard6[0].GetComponent<CardInfoScr>();
            //    GetComponent<Animation>().attack(GetComponent<Animation>().Sword, PlayerField6);
                fight(cardP6, cardE6, 6);
            }
            else if (PlayerFieldCard6.Count == 1 && EnemyFieldCard6.Count == 0)
            {
                if (chekWin == "WIN" || chekWin == "Lose")
                    return;
                CardInfoScr cardP6 = PlayerFieldCard6[0].GetComponent<CardInfoScr>();
             //   GetComponent<Animation>().attack(GetComponent<Animation>().Sword, PlayerField6);
                DamageHero(cardP6);
            }

            if (PlayerFieldCard7.Count == 1 && EnemyFieldCard7.Count == 1)
            {
                CardInfoScr cardP7 = PlayerFieldCard7[0].GetComponent<CardInfoScr>();
                CardInfoScr cardE7 = EnemyFieldCard7[0].GetComponent<CardInfoScr>();
              //  GetComponent<Animation>().attack(GetComponent<Animation>().Sword, PlayerField7);
                fight(cardP7, cardE7, 7);
            }
            else if (PlayerFieldCard7.Count == 1 && EnemyFieldCard7.Count == 0)
            {
                if (chekWin == "WIN" || chekWin == "Lose")
                    return;
                CardInfoScr cardP7 = PlayerFieldCard7[0].GetComponent<CardInfoScr>();
            //    GetComponent<Animation>().attack(GetComponent<Animation>().Sword, PlayerField7);
                DamageHero(cardP7);
            }

            if (PlayerFieldCard8.Count == 1 && EnemyFieldCard8.Count == 1)
            {
                CardInfoScr cardP8 = PlayerFieldCard8[0].GetComponent<CardInfoScr>();
                CardInfoScr cardE8 = EnemyFieldCard8[0].GetComponent<CardInfoScr>();
             //   GetComponent<Animation>().attack(GetComponent<Animation>().Sword, PlayerField8);
                fight(cardP8, cardE8, 8);
            }
            else if (PlayerFieldCard8.Count == 1 && EnemyFieldCard8.Count == 0)
            {
                if (chekWin == "WIN" || chekWin == "Lose")
                    return;
                CardInfoScr cardP8 = PlayerFieldCard8[0].GetComponent<CardInfoScr>();
             //   GetComponent<Animation>().attack(GetComponent<Animation>().Sword, PlayerField8);
                DamageHero(cardP8);
            }

        } else
        {
            if (PlayerFieldCard1.Count == 1 && EnemyFieldCard1.Count == 1)
            {
                CardInfoScr cardP1 = PlayerFieldCard1[0].GetComponent<CardInfoScr>();
                CardInfoScr cardE1 = EnemyFieldCard1[0].GetComponent<CardInfoScr>();
                fight(cardE1, cardP1, 1);
            }else if(EnemyFieldCard1.Count == 1 && PlayerFieldCard1.Count == 0)
            {
                if (chekWin == "WIN" || chekWin == "Lose")
                    return;
                CardInfoScr cardE1 = EnemyFieldCard1[0].GetComponent<CardInfoScr>();
                DamageHero(cardE1);
            }

            if (PlayerFieldCard2.Count == 1 && EnemyFieldCard2.Count == 1)
            {
                CardInfoScr cardP2 = PlayerFieldCard2[0].GetComponent<CardInfoScr>();
                CardInfoScr cardE2 = EnemyFieldCard2[0].GetComponent<CardInfoScr>();
                fight(cardE2, cardP2, 2);
            }
            else if (EnemyFieldCard2.Count == 1 && PlayerFieldCard2.Count == 0)
            {
                if (chekWin == "WIN" || chekWin == "Lose")
                    return;
                CardInfoScr cardE2 = EnemyFieldCard2[0].GetComponent<CardInfoScr>();
                DamageHero(cardE2);
            }

            if (PlayerFieldCard3.Count == 1 && EnemyFieldCard3.Count == 1)
            {
                CardInfoScr cardP3 = PlayerFieldCard3[0].GetComponent<CardInfoScr>();
                CardInfoScr cardE3 = EnemyFieldCard3[0].GetComponent<CardInfoScr>();
                fight(cardE3, cardP3, 3);
            }
            else if (EnemyFieldCard3.Count == 1 && PlayerFieldCard3.Count == 0)
            {
                if (chekWin == "WIN" || chekWin == "Lose")
                    return;
                CardInfoScr cardE3 = EnemyFieldCard3[0].GetComponent<CardInfoScr>();
                DamageHero(cardE3);
            }

            if (PlayerFieldCard4.Count == 1 && EnemyFieldCard4.Count == 1)
            {
                CardInfoScr cardP4 = PlayerFieldCard4[0].GetComponent<CardInfoScr>();
                CardInfoScr cardE4 = EnemyFieldCard4[0].GetComponent<CardInfoScr>();
                fight(cardE4, cardP4, 4);
            }
            else if (EnemyFieldCard4.Count == 1 && PlayerFieldCard4.Count == 0)
            {
                if (chekWin == "WIN" || chekWin == "Lose")
                    return;
                CardInfoScr cardE4 = EnemyFieldCard4[0].GetComponent<CardInfoScr>();
                DamageHero(cardE4);
            }

            if (PlayerFieldCard5.Count == 1 && EnemyFieldCard5.Count == 1)
            {
                CardInfoScr cardP5 = PlayerFieldCard5[0].GetComponent<CardInfoScr>();
                CardInfoScr cardE5 = EnemyFieldCard5[0].GetComponent<CardInfoScr>();
                fight(cardE5, cardP5, 5);
            }
            else if (EnemyFieldCard5.Count == 1 && PlayerFieldCard5.Count == 0)
            {
                if (chekWin == "WIN" || chekWin == "Lose")
                    return;
                CardInfoScr cardE5 = EnemyFieldCard5[0].GetComponent<CardInfoScr>();
                DamageHero(cardE5);
            }

            if (PlayerFieldCard6.Count == 1 && EnemyFieldCard6.Count == 1)
            {

                CardInfoScr cardP6 = PlayerFieldCard6[0].GetComponent<CardInfoScr>();
                CardInfoScr cardE6 = EnemyFieldCard6[0].GetComponent<CardInfoScr>();
                fight(cardE6, cardP6, 6);
            }
            else if (EnemyFieldCard6.Count == 1 && PlayerFieldCard6.Count == 0)
            {
                if (chekWin == "WIN" || chekWin == "Lose")
                    return;
                CardInfoScr cardE6 = EnemyFieldCard6[0].GetComponent<CardInfoScr>();
                DamageHero(cardE6);
            }

            if (PlayerFieldCard7.Count == 1 && EnemyFieldCard7.Count == 1)
            {
                CardInfoScr cardP7 = PlayerFieldCard7[0].GetComponent<CardInfoScr>();
                CardInfoScr cardE7 = EnemyFieldCard7[0].GetComponent<CardInfoScr>();
                fight(cardE7, cardP7, 7);
            }
            else if (EnemyFieldCard7.Count == 1 && PlayerFieldCard7.Count == 0)
            {
                if (chekWin == "WIN" || chekWin == "Lose")
                    return;
                CardInfoScr cardE7 = EnemyFieldCard7[0].GetComponent<CardInfoScr>();
                DamageHero(cardE7);
            }

            if (PlayerFieldCard8.Count == 1 && EnemyFieldCard8.Count == 1)
            {
                CardInfoScr cardP8 = PlayerFieldCard8[0].GetComponent<CardInfoScr>();
                CardInfoScr cardE8 = EnemyFieldCard8[0].GetComponent<CardInfoScr>();
                fight(cardE8, cardP8, 8);
            }
            else if (EnemyFieldCard8.Count == 1 && PlayerFieldCard8.Count == 0)
            {
                if (chekWin == "WIN" || chekWin == "Lose")
                    return;
                CardInfoScr cardE8 = EnemyFieldCard8[0].GetComponent<CardInfoScr>();
                DamageHero(cardE8);
            }
        }
        

    }
    
    public void fight(CardInfoScr card1, CardInfoScr card2, int e)
    {
        card2.SelfCard.GetDamage(card1.SelfCard.Attack);
        if (!card2.SelfCard.IsAlive)
        {
            
            DestroyCard(card2, e);
        }
        else
            card2.RefreshData();
    }
    
    void DestroyCard(CardInfoScr card, int e)
    {

        if (IsPlayerTurn)
        {
            if(e==1)
                EnemyFieldCard1.Remove(card);
            if (e == 2)
                EnemyFieldCard2.Remove(card);
            if (e == 3)
                EnemyFieldCard3.Remove(card);
            if (e == 4)
                EnemyFieldCard4.Remove(card);
            if (e == 5)
                EnemyFieldCard5.Remove(card);
            if (e == 6)
                EnemyFieldCard6.Remove(card);
            if (e == 7)
                EnemyFieldCard7.Remove(card);
            if (e == 8)
                EnemyFieldCard8.Remove(card);

            EnemyFieldCards.Remove(card);
        }
        else
        {
            if (e == 1)
                PlayerFieldCard1.Remove(card);
            if (e == 2)
                PlayerFieldCard2.Remove(card);
            if (e == 3)
                PlayerFieldCard3.Remove(card);
            if (e == 4)
                PlayerFieldCard4.Remove(card);
            if (e == 5)
                PlayerFieldCard5.Remove(card);
            if (e == 6)
                PlayerFieldCard6.Remove(card);
            if (e == 7)
                PlayerFieldCard7.Remove(card);
            if (e == 8)
                PlayerFieldCard8.Remove(card);

            PlayerFieldCards.Remove(card);
        }
        Destroy(card.gameObject);
        
    }

    void ShowHP()
    {
        EnemyHPTxt.text = EnemyHP.ToString();
        PlayerHPTxt.text = PlayerHP.ToString();
    }

    public void DamageHero(CardInfoScr card)
    {
        if (IsPlayerTurn)
        {
            EnemyHP = Mathf.Clamp(EnemyHP - card.SelfCard.Attack, 0, int.MaxValue);
        }else
        {
            PlayerHP = Mathf.Clamp(PlayerHP - card.SelfCard.Attack, 0, int.MaxValue);
        }
        ShowHP();
        ChekForResult();
    }

    public void ChekForResult()
    {
        if (EnemyHP == 0 || PlayerHP==0)
        {
            ResultGO.SetActive(true);
            StopAllCoroutines();

            if (EnemyHP == 0)
            {
                RezultTxt.text = "VICTORY";
                chekWin = "WIN";
                GetComponent<WinOrLose>().PanelWinChange(75, 50);
            }
            else
            {
                RezultTxt.text = "LOSE";
                chekWin = "Lose";
                GetComponent<WinOrLose>().PanelWinChange(50, 25);
            }
        }
    }
    void GiveNewCards(bool k)
    {
        if (k == false)
        {
            if (EnemyHandCards.Count != 8)
                GiveCardToHand(CurrentGame.EnemyDeck, EnemyHand);
        }
        if (k == true)
        {
            if (PlayerHandCards.Count != 8)
                GiveCardToHand(CurrentGame.PlayerDeck, PlayerHand);
        }
    }

    public void ShowMana()
    {
        PlayerManaPoolTxt.text = PlayerManapool.ToString();
        EnemyManaPoolTxt.text = EnemyManaPool.ToString();
    }
}
