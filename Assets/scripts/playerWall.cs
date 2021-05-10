using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerWall : MonoBehaviour
{
    public GameObject playerRed;
    public GameObject playerBlue;

    private Vector3 position;
    private Quaternion rotation;
    private Vector3 scale;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cambiarPosicion();
    }

    void cambiarPosicion()
    {
        rotation.Set(0, 0, 0, 0);
        scale.Set(3, 2, 2);
        Vector3 playerRedPos;
        Vector3 playerBluePos;
        playerRedPos = playerRed.transform.position;
        playerBluePos = playerBlue.transform.position;
        if (playerRedPos.x < playerBluePos.x)
        {
            position.x = (playerBluePos.x - playerRedPos.x)/2 + playerRedPos.x;
        }
        else
        {
            position.x = (playerRedPos.x - playerBluePos.x)/2 + playerBluePos.x;
        }

        if (playerRedPos.z < playerBluePos.z)
        {
            position.z = (playerBluePos.z - playerRedPos.z)/2 + playerRedPos.z;
        }
        else
        {
            position.z = (playerRedPos.z - playerBluePos.z)/2 + playerBluePos.z;
        }
        scale.x = Mathf.Sqrt(Mathf.Pow(Mathf.Abs(playerBluePos.x - playerRedPos.x), 2) + Mathf.Pow(Mathf.Abs(playerBluePos.z - playerRedPos.z), 2));
        transform.SetPositionAndRotation(position, rotation);
        transform.localScale = scale;
    }
}
