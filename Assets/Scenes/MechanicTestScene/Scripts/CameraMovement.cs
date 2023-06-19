using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private float CameraSpeedMulti;
    void Start()
    {
        transform.position = Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, Player.transform.position, Time.deltaTime* CameraSpeedMulti);
    }
}
