using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadFight : MonoBehaviour {

    public void Fight() => Application.LoadLevel(index: 2);
    public void CardTable() => Application.LoadLevel(index: 3);
    public void MenuOfCardTable() => Application.LoadLevel(index: 1);
    public void MenuOfShopCard() => Application.LoadLevel(index: 1);
    public void Shop() => Application.LoadLevel(index: 4);
    public void MenuOfFight() => Application.LoadLevel(index: 1);
}
