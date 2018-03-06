using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesController : MonoBehaviour {
    
    public float ray = 10.0f;
    public float projectileSpeed = 10f;
    public float timeInterval = 2;
    public float delay = 1;

    private NoteController[] children;
    private float time;

	// Use this for initialization
	void Start () {

        Transform[] transforms = GetComponentsInChildren<Transform>();
        children = GetComponentsInChildren<NoteController>();

        float angle = 2 * Mathf.PI / children.Length;
        for(int i = 0; i < children.Length; i++)
        {
            transforms[i].position = new Vector3(ray * Mathf.Cos(angle * i), 1,
                                                 ray * Mathf.Sin(angle * i));
        }

        time = 0;
	}

    private void Update()
    {
        if(time == 0)
        {
            int id = Random.Range(0, children.Length - 1);
            children[id].PlayNote();
            StartCoroutine(FireWave(id));
        }
        time += Time.deltaTime;
        if (time > timeInterval)
        {
            time = 0;
        }
    }


    IEnumerator FireWave(int id)
    {
        yield return new WaitForSeconds(delay);
        for (int i = 0; i < id; i++)
        {
            FireProjectile(i);
        }
        for (int i = id + 1; i < children.Length; i++)
        {
            FireProjectile(i);
        }
    }

    private void FireProjectile(int i)
    {
        float angle = 2 * Mathf.PI * i / children.Length;
        children[i].SendProjectile(angle, ray, projectileSpeed);
    }




}
