using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoopManager : MonoBehaviour
{
    public GameObject coopPanel;  // Faites référence au panneau coopératif dans l'éditeur Unity

    private void Start()
    {
        // Assurez-vous que le panneau coopératif est désactivé au démarrage
        if (coopPanel != null)
        {
            coopPanel.SetActive(false);
        }
    }

    public void OnCoopButtonClick()
    {
        // Inversez l'état d'activation du panneau coopératif
        if (coopPanel != null)
        {
            coopPanel.SetActive(!coopPanel.activeSelf);
        }
    }
}
