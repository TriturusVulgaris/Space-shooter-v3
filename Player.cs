using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [Header("Move function")]

    [SerializeField]
    Rigidbody body;
    [SerializeField]
    [Range(1.0f, 20.0f)]
    float speed = 10f;

    [Header("Fire function")]

    [SerializeField]
    GameObject laserBullet;
    [SerializeField]
    Transform laserCanon;

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
        else
        {
            move = Vector3.zero;
        }

        if (Input.GetButtonDown("Fire1")) {
            Instantiate(laserBullet, laserCanon.position, laserCanon.rotation);
        }

    }

    

    private void FixedUpdate()
    {
        body.velocity = move;
    }
}
