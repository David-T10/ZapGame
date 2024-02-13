using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerObject;
    void Update()
    {
        //match camera's transform to playerObject's transform so the camera always follows the player
        transform.position = new Vector3(playerObject.position.x, playerObject.position.y, transform.position.z);
    }
}
