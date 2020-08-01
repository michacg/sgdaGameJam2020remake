using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessRunner : MonoBehaviour
{
    [SerializeField] GameObject Character;
    [SerializeField] List<GameObject> Obstacles;
    [SerializeField] float TimeToRun;

    bool isPlaying = false;

    float timer;

    private void Update()
    {
        if(!isPlaying)
        {
            if(Input.GetKeyDown(KeyCode.Space) ||Input.GetKey(KeyCode.Mouse0))
            {
                FindObjectOfType<audioManager>().Play("jumping");
                isPlaying = true;
                StartGame();
            }
        }

        if(timer >= TimeToRun)
        {
            GameOver();
        }

        timer += Time.deltaTime;
    }



    public void GameOver()
    {
        Character.GetComponent<MCRunnerMovement>().Playing(false);
        foreach(GameObject ob in Obstacles)
        {
            ob.GetComponent<RunnerObstacle>().Playing(false);
        }
        GetComponentInParent<Minigame>().GameOver();
    }

    public void StartGame()
    {
        Character.GetComponent<MCRunnerMovement>().Playing(true);
        foreach (GameObject ob in Obstacles)
        {
            ob.GetComponent<RunnerObstacle>().Playing(true);
        }
        
    }

    void IncreaseSpeed()
    {
        foreach (GameObject ob in Obstacles)
        {
            ob.GetComponent<RunnerObstacle>().IncreaseSpeed();
        }
    }
}
