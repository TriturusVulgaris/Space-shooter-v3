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
    [SerializeField]
    [Range(0.0f, 2.0f)]
    float coolDown = 1f;
    float buffer = 0f;

    // Use this for initialization
    void Awake () {
        if (!body) body = GetComponent<Rigidbody>();
    }

    void Start () {
        buffer = coolDown;
		}

    Vector3 move;
    // Update is called once per frame
    void Update () {
        if (Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f)
        {
            move = new Vector3(Input.GetAxis("Horizontal") * speed, 0f, Input.GetAxis("Vertical") * speed);
        }
        else
        {
            move = Vector3.zero;
        }
        
        if (buffer >= coolDown) {
            if (Input.GetButtonDown("Fire1")) {
                Instantiate(laserBullet, laserCanon.position, laserCanon.rotation);
                buffer = 0f;
            }
        }
        else {
            buffer += Time.deltaTime;
        }

    }

    private void FixedUpdate()
    {
        body.velocity = move;
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.transform.tag == "Enemy") {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Debug.Log("Game Over !");
        }
    }
}
