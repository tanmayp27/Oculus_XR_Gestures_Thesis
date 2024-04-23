using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    private int totalCircuits=3;

    private int circuitsConnected;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void RestartGame()
    {
        circuitsConnected = 0;

        // Scene Logic
    }

    public void CircuitConnected(bool correctNode)
    {
        if (circuitsConnected < totalCircuits && correctNode)
        {
            circuitsConnected++;
        }
        else if (!correctNode)
        {
            Debug.Log("---Mistake!----");
        }
        else if(circuitsConnected == totalCircuits)
        {
            GameWon();
        }
    }

    private void GameWon()
    {
        //Game Won UI;

        Debug.Log("Congratulations you win! Game Restarts in 5 mins");

        Invoke("RestartGame", 5f);
    }

    
}
