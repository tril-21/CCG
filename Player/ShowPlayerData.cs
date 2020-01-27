using UnityEngine;
using TMPro;
using MySql.Data.MySqlClient;
using System.IO;


public class ShowPlayerData : MonoBehaviour {



    public TextMeshProUGUI PlayerXP;
    public TextMeshProUGUI PlayerMoney;
    // Use this for initialization
    void Start () {
        //ShowXP();
	}
	
    public void ShowXP(string data)
    {
        string connect = "server=localhost;user=root;database=userdata;password=Bkmzpfv210696";
        MySqlConnection conn = new MySqlConnection(connect);
        conn.Open();
        string sql = "SELECT NowXP, MaxXP FROM user WHERE Login="+"'"+data+"'";
        MySqlCommand command = new MySqlCommand(sql, conn);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            //CardManager.AllCards.Add(new Card(reader[0].ToString(), reader[1].ToString(), int.Parse(reader[2].ToString()), int.Parse(reader[3].ToString()), int.Parse(reader[4].ToString()), reader[6].ToString(), reader[5].ToString()));
            PlayerXP.text = reader[0].ToString() + "/" + reader[1].ToString();
        }
        conn.Close();
    }

    public void ShowMoney(string data)
    {
        string connect = "server=localhost;user=root;database=userdata;password=Bkmzpfv210696";
        MySqlConnection conn = new MySqlConnection(connect);
        conn.Open();
        string sql = "SELECT Money FROM user WHERE Login=" + "'" + data + "'";
        MySqlCommand command = new MySqlCommand(sql, conn);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            PlayerMoney.text = reader[0].ToString();
        }
        conn.Close();
    }

    public void ChangeXP(int XP, string data)
    {
        int nowXp=0;
        int maxXp=0;
        int newXP=0;
        int lvl = 0;
        string connect = "server=localhost;user=root;database=userdata;password=Bkmzpfv210696";
        MySqlConnection conn = new MySqlConnection(connect);
        conn.Open();
        string sql = "SELECT Level, NowXP, MaxXP FROM user WHERE Login=" + "'" + data + "'";
        MySqlCommand command = new MySqlCommand(sql, conn);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            //CardManager.AllCards.Add(new Card(reader[0].ToString(), reader[1].ToString(), int.Parse(reader[2].ToString()), int.Parse(reader[3].ToString()), int.Parse(reader[4].ToString()), reader[6].ToString(), reader[5].ToString()));
            //PlayerXP.text = reader[0].ToString() + "/" + reader[1].ToString();
            //PlayerMoney.text = reader[2].ToString();
            lvl = int.Parse(reader[0].ToString());
            nowXp = int.Parse(reader[1].ToString());
            maxXp = int.Parse(reader[2].ToString());
        }
        conn.Close();
        newXP = nowXp + XP;
        Debug.Log(nowXp+ " " + XP + " " + newXP);
        if (newXP >= maxXp)
        {
            nowXp = newXP - maxXp;
            maxXp = maxXp + 100;
            lvl++;
        } else
        {
            nowXp += XP;
        }
        Debug.Log(nowXp + " " + XP + " " + newXP);
        conn.Open();
        string sqlUpdate = "UPDATE user SET NowXP = @nowXP, MaxXP = @maxXP, Level = @level WHERE Login=" + "'" + data + "'";
        MySqlCommand cmd = new MySqlCommand(sqlUpdate, conn);
        cmd.Parameters.AddWithValue("@nowXP", nowXp);
        cmd.Parameters.AddWithValue("@maxXP", maxXp);
        cmd.Parameters.AddWithValue("@level", lvl);
        cmd.ExecuteNonQuery();
        conn.Close();

    }

    public void BuyCard(int price, string data)
    {
        int nowMoney=0;

        string connect = "server=localhost;user=root;database=userdata;password=Bkmzpfv210696";
        MySqlConnection conn = new MySqlConnection(connect);
        conn.Open();
        string sql = "SELECT Money FROM user WHERE Login=" + "'" + data + "'";
        MySqlCommand command = new MySqlCommand(sql, conn);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            //CardManager.AllCards.Add(new Card(reader[0].ToString(), reader[1].ToString(), int.Parse(reader[2].ToString()), int.Parse(reader[3].ToString()), int.Parse(reader[4].ToString()), reader[6].ToString(), reader[5].ToString()));
            //PlayerXP.text = reader[0].ToString() + "/" + reader[1].ToString();
            //PlayerMoney.text = reader[2].ToString();
            nowMoney = int.Parse(reader[0].ToString());
            
        }
        conn.Close();

        if (price > nowMoney)
        {
            return;
        } else
        {
            nowMoney -= price;
            conn.Open();
            string sqlUpdate = "UPDATE user SET Money = @money WHERE Login=" + "'" + data + "'";
            MySqlCommand cmd = new MySqlCommand(sqlUpdate, conn);
            cmd.Parameters.AddWithValue("@money", nowMoney);
            cmd.ExecuteNonQuery();
            conn.Close();
            GetComponent<ShopCard>().Open();
        }

    }
    public void ChangeMoney(int price, string data)
    {
        int nowMoney = 0;

        string connect = "server=localhost;user=root;database=userdata;password=Bkmzpfv210696";
        MySqlConnection conn = new MySqlConnection(connect);
        conn.Open();
        string sql = "SELECT Money FROM user WHERE Login=" + "'" + data + "'";
        MySqlCommand command = new MySqlCommand(sql, conn);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            nowMoney = int.Parse(reader[0].ToString());
        }
        conn.Close();

        nowMoney += price;
        conn.Open();
        string sqlUpdate = "UPDATE user SET Money = @money WHERE Login=" + "'" + data + "'";
        MySqlCommand cmd = new MySqlCommand(sqlUpdate, conn);
        cmd.Parameters.AddWithValue("@money", nowMoney);
        cmd.ExecuteNonQuery();
        conn.Close();
        

    }

    public void SaveFile(string data, string fileName)
    {
        StreamWriter sw = new StreamWriter(fileName);
        sw.WriteLine(data);
        sw.Close();
    }

    public string ReadFile(string fileName)
    {
        StreamReader sr = new StreamReader(fileName);
        string line;
        line = sr.ReadLine();
        sr.Close();
        return line;
    }
}
