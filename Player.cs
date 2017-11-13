using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    Rigidbody body;
    [SerializeField]
    float speed = 10f;

    // Use this for initialization
    void Awake ()
    {
        if (!body) body = GetComponent<Rigidbody>();
    }

    void Start () {
		
}

    Vector3 move;
    // Update is called once per frame
    void Update () {
        if (Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Horizontal") != 0f)
        {
            move = new Vector3(Input.GetAxis("Horizontal") * speed, 0f, Input.GetAxis("Vertical") * speed);
        }
    }

    

    private void FixedUpdate()
    {
        body.velocity = move;
    }
}
