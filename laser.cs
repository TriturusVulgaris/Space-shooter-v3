using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour {

    [SerializeField]
    Rigidbody body;

    [SerializeField]
    [Range(1f, 15f)]
    float speed = 10f;


    // Use this for initialization
    void Awake() {
        if (!body) body = GetComponent<Rigidbody>();
        body.velocity = new Vector3(0f, 0f, speed);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Killzone") {
            Destroy(gameObject);
        }
    }

}
