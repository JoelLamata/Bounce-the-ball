using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCanasta : MonoBehaviour
{
    public string tagFilter;
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
	if(level >= 5){Move();}
        
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
        float posX = Random.Range(5.0f, 95.0f);
        float posZ = Random.Range(5.0f, 95.0f);
        Vector3 position = new Vector3(posX, -15.2f, posZ);
        transform.position = position;
        Vector3 center = new Vector3(Random.Range(45, 55), -15.2f, Random.Range(45, 55));
        transform.LookAt(center);
	creationPos = transform.position;
    }

    void Move()
    {
	Vector3 movement = Vector3.right;		
        if (right == false) {movement = Vector3.left;}
	
	transform.Translate(movement * runSpeed * Time.deltaTime);

        // if((transform.position.x >= 10+creationPos.x) || (transform.position.x >= 99) || (transform.position.z >= 99)){right = false;}
	// else if((transform.position.x <= creationPos.x-10) || (transform.position.x <= 1) || (transform.position.z <= 1)){right = true;}
	
	if((transform.position.x <= (creationPos.x - 10)) || (transform.position.x >= (10 + creationPos.x)) ||
            (transform.position.z >= 99) || (transform.position.z <= 1) || 
            (transform.position.x >= 99) || (transform.position.x <= 1))
        {
            right = !right;
        }


        
    }

    public void SetLevel(int newLevel)
    {
        level = newLevel;
    }


}
