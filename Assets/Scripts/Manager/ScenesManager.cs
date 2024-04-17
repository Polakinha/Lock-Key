using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public enum Scene 
        {
        MenuScene, 
        MainScene,
        EndScene
        }

    public void LoadScene(Scene scene) {

        SceneManager.LoadScene(scene.ToString());
    
    }

    public void LoadNewGame()
    {
        SceneManager.LoadScene(Scene.MainScene.ToString());
    }

    //DONT FORGET ABOUT END SCENE WHEN GAME IS OVER
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadMainMenu() {
        SceneManager.LoadScene(Scene.MenuScene.ToString());

    }
}
