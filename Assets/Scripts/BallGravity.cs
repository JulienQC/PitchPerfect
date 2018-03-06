using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGravity : MonoBehaviour {

    public float forceFactor;

    private GameObject player;
    private PlayerMovement mover;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        mover = player.GetComponent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 force = transform.position - player.transform.position;
        float distance = Vector3.Magnitude(force);

		if(distance != 0)
        {
            mover.ApplyForce(force * forceFactor);
        }
	}
}
