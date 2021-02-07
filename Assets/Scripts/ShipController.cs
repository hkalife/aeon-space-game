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

    Quaternion originalRotationShipMesh;
    Vector3 originalRotationController;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;

        originalRotationShipMesh = this.gameObject.transform.GetChild(0).rotation;
        originalRotationController = transform.rotation.eulerAngles;
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

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
            GameObject newLeftLaser = Instantiate(leftLaser, leftLaser.transform.position, leftLaser.transform.rotation);
            GameObject newRightLaser = Instantiate(rightLaser, rightLaser.transform.position, rightLaser.transform.rotation);
            newLeftLaser.SetActive(true);
            newRightLaser.SetActive(true);
        }

        OriginalRotation();
    }

    float ConvertEulerToNegative(float eulerAngle) {
        return (eulerAngle > 180) ? eulerAngle - 360 : eulerAngle;
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
