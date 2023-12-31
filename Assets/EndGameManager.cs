using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class EndGameManager : MonoBehaviour
{
    public Button restartBtn;
    public Button exitBtn;

    public AudioSource endGameMusic;
    public AudioSource clickSound;

    public TMP_Text highScoreTxt;
    public TMP_Text scoreTxt;

    public void Start()
    {
        endGameMusic.Play();
        highScoreTxt.text = "Your High Score is : "+PlayerPrefs.GetInt("HighScore", 0);
        scoreTxt.text = "Score : " + PlayerMovement.score;
    }

    public void OnEnable()
    {
        restartBtn.onClick.AddListener(RetartGame);
        exitBtn.onClick.AddListener(EndGame);
    }
    public void OnDisable()
    {
        restartBtn.onClick.RemoveListener(RetartGame);
        exitBtn.onClick.RemoveListener(EndGame);

    }
    public void EndGame()
    {
        clickSound.Play();
        Application.Quit();
    }
    public void RetartGame()
    {
        clickSound.Play();
        SceneManager.LoadScene("s");
    }
}
