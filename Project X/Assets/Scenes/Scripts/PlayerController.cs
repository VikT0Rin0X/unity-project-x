using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 25;
    private float turnSpeed = 60;
    private float horizontalInput;
    private float verticalInput;

    private float currentPos;

    // Start is called before the first frame update
    void Start()
    {
        currentPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(speed * Time.deltaTime * verticalInput * Vector3.back);
        transform.Translate(Vector3.left * (Time.deltaTime * horizontalInput * turnSpeed));
        tiltPlayer(horizontalInput);


        if (horizontalInput != 0)
        {
            transform.position = new Vector3(transform.position.x, currentPos, transform.position.z);
        }
    }

    private void tiltPlayer(float horizontalInput)
    {
        transform.rotation = Quaternion.AngleAxis((30 * horizontalInput), Vector3.forward);
    }
}