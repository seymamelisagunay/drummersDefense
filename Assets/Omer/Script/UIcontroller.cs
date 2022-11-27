using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIcontroller : MonoBehaviour
{

    Scene scene;
    private void Start()
    {
        scene = SceneManager.GetActiveScene();
    }
    // Update is called once per frame
    void Update()
    {
        

 
    }

    public void playButton()
    {
         SceneManager.LoadScene(1);
    }

    public void exitButton()
    {
        Debug.Log("App Quit  - UI");
        Application.Quit();
       
    }
    
}

