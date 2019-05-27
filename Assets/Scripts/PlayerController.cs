using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

    public float speed = 2.0f;
    public float tilt = 0.0f;
    public Boundary bounds;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate = 0.5f;
    private float nextFire = 0.0f;

    private Rigidbody rigidBody;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal * speed, 0.0f, moveVertical * speed);
        rigidBody.velocity = movement;

        rigidBody.position = new Vector3
        (
            Mathf.Clamp(rigidBody.position.x, bounds.xMin, bounds.xMax),
            0.0f,
            Mathf.Clamp(rigidBody.position.z, bounds.zMin, bounds.zMax)
        );

        rigidBody.rotation = Quaternion.Euler(0.0f, 0.0f, rigidBody.velocity.x * -tilt);
    }

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            GetComponent<AudioSource>().Play();
        }
    }
}
