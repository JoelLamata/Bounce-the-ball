using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;

    public int ballScored;
    public GameObject canasta;

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
        if (ballScored == 1) { canasta.GetComponent<MoveCanasta>().SetLevel(5); }
    }

    public void Restart()
    {
        ballScored = 0;
    }
}
