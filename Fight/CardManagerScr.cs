using System.Collections.Generic;

using UnityEngine;
using MySql.Data.MySqlClient;

public struct Card
{
    public string Name;
    public Sprite Logo;
    public int Attack, Defense, Preparation;
    public string Rarity, Set;
    public string path;

    public bool IsAlive
    {
        get
        {
            return Defense > 0;
        }
    }

    public Card(string name, string logoPath, int attack, int defense, int prep, string rarity, string set)
    {
        Name = name;
        Logo = UnityEngine.Resources.Load<Sprite>(logoPath);
        Attack = attack;
        Defense = defense;
        Preparation = prep;
        Rarity = rarity;
        Set = set;
        path = logoPath;
    }

    public void GetDamage(int dmg)
    {
        Defense -= dmg;
    }
}
public static class CardManager
{
    public static List<Card> AllCards;  //shop box1
    public static List<Card> MyAllCards;  //CreateTroop
    public static List<Card> TroopeOne;
}

public class CardManagerScr : MonoBehaviour {

    public void Awake()
    {
        Box1();
        MyTroopeOneCard(GetComponent<ShowPlayerData>().ReadFile("troopeone.txt"));
    }
    
    public void Box1()
    {
        CardManager.AllCards = new List<Card>();
        string connect = "server=localhost;user=root;database=allcards;password=Bkmzpfv210696";
        MySqlConnection conn = new MySqlConnection(connect);
        conn.Open();
        string sql = "SELECT NameCard, ImgName, AttackCard, DefenseCard, PreparationCard, RarityCard FROM standard";
        MySqlCommand command = new MySqlCommand(sql, conn);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            CardManager.AllCards.Add(new Card(reader[0].ToString(), reader[1].ToString(), int.Parse(reader[2].ToString()), int.Parse(reader[3].ToString()), int.Parse(reader[4].ToString()), reader[5].ToString(), "standard"));
        }
        conn.Close();
    }
    
    public void MyCardSave(Card card, string sql)
    {
        string connect = "server=localhost;user=root;database=userdata;password=Bkmzpfv210696";
        MySqlConnection conn = new MySqlConnection(connect);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@nameCard", card.Name);
        cmd.Parameters.AddWithValue("@rarityCard", card.Rarity);
        cmd.Parameters.AddWithValue("@preparationCard", card.Preparation);
        cmd.Parameters.AddWithValue("@attackCard", card.Attack);
        cmd.Parameters.AddWithValue("@defenseCard", card.Defense);
        cmd.Parameters.AddWithValue("@scills", 0);
        cmd.Parameters.AddWithValue("@imgName", card.path);
        cmd.ExecuteNonQuery();
        conn.Close();

    }

    public void MyAllCard(string mycard)
    {
        CardManager.MyAllCards = new List<Card>();
        string connect = "server=localhost;user=root;database=userdata;password=Bkmzpfv210696";
        MySqlConnection conn = new MySqlConnection(connect);
        conn.Open();
        string sql = "SELECT NameCard, ImgName, AttackCard, DefenseCard, PreparationCard, RarityCard FROM "+ mycard;
        MySqlCommand command = new MySqlCommand(sql, conn);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            CardManager.MyAllCards.Add(new Card(reader[0].ToString(), reader[1].ToString(), int.Parse(reader[2].ToString()), int.Parse(reader[3].ToString()), int.Parse(reader[4].ToString()), reader[5].ToString(), "standard"));
        }
        conn.Close();
    }

    public void DeleteCardSql(Card card, string sql)
    {
        string connect = "server=localhost;user=root;database=userdata;password=Bkmzpfv210696";
        MySqlConnection conn = new MySqlConnection(connect);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@nameCard", card.Name);
        cmd.ExecuteNonQuery();
        conn.Close();
    }

    public void DeleteAll(string sql)
    {
        string connect = "server=localhost;user=root;database=userdata;password=Bkmzpfv210696";
        MySqlConnection conn = new MySqlConnection(connect);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand(sql, conn);
        cmd.ExecuteNonQuery();
        conn.Close();
    }

    public void MyTroopeOneCard(string tr)
    {
        CardManager.TroopeOne = new List<Card>();
        string connect = "server=localhost;user=root;database=userdata;password=Bkmzpfv210696";
        MySqlConnection conn = new MySqlConnection(connect);
        conn.Open();
        string sql = "SELECT NameCard, ImgName, AttackCard, DefenseCard, PreparationCard, RarityCard FROM "+tr;
        MySqlCommand command = new MySqlCommand(sql, conn);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            CardManager.TroopeOne.Add(new Card(reader[0].ToString(), reader[1].ToString(), int.Parse(reader[2].ToString()), int.Parse(reader[3].ToString()), int.Parse(reader[4].ToString()), reader[5].ToString(), "standard"));
        }
        conn.Close();
    }
    
}
