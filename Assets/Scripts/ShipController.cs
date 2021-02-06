using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{

    [SerializeField]
    private float shipSpeed = 10.0f;

    private float forwardAcceleration = 2.5f;

    [SerializeField]
    private GameObject leftLaser;

    [SerializeField]
    private GameObject rightLaser;

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
        transform.Rotate(Input.GetAxis("Vertical") * 5.0f, 0.0f, -Input.GetAxis("Horizontal") * 5.0f);
        transform.position += transform.forward * Time.deltaTime * shipSpeed;

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
            GameObject newLeftLaser = Instantiate(leftLaser, leftLaser.transform.position, leftLaser.transform.rotation);
            GameObject newRightLaser = Instantiate(rightLaser, rightLaser.transform.position, rightLaser.transform.rotation);
            newLeftLaser.SetActive(true);
            newRightLaser.SetActive(true);
        }
    }
}
