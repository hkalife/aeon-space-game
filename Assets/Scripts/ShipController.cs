using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{

    [SerializeField]
    private float shipSpeed = 10.0f;

    private float forwardAcceleration = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) {
            shipSpeed = Mathf.Lerp(shipSpeed, 100.0f, forwardAcceleration * Time.deltaTime);
        } else {
            shipSpeed = Mathf.Lerp(shipSpeed, 25.0f, forwardAcceleration * Time.deltaTime);
        }
        transform.Rotate(Input.GetAxis("Vertical"), 0.0f, -Input.GetAxis("Horizontal"));
        transform.position += transform.forward * Time.deltaTime * shipSpeed;
    }
}
