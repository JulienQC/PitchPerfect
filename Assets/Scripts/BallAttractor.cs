using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAttractor : MonoBehaviour {

    public KeyCode key;
    public float forceFactor;

    private GameObject prefab;
    private GameObject player;
    private PlayerMovement mover;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        mover = player.GetComponent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(key))
        {
            Vector3 force = transform.position - player.transform.position;
            mover.Attract(force * forceFactor);
        }
	}

    public void SetKey(KeyCode k)
    {
        key = k;
    }

}
