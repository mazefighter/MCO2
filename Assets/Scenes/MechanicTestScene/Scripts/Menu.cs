using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button[] btn = new Button[3];
    void Start()
    {
        btn[0].onClick.AddListener(Continue);
        btn[1].onClick.AddListener(Options);
        btn[2].onClick.AddListener(Exit);
        btn[0].Select();
        
    }

    private void Exit()
    {
        Application.Quit();
    }

    private void Options()
    {
        
    }

    private void Continue()
    {
        SceneManager.LoadScene("HubScene");
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
