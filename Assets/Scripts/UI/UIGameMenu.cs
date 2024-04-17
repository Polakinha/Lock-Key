//using Mono.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class UIGameMenu : MonoBehaviour
{
    [SerializeField] Button restart;
    [SerializeField] Button end;
    [SerializeField] Button pause;
    [SerializeField] Button back;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject text;
    [SerializeField] GameObject pauseButton;
    [SerializeField] GameObject splashScreen;
    [SerializeField] Text inGameIntructions;
    [SerializeField] GameObject initIntruction;
    [SerializeField] GameObject initImage;
    [SerializeField] GameObject inGameInst;
    [SerializeField] GameObject finalPanel;
    private bool isPaused = false;

    [SerializeField] GameObject message;
    [SerializeField] Text textMessage;
    public static UIGameMenu UI;

    private void Awake()
    {
        UI = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        restart.onClick.AddListener(DelayRestart);
        pause.onClick.AddListener(Pause);
        end.onClick.AddListener(DelayQuit);
        back.onClick.AddListener(Back);

    }
    private void FixedUpdate()
    {
        if (inGameIntructions.text != "") {
            Invoke("ClearText", 7);
        }
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            pauseMenu.SetActive(true);
            pauseButton.SetActive(false);
            isPaused = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            isPaused = false;
            pauseMenu.SetActive(false);
            pauseButton.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            message.SetActive(false);
            textMessage.text = "";
        }


    }

    private void DelayRestart()
    {
        Invoke("Restart", 0.4f);
    }
    private void Restart()
    {
        ScenesManager.Instance.LoadNewGame();
        text.SetActive(false);
    }
    public void Pause()
    {
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
    }
    public void Back()
    {
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
    }
    private void DelayQuit()
    {
        Invoke("Quit", 0.4f);
    }
    private void Quit()
    {
        Application.Quit();
        Debug.Log("DelayQuit");
    }

    public void ChangeUI( string text)
    {
        inGameIntructions.text = text;
    }
    private void ClearText()
    {
        inGameIntructions.text = "";

    }

    private void animationUI()
    {
       initImage.SetActive(true );
        initIntruction.SetActive(true);
        inGameInst.SetActive(true );

    }

    public void finalBlackout()
    {
        finalPanel.SetActive(true);
    }
}
