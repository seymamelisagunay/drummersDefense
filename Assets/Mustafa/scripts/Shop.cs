using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shop : MonoBehaviour
{
    public static Shop instante;
    public Text moneyText;
    public GameObject shopPanel;
    public GameObject tower1;
    public GameObject tower2;
    public float tower1Price;
    public float tower2Price;

    private void Awake()
    {
        tower1Price = tower1.GetComponent<TowerAttack>().cost;
        tower2Price = tower2.GetComponent<TowerAttack>().cost;
    }
    void Start()
    {
        instante = this;
        
    }
    private void Update()
    {
        moneyText.text = GameManager.money + "";
    }

    public void buyTower1()
    {
        if (GameManager.money>= tower1Price)
        {
            GameManager.money -= tower1Price;
            Instantiate(tower1, Vector3.up, Quaternion.identity);
            closePanel();

        }
    }
    public void buyTower2()
    {
        if (GameManager.money >= tower2Price)
        {
            GameManager.money -= tower2Price;
            Instantiate(tower2, Vector3.up, Quaternion.identity);
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
