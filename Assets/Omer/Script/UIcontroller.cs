using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIcontroller : MonoBehaviour
{
 


    // Update is called once per frame
    void Update()
    {
        
    }

    public void playButton()
    {
        Debug.Log("Game Start - UI");
    }

    public void exitButton()
    {
        Debug.Log("App Quit  - UI");
        Application.Quit();
       
    }
    
}

