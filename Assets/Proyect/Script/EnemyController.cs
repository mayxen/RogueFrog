using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float speed = 1f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed,0);

        Debug.Log((Screen.width / 100f) / 2f / Camera.main.aspect);

        if (transform.position.x > (Screen.width / 100f)/2f / Camera.main.aspect)
        {
            transform.position = new Vector3(-transform.position.x +0.12f, transform.position.y, transform.position.z);
        }
        else if(transform.position.x < -(Screen.width / 100f) / 2f / Camera.main.aspect)
        {
            transform.position = new Vector3(-transform.position.x - 0.12f, transform.position.y, transform.position.z);
        }
	}
}
