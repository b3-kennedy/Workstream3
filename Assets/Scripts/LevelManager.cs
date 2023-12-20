using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int Hearts = 5;
   
    public void DamageOnHit()
    {
        Hearts--;
    }

 }

