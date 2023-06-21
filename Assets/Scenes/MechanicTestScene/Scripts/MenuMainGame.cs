using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuMainGame : MonoBehaviour
{
   [SerializeField] private GameObject MenuCanvas;
   private bool click;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton4)&&!click)
        {
            Time.timeScale = 0;
            MenuCanvas.SetActive(true);
            GameObject.Find("Canvas").GetComponent<Canvas>().enabled = false;
            foreach (Transform trans in MenuCanvas.transform)
            {
                
                if (trans.gameObject.name == "Button")
                {
                    trans.GetComponent<Button>().Select();
                    trans.GetComponent<Button>().onClick.AddListener(Continue);
                }
                
                if (trans.gameObject.name == "Button (1)")
                {
                    trans.GetComponent<Button>().onClick.AddListener(Exit);
                }
            }

            click = true;
        }
    }

    private void Exit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("HubScene 1");
        Destroy(GameObject.Find("Canvas"));
        Destroy(GameObject.Find("Save"));
        click = false;
    }

    private void Continue()
    {
        Time.timeScale = 1;
        GameObject.Find("Canvas").GetComponent<Canvas>().enabled = true;
        MenuCanvas.SetActive(false);
        click = false;
    }
}
