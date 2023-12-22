using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    public int Hearts = 5;
    public GameObject[] LifeBarStateGameObjects;

    

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

