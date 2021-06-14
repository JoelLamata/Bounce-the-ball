using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

//Inhering from IPointerClickHandler -> to receive OnPointerClick callbacks
public class StartButton : MonoBehaviour
{
    public GameObject playerRed;
    public GameObject playerBlue;
    bool redInPlace;
    bool blueInPlace;
    bool startTimer = false;
    public float onTopTime;
    float timer = 0;
    void Update()
    {
        if(redInPlace && blueInPlace)
        {
            timer++;
            if (timer >= onTopTime)
            {
                SceneManager.LoadScene("Sample Scene");
                InfoShared.initTime = Time.unscaledTime;
            }
        }
        else
        {
            timer = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player1")
        {
            redInPlace = true;
        }
        if (other.tag == "Player2")
        {
            blueInPlace = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player1")
        {
            redInPlace = false;
        }
        if (other.tag == "Player2")
        {
            blueInPlace = false;
        }
    }
}
