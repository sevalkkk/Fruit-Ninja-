using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private FruitSpawner fs;
    public static GameManager instance;
    public GameObject gameOverPanel;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        fs = GameObject.FindObjectOfType<FruitSpawner>();
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public IEnumerator WaitForGameOverText(GameObject exp)
    {
        yield return new WaitForSeconds(1f);
        Destroy(exp);
        GameOver();


    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        fs.StopSpawning();
    }
}
