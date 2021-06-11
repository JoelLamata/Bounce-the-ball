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
	if(ballScored == 5){canasta.GetComponent<MoveCanasta>().SetLevel(ballScored);}
	else if(ballScored == 10){ball.GetComponent<ballControl>().SetLevel(ballScored);}
	else if(ballScored == 15){obstacle.GetComponent<Obstacle>().InstantiateObstacle();}

    }

    public void Restart()
    {
        ballScored = 0;
    }
}
