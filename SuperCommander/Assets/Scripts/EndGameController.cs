using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameController : MonoBehaviour
{
    public string menu;

    // Update is called once per frame
    void Update()
    {
        EndGame();   
    }

    public void EndGameReturnMenu()
    {
        SceneManager.LoadScene(menu);
    }

    public void EndGame()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
