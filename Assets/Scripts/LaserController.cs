using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    private IEnumerator coroutine;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isActiveAndEnabled) {
            transform.position += transform.forward * Time.deltaTime * 500;
        }
    }

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "Target") {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }

}
