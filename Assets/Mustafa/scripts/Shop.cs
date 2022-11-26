using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shop : MonoBehaviour
{
    public static Shop instante;
    public Text moneyText;
    public GameObject shopPanel;
    public GameObject tower;
    public float towePrice;


    void Start()
    {
        instante = this;
    }
    private void Update()
    {
        moneyText.text = GameManager.money + "";
    }

    public void buyTower()
    {
        if (GameManager.money>=towePrice)
        {
            GameManager.money -= towePrice;
            Instantiate(tower, Vector3.up, Quaternion.identity);
            closePanel();

        }
    }

    public void closePanel()
    {
        shopPanel.SetActive(false);
    }

    public void OpenPanel()
    {
        shopPanel.SetActive(true);
    }
    public void EndShopping()
    {
        closePanel();
    }
}
