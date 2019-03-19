using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadStartGameController : MonoBehaviour
{
    public string levelToLoad;

    private void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(levelToLoad); 
    }
}
