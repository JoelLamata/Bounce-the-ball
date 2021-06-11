using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Vector3 position; 
    public GameObject myPrefab;

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
        Instantiate(myPrefab, position, Quaternion.identity); 
    }
 

 
}
