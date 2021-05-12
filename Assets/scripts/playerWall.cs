using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerWall : MonoBehaviour
{
    // Players
    public GameObject playerRed;
    public GameObject playerBlue;
    private Vector3 playerRedPos;
    private Vector3 playerBluePos;

    // definim la posició, rotació i escala
    private Vector3 position;
    private Quaternion rotation;
    private Vector3 scale;   

    public float distanceControl;  // Distància mínima per crear la malla

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Calculem la distància entre els dos jugadors
        playerRedPos = playerRed.transform.position;
        playerBluePos = playerBlue.transform.position;

        scale.x = Mathf.Sqrt(Mathf.Pow(Mathf.Abs(playerBluePos.x - playerRedPos.x), 2) + Mathf.Pow(Mathf.Abs(playerBluePos.z - playerRedPos.z), 2));

        // Si la distància és menor que distanceControl, creem la malla
        if (scale.x < distanceControl)
        {
            cambiarPosicion();
        }
        else
        {
            scale.Set(0, 0, 0);
            transform.localScale = scale;
        }
    }

    void cambiarPosicion()
    {
        // Definim la escala
        scale.Set(scale.x, 2, 2);

        // Calculem la posició de la malla
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

        // Calculem la rotació de la malla
        rotation = Quaternion.LookRotation(playerRedPos - playerBluePos, Vector3.up); // relative position, dir 

        // Rectifiquem 90º la rotació de la malla en l'eix y 
        Vector3 v = rotation.eulerAngles; 
        rotation = Quaternion.Euler(v.x, v.y - 90, v.z);


        transform.SetPositionAndRotation(position, rotation);
        transform.localScale = scale;

        
    }
}
