using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballControl : MonoBehaviour
{
    public Vector3 initialVelocity; // Bounce velocity
    private Rigidbody rb;            // Ball RigidBody             
    public float minVelocity = 10f;
    private Vector3 lastFrameVelocity;
    public int level;
    private float speed; 
 
    // Start is called before the first frame update - cambiar por OnEnable()
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = initialVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        lastFrameVelocity = rb.velocity;
        speed = lastFrameVelocity.magnitude;

        // updating the vel. If the player is in the lev 10 increase the vel per frame
        if(level >= 10)
        {
            speed = speed + 2; 
        }
	
    }
    private void Bounce(Vector3 collisionNormal)
    {
        
        var direction = Vector3.Reflect(lastFrameVelocity.normalized, collisionNormal);

        // Debug.Log("Out Direction: " + direction);
        rb.velocity = direction * Mathf.Max(speed, minVelocity);
    }

    private void OnCollisionEnter(Collision other)
    {
        SoundManager.Instance.PlayBounceClip();

        Bounce(other.contacts[0].normal);
	
        
    }

    public void SetLevel(int newLevel)
    {
        level = newLevel;
    }

}
