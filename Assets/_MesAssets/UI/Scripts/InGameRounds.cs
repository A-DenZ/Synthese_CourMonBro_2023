using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InGameRounds : MonoBehaviour
{
    public static InGameRounds Instance;
    [SerializeField] private TMP_Text roundsTMP;
    private int round = 1;

    private void Awake()
    {
        Instance = this;
    }

    public void Increment()
    {
        round++;
        roundsTMP.text = round.ToString();
    }
}
