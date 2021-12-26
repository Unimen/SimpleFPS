using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHaveMyEyes : MonoBehaviour
{

    public float mouseSensitivity = 100f;

    //reference from MainCamera to Player

    public Transform playerBody;

    //rotation x axis
    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        //Lock cursor on center screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    { 
        //get mouse X axis value multiply by mouseSensitivity and time of last using of method up(Update)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
