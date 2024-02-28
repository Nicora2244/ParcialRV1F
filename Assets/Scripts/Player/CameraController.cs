using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Player;
    public Vector3 offset;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = Player.position + offset;
    }
}
