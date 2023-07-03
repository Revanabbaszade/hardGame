using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Vector2 playerInitialPosition;
    private GameObject[] Enemys;
    private GameObject Player;
    void Awake()
    {
        if (instance == null)
            instance = this;
        Time.timeScale = 1f;
    }
    // Start is called before the first frame update
    void Start()
    {
        Enemys = GameObject.FindGameObjectsWithTag("Enemy");
        Player = GameObject.FindWithTag("Player");

    }
    public  void PlayerReachedGoal()
    {
        Player.transform.position = playerInitialPosition;
        Player.GetComponent<PlayerController>().moveSpeed += 0.3f;

       

        foreach(GameObject g  in Enemys)
        {
            g.GetComponent<Enemy>().moveSpeed += 1f;
        }
    }

    // Update is called once per frame
    public void PlayerDied()
    {
        Time.timeScale = 0f;
        StartCoroutine(RestartGame());
    }
    IEnumerator RestartGame()
    {
        yield return new WaitForSecondsRealtime(2F);

        UnityEngine.SceneManagement.SceneManager.LoadScene
            (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
