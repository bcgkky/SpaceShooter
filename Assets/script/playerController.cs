using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [System.Serializable]
    public class Sinirlayici
    {
        public float xMax, xMin, zMin, zMax;
    }

    public Sinirlayici forsinir;
    Rigidbody rb;

    [SerializeField] float speed;
    [SerializeField] float tilt;
    [SerializeField] float nextFire;
    [SerializeField] float saniyede;

    public GameObject shot;
    public GameObject shotSpawn;

    AudioSource aud;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        aud = GetComponent<AudioSource>();

    }

    void FixedUpdate()
    {
        float yatay = Input.GetAxis("Horizontal");
        float dikey = Input.GetAxis("Vertical");

        Vector3 vek = new Vector3(yatay,0,dikey);

        rb.velocity = vek*speed;

        Vector3 sinir = new Vector3(
            Mathf.Clamp(rb.position.x, forsinir.xMin, forsinir.xMax),
            4,
            Mathf.Clamp(rb.position.z, forsinir.zMin, forsinir.zMax)
            );

        rb.position = sinir;


        rb.rotation = Quaternion.Euler(0,0,rb.velocity.x * tilt);
        
    }
    void Update()
    {

        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + saniyede;
            Instantiate(shot, shotSpawn.transform.position, shotSpawn.transform.rotation); aud.Play();

        }

    }
}
