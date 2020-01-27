using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;
using MySql.Data.MySqlClient;

public class inpuSave : MonoBehaviour {

    public GameObject namePan;

    public GameObject input;
    public GameObject registr;

    public InputField login;
    public InputField password;

    public InputField RegPassword;
    public InputField RegLogin;
    public InputField RegEmail;
    public InputField RegCopyPassword;

    public Toggle zap;
    public Text Error;

    public Text ErrorLogin;
    public Text ErrorPassword;
    public Text ErrorEmail;

    private Save sv = new Save();
    private string path;
	// Use this for initialization
	void Start () {
        path = Path.Combine(Application.dataPath, "Save.json");
        if (File.Exists(path))
        {
            sv = JsonUtility.FromJson<Save>(File.ReadAllText(path));
            login.text = sv.Login;
            password.text = sv.Password;
        }
	}
	
    public void InputGame()
    {
        bool err = true;
        string connect = "server=localhost;user=root;database=userdata;password=Bkmzpfv210696";
        MySqlConnection conn = new MySqlConnection(connect);
        conn.Open();
        string sql = "SELECT Login, Password FROM user ";
        MySqlCommand command = new MySqlCommand(sql, conn);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            if (reader[0].ToString() == login.text && reader[1].ToString() == password.text)
            {
                if (zap== true)
                {
                    sv.Login = login.text;
                    sv.Password = password.text;
                    File.WriteAllText(path, JsonUtility.ToJson(sv));
                }
                SaveComponent(login.text);
                err = false;
                break;
            }
            
        }
        conn.Close();
        if (err == true)
        {
            Error.text = "Incorrect login or password!";
        }
        else
        {
            GetComponent<LoadFight>().MenuOfFight();
        }
    }

    public void GoRegistr()
    {
        input.SetActive(false);
        registr.SetActive(true);
    }

    public void Registration()
    {
        string connect = "server=localhost;user=root;database=userdata;password=Bkmzpfv210696";
        MySqlConnection conn = new MySqlConnection(connect);
        conn.Open();
        string sel = "SELECT Login, Email FROM user ";
        MySqlCommand command = new MySqlCommand(sel, conn);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            if (reader[0].ToString() == RegLogin.text||RegLogin.text==""||RegLogin.text.Length<4)
            {
                conn.Close();
                ErrorLogin.text = "Incorrect login";
                return;
            }
            if (reader[1].ToString() == RegEmail.text||RegEmail.text=="")
            {
                conn.Close();
                ErrorEmail.text = "Incorrect email";
                return;
            }
        }
        conn.Close();
        if (RegPassword.text!=RegCopyPassword.text||RegPassword.text==""||RegPassword.text.Length<6)
        {
            conn.Close();
            ErrorPassword.text = "Incorrect password";
            return;
        }
        conn.Open();
        string ins = "INSERT INTO user (Login, Password, Email, Level, NowXP, MaxXP, Money, Person, MyCard, TroopeOne, TroopeTwo, TroopeThree)" +
            "VALUES (@login, @password, @email, @level, @nowXP, @maxXP, @money, @person, @myCard, @troopeOne, @troopeTwo, @troopeThree);";
        MySqlCommand cmd = new MySqlCommand(ins, conn);
        string pers = RegLogin.text + "Person";
        string myc = RegLogin.text + "myCard";
        string tr1 = RegLogin.text + "troopeOne";
        string tr2 = RegLogin.text + "troopeTwo";
        string tr3 = RegLogin.text + "troopeThree";

        cmd.Parameters.AddWithValue("@login", RegLogin.text);
        cmd.Parameters.AddWithValue("@password", RegPassword.text);
        cmd.Parameters.AddWithValue("@email", RegEmail.text);
        cmd.Parameters.AddWithValue("@level", 1);
        cmd.Parameters.AddWithValue("@nowXP", 0);
        cmd.Parameters.AddWithValue("@maxXP", 100);
        cmd.Parameters.AddWithValue("@money", 250);
        cmd.Parameters.AddWithValue("@person", pers.ToLower());
        cmd.Parameters.AddWithValue("@myCard", myc.ToLower());
        cmd.Parameters.AddWithValue("@troopeOne", tr1.ToLower());
        cmd.Parameters.AddWithValue("@troopeTwo", tr2.ToLower());
        cmd.Parameters.AddWithValue("@troopeThree", tr3.ToLower());
        cmd.ExecuteNonQuery();

        conn.Close();

        conn.Open();
        string create = "CREATE TABLE " +"`"+pers.ToLower()+"` " +
            "(id INT(11) NOT NULL AUTO_INCREMENT, " + "IEnter INT(11), Points INT(11), Healt INT(11), Mana INT(11), "
            + "Scill1 INT(11), Scill2 INT(11), Scill3 INT(11), Scill4 INT(11), Scill5 INT(11), Scill6 INT(11), Scill7 INT(11), Scill8 INT(11), Scill9 INT(11), PRIMARY KEY (id))";
        MySqlCommand createTable = new MySqlCommand(create, conn);
        createTable.ExecuteNonQuery();
        conn.Close();

        conn.Open();
        string createMycard = "CREATE TABLE " + "`" + myc.ToLower() + "` " +
            "(id INT(11) NOT NULL AUTO_INCREMENT, " + "NameCard VARCHAR(45), RarityCard VARCHAR(45), PreparationCard INT(11), AttackCard INT(11), DefenseCard INT(11), Skills INT(11), ImgName VARCHAR(45), PRIMARY KEY (id))";
            MySqlCommand CreateMyCard = new MySqlCommand(createMycard, conn);
        CreateMyCard.ExecuteNonQuery();
        conn.Close();

        conn.Open();
        string createTroope1 = "CREATE TABLE " + "`" +tr1.ToLower()+ "` " +
            "(id INT(11) NOT NULL AUTO_INCREMENT, " + "NameCard VARCHAR(45), RarityCard VARCHAR(45), PreparationCard INT(11), AttackCard INT(11), DefenseCard INT(11), Skills INT(11), ImgName VARCHAR(45), PRIMARY KEY (id))";
        MySqlCommand CreateTroope1 = new MySqlCommand(createTroope1, conn);
        CreateTroope1.ExecuteNonQuery();
        conn.Close();

        conn.Open();
        string createTroope2 = "CREATE TABLE " + "`"+ tr2.ToLower() + "` " +
            "(id INT(11) NOT NULL AUTO_INCREMENT, " + "NameCard VARCHAR(45), RarityCard VARCHAR(45), PreparationCard INT(11), AttackCard INT(11), DefenseCard INT(11), Skills INT(11), ImgName VARCHAR(45), PRIMARY KEY (id))";
        MySqlCommand CreateTroope2 = new MySqlCommand(createTroope2, conn);
        CreateTroope2.ExecuteNonQuery();
        conn.Close();

        conn.Open();
        string createTroope3 = "CREATE TABLE " + "`" + tr3.ToLower() + "` " +
            "(id INT(11) NOT NULL AUTO_INCREMENT, " + "NameCard VARCHAR(45), RarityCard VARCHAR(45), PreparationCard INT(11), AttackCard INT(11), DefenseCard INT(11), Skills INT(11), ImgName VARCHAR(45), PRIMARY KEY (id))";
        MySqlCommand CreateTroope3 = new MySqlCommand(createTroope3, conn);
        CreateTroope3.ExecuteNonQuery();
        conn.Close();

        input.SetActive(true);
        registr.SetActive(false);

    }

    public void SaveComponent(string user)
    {
        string connect = "server=localhost;user=root;database=userdata;password=Bkmzpfv210696";
        MySqlConnection conn = new MySqlConnection(connect);
        conn.Open();
        string sel = "SELECT Person, MyCard, TroopeOne, TroopeTwo, TroopeThree  FROM user WHERE Login="+"'"+user+"'";
        MySqlCommand command = new MySqlCommand(sel, conn);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            GetComponent<ShowPlayerData>().SaveFile(user, "username.txt");
            GetComponent<ShowPlayerData>().SaveFile(reader[0].ToString(), "person.txt");
            GetComponent<ShowPlayerData>().SaveFile(reader[1].ToString(), "mycard.txt");
            GetComponent<ShowPlayerData>().SaveFile(reader[2].ToString(), "troopeone.txt");
            GetComponent<ShowPlayerData>().SaveFile(reader[3].ToString(), "troopetwo.txt");
            GetComponent<ShowPlayerData>().SaveFile(reader[4].ToString(), "troopethree.txt");
        }
        conn.Close();
    }
}

[Serializable]
public class Save
{
    public string Login;
    public string Password;
}
