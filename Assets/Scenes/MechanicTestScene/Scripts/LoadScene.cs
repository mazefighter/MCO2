using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    [SerializeField] private string sceneName;
    private Rigidbody Player;
    private bool exitScene;
    private bool enterScene = true;
    private Image _image;
    private float duration = 0.5f;
    private float elapsedTime;

    [SerializeField] private int Scene;


    private void Awake()
    {
        _image = GameObject.Find("FadeImage").GetComponent<Image>();
        Player = GameObject.Find("Player").GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (enterScene)
        {
            elapsedTime += Time.deltaTime;
            float percentageComplete = elapsedTime / duration;


            _image.color = new Color(0, 0, 0, Mathf.Lerp(1, 0, percentageComplete));
            if (elapsedTime > 0.5f)
            {
                enterScene = false;
                elapsedTime = 0;
            }
        }
        if (exitScene)
        {
            Save save = GameObject.FindWithTag("Save").GetComponent<Save>();
            save.SaveScenePosition(Scene, Player.transform.position);
            elapsedTime += Time.deltaTime;
            float percentageComplete = elapsedTime / duration;


            _image.color = new Color(0, 0, 0, Mathf.Lerp(0, 1, percentageComplete));
            if (elapsedTime > 0.5f)
            {
                SceneManager.LoadScene(sceneName);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player.constraints = RigidbodyConstraints.FreezeAll;
            exitScene = true;
        }
        
    }
    
}
