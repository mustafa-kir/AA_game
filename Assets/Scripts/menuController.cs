using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuController : MonoBehaviour
{
    public GameObject[] menus;

    public gameManager gameManager;
    
  
    public void mainMenuCanvas()
    {

    }

    public void btn_playGame()
    {
        menus[1].SetActive(true);
        menus[0].SetActive(false);
        gameManager.StartGame();
        
    }
}
