using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Save : MonoBehaviour
{
    private GameObject Player;
   [SerializeField] private List<Vector3> ScenePositions;
    void Start()
    {
        SceneManager.activeSceneChanged += SceneManagerOnactiveSceneChanged;
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Save");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        
    }

    private void SceneManagerOnactiveSceneChanged(Scene arg0, Scene arg1)
    {
        Player = GameObject.FindWithTag("Player");
        LoadScenePosition();
    }

    public void SaveScenePosition(int scene, Vector3 position)
   {
       ScenePositions[scene] = position;
   }

    void LoadScenePosition()
    {
        if (SceneManager.GetActiveScene().name == "HubScene")
        {
            Player.transform.position = ScenePositions[0];
        }
    }
}
