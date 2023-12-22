using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Manager : MonoBehaviour
{
    public Button StartBtn;

    public AudioSource clickSound;

   public void OnEnable() {
        StartBtn.onClick.AddListener(StartGame);
    }
    public void OnDisable()
    {
        StartBtn.onClick.RemoveListener(StartGame);
    }
    public void StartGame()
    {
        clickSound.Play();
         SceneManager.LoadScene("s");
    }
    
}
