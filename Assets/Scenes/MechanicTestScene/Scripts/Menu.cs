using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button[] btn = new Button[3];
    [SerializeField] private Animator _animator;
    private float timer;
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
        timer += Time.deltaTime;
        if (timer > 2)
        {
            if (Random.Range(0f,10f) <= 2f)
            {
                _animator.SetTrigger("Random");
            }

            timer = 0;
        }
    }
}
