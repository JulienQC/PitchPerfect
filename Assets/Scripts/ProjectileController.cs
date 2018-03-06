using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {
    
    public float speed;
    public Vector3 target;
    public Vector3 direction;

	public static ProjectileController Create(Object prefab, Color color, Vector3 pos, Quaternion rot, float s, Vector3 t)
    {
        GameObject obj = Instantiate(prefab, pos, rot) as GameObject;
        ProjectileController proj = obj.GetComponent<ProjectileController>();
        Material m = obj.GetComponent<Renderer>().material;
        m.color = color;
        proj.speed = s;
        proj.target = t;
        proj.direction = (t - obj.transform.position).normalized;
        return proj;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
        transform.position += speed * Time.deltaTime * direction.normalized;
        if(Vector3.Dot(direction, target - transform.position) <= 0)
        {
            Destroy(gameObject);
        }
	}
}
