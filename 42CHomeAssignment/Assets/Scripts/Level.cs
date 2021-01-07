using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // We need to import the SceneManagement library so that we can use its
//classes and methods to load and manage different scenes

public class Level : MonoBehaviour
{
    public void LoadStartMenu()
    {
        /* The LoadScene method is found in the SceneManager class which is located in the SceneManagement
         * library - to use it we had to import the library.
         * LoadScene loads a scene either via its buildIndex or else via its name.
         * The StartMenu should always be the first scene and so we are loading the scene which is at index 0
         */
        SceneManager.LoadScene(0);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("LaserDefender");
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void QuitGame()
    {
        Application.Quit(); //this will quit the executable game and not while testing in the Editor
    }
}
