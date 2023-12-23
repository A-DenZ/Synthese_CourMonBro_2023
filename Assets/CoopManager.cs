using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoopManager : MonoBehaviour
{
    public GameObject coopPanel;  // Faites r�f�rence au panneau coop�ratif dans l'�diteur Unity

    private void Start()
    {
        // Assurez-vous que le panneau coop�ratif est d�sactiv� au d�marrage
        if (coopPanel != null)
        {
            coopPanel.SetActive(false);
        }
    }

    public void OnCoopButtonClick()
    {
        // Inversez l'�tat d'activation du panneau coop�ratif
        if (coopPanel != null)
        {
            coopPanel.SetActive(!coopPanel.activeSelf);
        }
    }
}
