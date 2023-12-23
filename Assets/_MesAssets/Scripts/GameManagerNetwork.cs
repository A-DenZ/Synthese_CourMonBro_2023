using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerNetwork : NetworkBehaviour
{

    public static GameManagerNetwork Instance;

    private int ctrNiveau;
    private float lifepoints = 10f;
    private float vitesse = 1f;


    private void Awake()
    {
        Instance = this;
    }

    public void IncrementLvlDifficulty()
    {
        ctrNiveau++;
        if(ctrNiveau > 5)
        {
            lifepoints += 10;

        }else if(ctrNiveau == 5)
        {
            vitesse = 2f; 

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
           // FIN DU JEUX GAGNANT
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
