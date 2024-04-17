using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] Button start;
    [SerializeField] Button end;
    [SerializeField] GameObject panel;
    [SerializeField]private Animator startAnimator;
    [SerializeField] private Animator leaveAnimator;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        start.onClick.AddListener(Fade);
        end.onClick.AddListener(DelayQuit);
        audioSource = GetComponent<AudioSource>();
    }

    private void startGame()
    {
        audioSource.Stop();
        ScenesManager.Instance.LoadNewGame();
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

    private void Fade()
    {
        panel.SetActive(true);
        startAnimator.SetTrigger("startTrigger");
        leaveAnimator.SetTrigger("leaveTrigger");
        Invoke("startGame", 2);
    }
}

