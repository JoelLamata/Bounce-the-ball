using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCanasta : MonoBehaviour
{
    public string tagFilter;
    public GameObject ball;

    public float runSpeed = 10;
    public int level = 1;
    public Vector3 creationPos;
    private bool right = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (level >= 5) { Move(); }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagFilter))
        {
            SoundManager.Instance.PlayBasketClip();
            GameStateManager.Instance.ScoreBall();
            Respawn();
        }
    }
    
    void Respawn()
    {
        float posX = Random.Range(5.0f, 90.0f);
        float posZ = Random.Range(5.0f, 90.0f);
        Vector3 ballPos = ball.transform.position;
        while(posX >= ballPos.x - 25 && posX <= ballPos.x + 25)
        {
            posX = Random.Range(10.0f, 90.0f);
        }
        while(posZ >= ballPos.z - 25 && posZ <= ballPos.z + 25)
        {
            posZ = Random.Range(10.0f, 90.0f);
        }
        Vector3 position = new Vector3(posX, -15.2f, posZ);
        transform.position = position;
        Vector3 center = new Vector3(Random.Range(45, 55), -15.2f, Random.Range(45, 55));
        transform.LookAt(center);
        creationPos = transform.position;
    }

    void Move()
    {
        Vector3 movement = Vector3.right;
        if (right == false) { movement = Vector3.left; }
        

        transform.Translate(movement * runSpeed * Time.deltaTime);

        
        if((transform.position.x <= (creationPos.x - 10)) || (transform.position.x >= (10 + creationPos.x)) ||
            (transform.position.z <= (creationPos.z - 10)) || (transform.position.z >= (10 + creationPos.z)) ||
            (transform.position.z >= 95) || (transform.position.z <= 5) || 
            (transform.position.x >= 95) || (transform.position.x <= 5))
        {
            right = !right;
        }
    }

    public void SetLevel(int newLevel)
    {
        level = newLevel;
    }

}
