using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Vector3 position; 
    public GameObject myPrefab;

    public GameObject ball;
    public GameObject canasta;

    // Start is called before the first frame update
    void Start()    
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // Instantiate the obstacle
    public void InstantiateObstacle()
    {
        // Instantiate at given position
        float posX = Random.Range(5.0f, 90.0f);
        float posZ = Random.Range(5.0f, 90.0f);
        Vector3 ballPos = ball.transform.position;
        Vector3 canastaPos = canasta.transform.position;
        while ((posX >= ballPos.x - 25 && posX <= ballPos.x + 25) || (posX >= ballPos.x - 25 && posX <= ballPos.x + 25))
        {
            posX = Random.Range(10.0f, 90.0f);
        }
        while (posZ >= ballPos.z - 25 && posZ <= ballPos.z + 25 || (posZ >= ballPos.z - 25 && posZ <= ballPos.z + 25))
        {
            posZ = Random.Range(10.0f, 90.0f);
        }
        Vector3 position = new Vector3(posX, 0f, posZ);
        Instantiate(myPrefab, position, Quaternion.identity); 
    }
}
