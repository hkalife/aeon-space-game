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

    [SerializeField]
    private GameObject leftLaserPosition;

    [SerializeField]
    private GameObject rightLaserPosition;

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
            shipSpeed = Mathf.Lerp(shipSpeed, 0f, forwardAcceleration * Time.deltaTime);
        }

        transform.Rotate(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"), 0.0f);
        this.gameObject.transform.GetChild(0).Rotate(-Input.GetAxis("Horizontal"), 0.0f, 0.0f);


        transform.position += transform.forward * Time.deltaTime * shipSpeed;

        if (Input.GetKeyDown(KeyCode.Space)) {
            GameObject newLeftLaser = Instantiate(leftLaser, leftLaserPosition.transform.position, leftLaserPosition.transform.rotation);
            GameObject newRightLaser = Instantiate(rightLaser, rightLaserPosition.transform.position, rightLaserPosition.transform.rotation);
            newLeftLaser.SetActive(true);
            newRightLaser.SetActive(true);
        }

        OriginalRotation();
    }

    void OriginalRotation() {
        bool directionKeysPressed =
            Input.GetKey(KeyCode.LeftArrow)
            || Input.GetKey(KeyCode.RightArrow)
            || Input.GetKey(KeyCode.UpArrow)
            || Input.GetKey(KeyCode.DownArrow);

        if (!directionKeysPressed) {
            Quaternion rotationOR = transform.rotation;

            transform.rotation = Quaternion.Lerp(
                rotationOR,
                new Quaternion(0.0f, rotationOR.y, 0.0f, rotationOR.w),
                0.05f
            );
        }
    }
}
