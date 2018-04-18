using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle2Points : Obstacles {
    int dir = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position += transform.forward * dir * 4 * Time.deltaTime;
	}

    protected override void OnCollisionEnter(Collision collision)
    {
        dir = dir * (-1);
        base.OnCollisionEnter(collision);
    }
}
