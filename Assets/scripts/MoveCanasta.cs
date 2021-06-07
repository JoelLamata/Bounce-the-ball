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
    }

}
