using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI bestScore;
    public TextMeshProUGUI currentPlayerName;
    // Start is called before the first frame update
    void Start()
    {
        ShowScore();


    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G)) 
        {
            GameManager.Instance.SaveScore();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            GameManager.Instance.LoadScore();
            ShowScore();
        }

    }

    public void SetBestScore(string player, string score)
    {
        bestScore.text = "Best Score\n" + player + " " + score;
    }
    public void ShowScore()
    {
        if (GameManager.Instance != null)
        {
            SetBestScore(GameManager.Instance.bestPlayer, GameManager.Instance.bestScore.ToString());
        }
    }
    public void UpdateName()
    {
        GameManager.Instance.playerName = currentPlayerName.text;
    }

    public void LoadScene1()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        GameManager.Instance.SaveScore();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
