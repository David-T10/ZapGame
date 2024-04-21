using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerObject;
    void Update()
    {
        transform.position = new Vector3(playerObject.position.x, playerObject.position.y, transform.position.z);
    }
}
