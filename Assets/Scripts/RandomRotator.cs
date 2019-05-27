using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {

    public float tumble = 0.0f;

    private Rigidbody rigidBody;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();

        rigidBody.angularVelocity = Random.insideUnitSphere * tumble;
    }
}
