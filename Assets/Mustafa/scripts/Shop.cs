using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shop : MonoBehaviour
{
    public static Shop instante;
    public Text moneyText;
    public Text WaveTime;
    public GameObject shopPanel;
    public GameObject tower1;
    public GameObject tower2;
    public GameObject wall1;
    public float tower1Price;
    public float tower2Price;
    public float wall1Price;
    public LayerMask layer;
    RaycastHit hit;
    public bool onPresCreat;
    public AudioSource moneySpendSound;


    private void Awake()
    {
        tower1Price = tower1.GetComponent<TowerAttack>().cost;
        tower2Price = tower2.GetComponent<TowerAttack>().cost;
    }
    void Start()
    {
        instante = this;
        closePanel();
        onPresCreat = false;
        moneySpendSound = GetComponent<AudioSource>();


    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (GameManager.money >= tower1Price)
            {
                GameManager.money -= tower1Price;
                Instantiate(tower1, Vector3.up * -5, Quaternion.identity);
                closePanel();

            }
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (GameManager.money >= tower2Price)
            {
                GameManager.money -= tower2Price;
                Instantiate(tower2, Vector3.up * -5, Quaternion.identity);
                closePanel();

            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (GameManager.money >= wall1Price)
            {
                GameManager.money -= wall1Price;
                Instantiate(wall1, Vector3.up * -5, Quaternion.identity);
                closePanel();

            }
        }

        if (GameManager.intance.waveIsContinious&&shopPanel.activeSelf)
        {
            closePanel();
        }
        moneyText.text = GameManager.money + "";
        if (GameManager.intance.spawmIsStoped)
        {
            WaveTime.text = (int)(GameManager.intance.waveBreakTime - GameManager.intance.timer) + "";
        }
        else
        {
            WaveTime.text = "";
        }


        

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000, layer))
        {
            Debug.DrawLine(Camera.main.transform.position , hit.point,Color.magenta);
            if (Input.GetMouseButton(1))
            {
                if (hit.transform.tag=="wall")
                {
                    Debug.Log("giriyor walll");

                    if (hit.transform.GetComponent<ObjectPlaced>().canSeal)
                    {
                        GameManager.money += wall1Price;
                        for (int i = 0; i < hit.transform.GetComponent<ObjectPlaced>().grids.Count; i++)
                        {
                            hit.transform.GetComponent<ObjectPlaced>().grids[i].GetComponent<grid>().isOpend = true;
                            hit.transform.GetComponent<ObjectPlaced>().grids[i].GetComponent<grid>().gridColorClose();
                        }
                        Destroy(hit.transform.gameObject);
                    }
                    
                }

                if (hit.transform.tag == "tower")
                {
                    Debug.Log("giriyor tower");

                    if (hit.transform.GetComponent<ObjectPlaced>().canSeal)
                    {
                        GameManager.money += hit.transform.GetComponent<TowerAttack>().cost;
                        for (int i = 0; i < hit.transform.GetComponent<ObjectPlaced>().grids.Count; i++)
                        {
                            hit.transform.GetComponent<ObjectPlaced>().grids[i].GetComponent<grid>().isOpend = true;
                            hit.transform.GetComponent<ObjectPlaced>().grids[i].GetComponent<grid>().gridColorClose();

                        }
                        Destroy(hit.transform.gameObject);
                    }
                   
                }
                
            }

            
        }

        buyTower1btn(); buyTower2btn(); buyWallbtn(); EndShoppingBtn();
    }

    public void buyTower1()
    {
        if (GameManager.money>= tower1Price)
        {
            moneySpendSound.Play();
            GameManager.money -= tower1Price;
            Instantiate(tower1, Vector3.up*-5, Quaternion.identity);
            closePanel();

        }
    }

 
    public void buyTower2()
    {
        if (GameManager.money >= tower2Price)
        {
            moneySpendSound.Play();
            GameManager.money -= tower2Price;
            Instantiate(tower2, Vector3.up * -5, Quaternion.identity);
            closePanel();

        }
    }
    public void buyWall()
    {
        if (GameManager.money >= wall1Price)
        {
            moneySpendSound.Play();
            GameManager.money -= wall1Price;
            Instantiate(wall1, Vector3.up * -5, Quaternion.identity);
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
        GameManager.intance.waveBreakTime = 0;
        WaveTime.text = (int)(GameManager.intance.waveBreakTime - GameManager.intance.timer) + "";
        closePanel();
    }

    public void buyTower1btn()
    {
        if (Input.GetKeyDown(KeyCode.Q) && shopPanel.activeSelf)
        {
            if (GameManager.money >= tower1Price)
            {
                GameManager.money -= tower1Price;
                Instantiate(tower1, Vector3.up * -5, Quaternion.identity);
                closePanel();

            }
        }

    }


    public void buyTower2btn()
    {
        if (Input.GetKeyDown(KeyCode.W) && shopPanel.activeSelf)
        {
            if (GameManager.money >= tower2Price)
            {
                GameManager.money -= tower2Price;
                Instantiate(tower2, Vector3.up * -5, Quaternion.identity);
                closePanel();

            }
        }
    }


    public void buyWallbtn()
    {
        if (Input.GetKeyDown(KeyCode.E) && shopPanel.activeSelf)
        {
            if (GameManager.money >= wall1Price)
            {
                GameManager.money -= wall1Price;
                Instantiate(wall1, Vector3.up * -5, Quaternion.identity);
                closePanel();

            }
        }
    }

    public void EndShoppingBtn()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.intance.waveBreakTime = 0;
            WaveTime.text = (int)(GameManager.intance.waveBreakTime - GameManager.intance.timer) + "";
            closePanel();
        }

    }

 
}
 
 


 