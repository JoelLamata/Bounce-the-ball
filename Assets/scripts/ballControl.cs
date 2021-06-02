using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballControl : MonoBehaviour
{
    public Vector3 initialVelocity; // Bounce velocity
    private Rigidbody rb;            // Ball RigidBody             
    public float minVelocity = 10f;
    private Vector3 lastFrameVelocity;

    // Start is called before the first frame update - cambiar por OnEnable()
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = initialVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        // updating the vel
        lastFrameVelocity = rb.velocity; 
    }
    private void Bounce(Vector3 collisionNormal)
    {
        var speed = lastFrameVelocity.magnitude;
        var direction = Vector3.Reflect(lastFrameVelocity.normalized, collisionNormal);

        // Debug.Log("Out Direction: " + direction);
        rb.velocity = direction * Mathf.Max(speed, minVelocity);
    }

    private void OnCollisionEnter(Collision other)
    {
        SoundManager.Instance.PlayBounceClip();

        Bounce(other.contacts[0].normal);
        
    }
}
