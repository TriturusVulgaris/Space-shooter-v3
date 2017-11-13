using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField]
    Transform[] spawner;

    [SerializeField]
    GameObject asteroid;

    [SerializeField]
    float cooldown = 0.5f;
    float buffer = 0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(buffer >= cooldown) {
            int randomspawn = Random.Range(0, 5);
            Instantiate(asteroid, spawner[randomspawn].position, spawner[randomspawn].rotation);
            buffer = 0f;
        }
        else {
            buffer += Time.deltaTime;
        }
		
	}
}
