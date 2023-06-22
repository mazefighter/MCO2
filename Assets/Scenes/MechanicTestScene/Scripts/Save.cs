using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Save : MonoBehaviour
{
    private GameObject Player;
    private UIScript _uiScript;
   [SerializeField] private List<Vector3> ScenePositions;

   [SerializeField] private GameObject Egg;
    void Start()
    {
        _uiScript = GameObject.FindWithTag("Canvas").GetComponent<UIScript>();
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Save");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        SceneManager.activeSceneChanged += SceneManagerOnactiveSceneChanged;
    }

    private void Update()
    {
        
    }

    private void SceneManagerOnactiveSceneChanged(Scene arg0, Scene arg1)
    {
        Player = GameObject.FindWithTag("Player");
        if (gameObject == null)
        {
            Destroy(gameObject);
        }
        else
        {
            LoadScenePosition();
            DestroyCollectedEggs();
        }
    }

    public void SaveScenePosition(int scene, Vector3 position)
   {
       ScenePositions[scene] = position;
   }

    void DestroyCollectedEggs()
    {
        if (SceneManager.GetActiveScene().name == "HubScene")
        {
            Egg = GameObject.Find("FireEgg");
            if (_uiScript.GetElementSlot(1) != null)
            {
                Destroy(Egg);
            }
        }
        if (SceneManager.GetActiveScene().name == "CaveScene")
        {
            Egg = GameObject.Find("WaterEgg");
            if (_uiScript.GetElementSlot(2) != null)
            {
                Destroy(Egg);
            }
        }
        if (SceneManager.GetActiveScene().name == "WaterEndScene")
        {
            Egg = GameObject.Find("EarthEgg");
            if (_uiScript.GetElementSlot(3) != null)
            {
                Destroy(Egg);
            }
        }
        if (SceneManager.GetActiveScene().name == "Mausoleum")
        {
            Egg = GameObject.Find("WindEgg");
            if (_uiScript.GetElementSlot(0) != null)
            {
                Destroy(Egg);
            }
        }
    }
    void LoadScenePosition()
    {
        if (SceneManager.GetActiveScene().name == "HubScene")
        {
            Player.transform.position = ScenePositions[0];
        }
    }
}
