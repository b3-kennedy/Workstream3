using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class LevelManager : MonoBehaviour
{
    public int Hearts = 5;
    public GameObject[] LifeBarStateGameObjects;

    public TMP_Text scoreUIText;

    public int score = 0;
    

    public void DamageOnHit()
    {
        Hearts--;
        UpdateHealthBar(5-Hearts);
    }
    public void Update()
    {
        if(Hearts == 0)
        {
            SceneManager.LoadScene("EndScene");
        }
        score += Mathf.RoundToInt(Time.deltaTime*100);

        scoreUIText.text = "Score : "+score;


        
    }
    public void UpdateHealthBar(int index)
    {
        for(int i = 0;i< LifeBarStateGameObjects.Length; i++)
        {
            if (i == index)
            {
                LifeBarStateGameObjects[i].SetActive(true);
            }
            else
            {
                LifeBarStateGameObjects[i].SetActive(false);
            }
        }
    }

 }

