using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpace : MonoBehaviour
{

    public float speed = 10f;

    float roll;
    float pitch;
    float yaw;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        roll = Input.GetAxisRaw("Horizontal");
        pitch = Input.GetAxisRaw("Vertical");

        transform.Rotate(Vector3.back * roll * 100f * Time.deltaTime, Space.Self);
        transform.Rotate(Vector3.right * pitch * 100f * Time.deltaTime, Space.Self);

        if (Input.GetKey("space")) {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
