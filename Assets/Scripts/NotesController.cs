using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesController : MonoBehaviour {

    public GameObject notePrefab;
    public GameObject projectilePrefab;
    public float ray = 10.0f;
    public float projectileSpeed = 10f;
    public List<KeyCode> keys;
    public float timeInterval = 2;

    private float time;

	// Use this for initialization
	void Start () {
    
        float angle = 2 * Mathf.PI / keys.Count;
        Vector3 position;

        for(int i = 0; i < keys.Count; i++)
        {
            position = new Vector3(ray * Mathf.Cos(angle * i), 1,
                                   ray * Mathf.Sin(angle * i));
            BallAttractor attractor = Instantiate(notePrefab, position, Quaternion.identity).GetComponent<BallAttractor>();
            attractor.SetKey(keys[i]);
        }

        time = 0;
	}

    private void Update()
    {
        if(time == 0)
        {
            Fire();
        }
        time += Time.deltaTime;
        if (time > timeInterval)
        {
            time = 0;
        }
    }

    private void Fire()
    {
        int id = Random.Range(0, keys.Count - 1);
        for(int i = 0; i < id; i++)
        {
            SendProjectile(i);
        }
        for (int i = id + 1; i < keys.Count; i++)
        {
            SendProjectile(i);
        }
    }

    private void SendProjectile(int note)
    {
        float angle = 2 * Mathf.PI / keys.Count;
        Vector3 position = new Vector3(ray * Mathf.Cos(angle * note), 1, ray * Mathf.Sin(angle * note));
        Quaternion rotation = Quaternion.Euler(90, 0, Mathf.Rad2Deg * angle * note - 90);
        //Vector3 target = -position + new Vector3(0, 1 + position.y, 0);
        Vector3 target = new Vector3(0, 1, 0);
        ProjectileController proj = ProjectileController.Create(projectilePrefab, position, rotation, projectileSpeed, target);
    }


}
