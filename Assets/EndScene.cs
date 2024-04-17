using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EndScene : MonoBehaviour
{
    [SerializeField] Button end;
    [SerializeField] GameObject quit;
    [SerializeField] GameObject fade;

    // Start is called before the first frame update
    void Start()
    {
        end.onClick.AddListener(DelayQuit);
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
 
}
