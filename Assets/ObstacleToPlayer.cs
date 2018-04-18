using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleToPlayer : Obstacles{

    Transform player;
    private void Start()
    {
        player = GameObject.Find("Player").transform;
    }
    // Update is called once per frame
    void Update () {
        if (Vector3.Distance(transform.position, player.position) < 15)
        {
            transform.LookAt(player.position);
            transform.position = Vector3.MoveTowards(transform.position, player.position, 4 * Time.deltaTime);
        }
	}
}
