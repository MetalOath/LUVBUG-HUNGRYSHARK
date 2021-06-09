using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    Vector3 movementVector;
    private Rigidbody rigidBody;

    //Quaternion rotationVector;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, Input.GetAxis("Horizontal"));

        if (Input.GetAxis("Vertical") > 0f)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 20);
        }

        if (Input.GetAxis("Jump") > 0f)
        {
            transform.Translate(Vector3.up * Time.deltaTime * 20);
        }
        else if (Input.GetAxis("Jump") < 0f)
        {
            transform.Translate(Vector3.down * Time.deltaTime * 20);
        }
    }
}
