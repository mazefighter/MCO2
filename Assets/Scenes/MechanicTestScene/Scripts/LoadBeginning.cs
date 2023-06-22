using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadBeginning : MonoBehaviour
{
    private float time;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 23)
        {
            SceneManager.LoadScene("HubScene 1");
            Destroy(GameObject.Find("Canvas"));
            Destroy(GameObject.Find("Save"));
        }
    }
}
