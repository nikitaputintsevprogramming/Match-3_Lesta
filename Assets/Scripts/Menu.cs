using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : RayCastInColumn
{
    public GameObject StartPanel;
    public GameObject EndPanel;

    // Start is called before the first frame update
    void Start()
    {
        StartPanel = GameObject.Find("PanelStarting");
        EndPanel = GameObject.Find("PanelEnding");

        StartPanel.SetActive(true);
        EndPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            StartPanel.SetActive(false);
        }

        if(RedColumn() == true && BlueColumn() == true && GreenColumn() == true)
        {
            EndPanel.SetActive(true);
        }        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
