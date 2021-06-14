using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;

    public int ballScored;
    public GameObject canasta;
    public GameObject obstacle;
    public GameObject ball;
    public GameObject particle;

    //public hoopSpawner hoopSpawner;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ScoreBall()
    {
        ballScored++;
        UIManager.Instance.UpdateBallScored();

        Vector3 position = canasta.transform.position;
        position.y = 0;
        Instantiate(particle, position, Quaternion.identity);
        
        if (ballScored == 2) { canasta.GetComponent<MoveCanasta>().SetLevel(5); }
        else if (ballScored % 4 == 0) { obstacle.GetComponent<Obstacle>().InstantiateObstacle(); }
        else if (ballScored == 6) { ball.GetComponent<ballControl>().SetLevel(10); }
    }

    public void Restart()
    {
        ballScored = 0;
    }

    public void end()
    {
        if(InfoShared.record < ballScored)
        {
            InfoShared.record = ballScored;
        }
        SceneManager.LoadScene("Start");
    }
}
