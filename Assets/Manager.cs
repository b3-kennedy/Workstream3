using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Manager : MonoBehaviour
{
    public Button StartBtn;
    void Start()
    {
        
    }
   public void OnEnable() {
        StartBtn.onClick.AddListener(StartGame);
    }
    public void OnDisable()
    {
        StartBtn.onClick.RemoveListener(StartGame);
    }
    public void StartGame()
    {
         SceneManager.LoadScene("s");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
