using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    private int ctrNiveau;
    private float lifepoints = 10f;
    private float vitesse = 1f;


    private void Awake()
    {
        Instance = this;
    }

    public void IncrementLvlDifficulty()
    {
        InGameRounds.Instance.Increment();
        ctrNiveau++;
        if(ctrNiveau < 5)
        {
            lifepoints += 10;

        }else if(ctrNiveau == 5)
        {
            vitesse = 2.5f; 

        }else if (ctrNiveau > 5 && ctrNiveau> 9)
        {
            lifepoints += 5;
        }
        
        
        if(ctrNiveau == 10)
        {
            lifepoints = 30;
            vitesse = 5f;
        }

        if (ctrNiveau == 11) 
        {
            SceneManager.LoadScene(0);
        }

        
    }

    public float getLifePoints()
    {
        return lifepoints;
    }

    public float getVitesse()
    { 
        return vitesse; 
    }


    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
