using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCanasta : MonoBehaviour
{
    public string tagFilter;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagFilter))
        {
            Respawn();
        }
    }
    
    void Respawn()
    {
        float posX = Random.Range(5.0f, 95.0f);
        float posZ = Random.Range(5.0f, 95.0f);
        Vector3 position = new Vector3(posX, -15.2f, posZ);
        float rotate = Random.Range(0, 360);
        transform.position = position;
        transform.Rotate(0, rotate, 0);
    }

}
