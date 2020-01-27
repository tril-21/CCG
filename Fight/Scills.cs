using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scills : MonoBehaviour {

    public int manacost;
    public int damage;

    public void DamageAll()
    {
        manacost = 6;
        damage = 3;
        if (GetComponent<GameManagerScr>().PlayerManapool < manacost)
            return;
        else
            GetComponent<GameManagerScr>().PlayerManapool = Mathf.Clamp(GetComponent<GameManagerScr>().PlayerManapool - manacost, 0, int.MaxValue);
        GetComponent<GameManagerScr>().ShowMana();

        if (GetComponent<GameManagerScr>().EnemyFieldCards.Count > 0 && GetComponent<GameManagerScr>().IsPlayerTurn)
        {
                if (GetComponent<GameManagerScr>().EnemyFieldCard1.Count == 1)
                {
                    CardInfoScr card1 = GetComponent<GameManagerScr>().EnemyFieldCard1[0].GetComponent<CardInfoScr>();
                    card1.SelfCard.GetDamage(damage);
                    if (!card1.SelfCard.IsAlive)
                    {
                        GetComponent<GameManagerScr>().EnemyFieldCard1.Remove(card1);
                        GetComponent<GameManagerScr>().EnemyFieldCards.Remove(card1);
                        Destroy(card1.gameObject);
                    }
                    else
                    {
                        card1.RefreshData();
                    }

                }
                if (GetComponent<GameManagerScr>().EnemyFieldCard2.Count == 1)
                {
                    CardInfoScr card2 = GetComponent<GameManagerScr>().EnemyFieldCard2[0].GetComponent<CardInfoScr>();
                    card2.SelfCard.GetDamage(damage);
                    if (!card2.SelfCard.IsAlive)
                    {
                        GetComponent<GameManagerScr>().EnemyFieldCard2.Remove(card2);
                        GetComponent<GameManagerScr>().EnemyFieldCards.Remove(card2);
                        Destroy(card2.gameObject);
                    }
                    else
                    {
                        card2.RefreshData();
                    }

                }
                if (GetComponent<GameManagerScr>().EnemyFieldCard3.Count == 1)
                {
                    CardInfoScr card3 = GetComponent<GameManagerScr>().EnemyFieldCard3[0].GetComponent<CardInfoScr>();
                    card3.SelfCard.GetDamage(damage);
                    if (!card3.SelfCard.IsAlive)
                    {
                        GetComponent<GameManagerScr>().EnemyFieldCard3.Remove(card3);
                        GetComponent<GameManagerScr>().EnemyFieldCards.Remove(card3);
                        Destroy(card3.gameObject);
                    }
                    else
                    {
                        card3.RefreshData();
                    }

                }
                if (GetComponent<GameManagerScr>().EnemyFieldCard4.Count == 1)
                {
                    CardInfoScr card4 = GetComponent<GameManagerScr>().EnemyFieldCard4[0].GetComponent<CardInfoScr>();
                    card4.SelfCard.GetDamage(damage);
                    if (!card4.SelfCard.IsAlive)
                    {
                        GetComponent<GameManagerScr>().EnemyFieldCard4.Remove(card4);
                        GetComponent<GameManagerScr>().EnemyFieldCards.Remove(card4);
                        Destroy(card4.gameObject);
                    }
                    else
                    {
                        card4.RefreshData();
                    }

                }
                if (GetComponent<GameManagerScr>().EnemyFieldCard5.Count == 1)
                {
                    CardInfoScr card5 = GetComponent<GameManagerScr>().EnemyFieldCard5[0].GetComponent<CardInfoScr>();
                    card5.SelfCard.GetDamage(damage);
                    if (!card5.SelfCard.IsAlive)
                    {
                        GetComponent<GameManagerScr>().EnemyFieldCard5.Remove(card5);
                        GetComponent<GameManagerScr>().EnemyFieldCards.Remove(card5);
                        Destroy(card5.gameObject);
                    }
                    else
                    {
                        card5.RefreshData();
                    }

                }
                if (GetComponent<GameManagerScr>().EnemyFieldCard6.Count == 1)
                {
                    CardInfoScr card6 = GetComponent<GameManagerScr>().EnemyFieldCard6[0].GetComponent<CardInfoScr>();
                    card6.SelfCard.GetDamage(damage);
                    if (!card6.SelfCard.IsAlive)
                    {
                        GetComponent<GameManagerScr>().EnemyFieldCard6.Remove(card6);
                        GetComponent<GameManagerScr>().EnemyFieldCards.Remove(card6);
                        Destroy(card6.gameObject);
                    }
                    else
                    {
                        card6.RefreshData();
                    }

                }
                if (GetComponent<GameManagerScr>().EnemyFieldCard7.Count == 1)
                {
                    CardInfoScr card7 = GetComponent<GameManagerScr>().EnemyFieldCard7[0].GetComponent<CardInfoScr>();
                    card7.SelfCard.GetDamage(damage);
                    if (!card7.SelfCard.IsAlive)
                    {
                        GetComponent<GameManagerScr>().EnemyFieldCard7.Remove(card7);
                        GetComponent<GameManagerScr>().EnemyFieldCards.Remove(card7);
                        Destroy(card7.gameObject);
                    }
                    else
                    {
                        card7.RefreshData();
                    }

                }
                if (GetComponent<GameManagerScr>().EnemyFieldCard8.Count == 1)
                {
                    CardInfoScr card8 = GetComponent<GameManagerScr>().EnemyFieldCard8[0].GetComponent<CardInfoScr>();
                    card8.SelfCard.GetDamage(damage);
                    if (!card8.SelfCard.IsAlive)
                    {
                        GetComponent<GameManagerScr>().EnemyFieldCard8.Remove(card8);
                        GetComponent<GameManagerScr>().EnemyFieldCards.Remove(card8);
                        Destroy(card8.gameObject);
                    }
                    else
                    {
                        card8.RefreshData();
                    }

                }
          
        }
       
    }
    
}
