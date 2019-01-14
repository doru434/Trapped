using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementPrototype : MonoBehaviour
{
    private Transform player;
    private Transform camera;
    public float cameraSpeed;
    public float movementSpeed;

    private void Start() {
        player = this.transform;
        camera = this.transform.Find("Camera");
    }

    private void FixedUpdate() {
        transform.Rotate(0, Input.GetAxisRaw("Mouse X") * cameraSpeed * Time.deltaTime, 0);
        camera.Rotate(-Input.GetAxisRaw("Mouse Y") * cameraSpeed * Time.deltaTime, 0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, 1 * Time.deltaTime * movementSpeed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -1 * Time.deltaTime * movementSpeed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-1 * Time.deltaTime * movementSpeed, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(1 * Time.deltaTime * movementSpeed, 0, 0);
        }
    }
}
