using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCamera : MonoBehaviour
{
    [SerializeField] private Camera cam;
    private bool zoomIn;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (zoomIn)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 6, Time.deltaTime * 4);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        zoomIn = false;
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 16, Time.deltaTime * 4);
    }

    private void OnTriggerExit(Collider other)
    {
        zoomIn = true;
    }
    
}
