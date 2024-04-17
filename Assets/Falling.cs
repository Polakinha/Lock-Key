using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
   [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject text;
    [SerializeField] private GameObject BackButton;

    private void OnTriggerEnter(Collider other)
    {
            if (other.CompareTag("Player"))
        {

            pausePanel.SetActive(true);
            text.SetActive(true);
            BackButton.SetActive(false);
        }
    }

}
