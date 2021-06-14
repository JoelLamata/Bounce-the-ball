using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Text ballScored;
    public Text timer;
    public float playTime;
    static float initialTime;
    bool finDeLaPartida = false;
    bool horn = false;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        initialTime = Time.time + (playTime * 60);
    }

    // Update is called once per frame
    void Update()
    {
        float tiempoTotal = Mathf.Round(initialTime - Time.time);
        float minutos = Mathf.Floor(tiempoTotal / 60);
        float segundos = tiempoTotal % 60;
        if(finDeLaPartida && segundos == -2)
        {
            GameStateManager.Instance.end();
        }
        if (segundos == 0 && minutos == 0)
        {
            timer.text = "0:00";
            finDeLaPartida = true;
            if (!horn)
            {
                SoundManager.Instance.PlayAirHornSound();
                horn = true;
            }
        }
        else if (finDeLaPartida) timer.text = "0:00";
        else if (segundos <= 9)
        {
            timer.text = minutos.ToString() + ":" + "0" + segundos.ToString();
        }
        else timer.text = minutos.ToString() + ":" + segundos.ToString();
    }

    public void UpdateBallScored()
    {
        ballScored.text = GameStateManager.Instance.ballScored.ToString();
    }
}
