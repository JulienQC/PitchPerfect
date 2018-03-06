using UnityEngine;

public class NoteController : MonoBehaviour{

    public AudioClip noteSound;
    public GameObject projectilePrefab;
    public KeyCode key;
    public Color color;
    public float forceFactor;

    private GameObject prefab;
    private GameObject player;
    private PlayerMovement mover;
    private AudioSource source;
    private Material material;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        mover = player.GetComponent<PlayerMovement>();
        source = GetComponent<AudioSource>();
        material = GetComponent<Renderer>().material;
        material.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            Vector3 force = transform.position - player.transform.position;
            mover.Attract(force * forceFactor);
            source.PlayOneShot(noteSound);
        }
    }

    public void SendProjectile(float angle, float ray, float speed)
    {
        Vector3 position = new Vector3(ray * Mathf.Cos(angle), 1, ray * Mathf.Sin(angle));
        Quaternion rotation = Quaternion.Euler(90, 0, Mathf.Rad2Deg * angle - 90);
        Vector3 target = new Vector3(0, 1, 0);
        ProjectileController proj = ProjectileController.Create(projectilePrefab, color, position, rotation, speed, target);
    }

    public void PlayNote()
    {
        source.PlayOneShot(noteSound);
    }
}
