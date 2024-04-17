using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class GateAndKey : MonoBehaviour
{

    [SerializeField] Text instructions;
    [SerializeField] GameObject key;
    [SerializeField] GameObject gate;
    [SerializeField] Animator animator;
    [SerializeField] AudioClip audioClip;
    [SerializeField] GameObject message;
    [SerializeField] GameObject paper;
    [SerializeField] Text tMessage;


    private AudioSource audioSource;
    private OpenGate openGate; 
    private bool gotKey = false;
    private bool checkKey= false;
    private int control = 0;

    // Start is called before the first frame update
    void Start()
    {
        openGate = GameObject.FindObjectOfType<OpenGate>();
       audioSource = GetComponent<AudioSource>();
       // audioSource.clip = audioClip;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E) && checkKey)
        {
            audioSource.Play();
            instructions.text = "";
            Object.Destroy(key);
            gotKey = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key")) 
        {
            instructions.text = "Press [E] to collect Key";
            checkKey = true;
        
        }
        if (other.CompareTag("Gate") && gotKey == false)
        {
            instructions.text = "Find key to unlock the gate";
            UIGameMenu.UI.ChangeUI("Follow the music");
            Invoke("ClearText", 3);
        }
        else if (other.CompareTag("Gate") && gotKey == true)
        {
            openGate.GateMove();
        }

        if(other.CompareTag("Message"))
        {
            control++;
            message.SetActive(true);
            paper.SetActive(false);

            switch (control)
            {
                case 7:
                   tMessage.text = "dO yoU ThInk yoU cAn ScApe?" + "\n" + "\n" + "\n";
                    UIGameMenu.UI.ChangeUI("Press [space] to close message");
                    Invoke("ClearText", 3);
                    break;

                case 2:
                    tMessage.text = "WHY ME?????" + "\n" + "\n";
                    UIGameMenu.UI.ChangeUI("Press [space] to close message");
                    Invoke("ClearText", 3);
                    break;
                case 3:
                    tMessage.text = "I HatE YoU" + "\n" + "\n";
                    UIGameMenu.UI.ChangeUI("Press [space] to close message");
                    Invoke("ClearText", 3);
                    break;
                case 4:
                    tMessage.text = "You're STUCK hEre" + "\n" + "\n";
                    UIGameMenu.UI.ChangeUI("Press [space] to close message");
                    Invoke("ClearText", 3);
                    break;
                case 5:
                    tMessage.text = "iF IM StayiNg YoU aRe Too" + "\n" + "\n";
                    UIGameMenu.UI.ChangeUI("Press [space] to close message");
                    Invoke("ClearText", 3);
                    break;

                case 6:
                   tMessage.text = "IlL coMe for YOU" + "\n" + "\n";
                    UIGameMenu.UI.ChangeUI("Press [space] to close message");
                    Invoke("ClearText", 3);
                    break;
                case 1:
                    tMessage.text = "You can run away, leave my cold body behind. " + "\n" + "BUT I WONT LET YOUR MIND REST";
                    break;

                


                    

            }


        }

    }

    private void ClearText()
    {
        instructions.text = "";
        tMessage.text = "";

        message.SetActive(false);

    }




}
