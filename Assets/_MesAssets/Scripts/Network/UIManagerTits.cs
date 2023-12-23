using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerTits : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject instructionsMenu;
    [SerializeField] private GameObject coopMenu;
    [SerializeField] private GameObject readyMenu;

    // Start is called before the first frame update
    public void ToggleInstructionsMenu()
    {
        if (instructionsMenu.activeSelf)
        {
            instructionsMenu.SetActive(false);
        }
        else
        {
            instructionsMenu.SetActive(true);
            InstructionsMenu.Instance.OpenMenu();
        }
    }

    public void CloseInstructionsMenu()
    {
        if (instructionsMenu.activeSelf)
        {
            instructionsMenu.SetActive(false);
        }
    }

    public void CloseMainMenu()
    {
        if (mainMenu.activeSelf)
        {
            if (instructionsMenu.activeSelf)
            {
                CloseInstructionsMenu();
            }
            MainMenu.Instance.CloseMenu();
            StartCoroutine(ExecuteFunction(() => {
                coopMenu.SetActive(true);
                if (CoopMenu.Instance) CoopMenu.Instance.OpenMenu();
            }, 0.7f));
        }
    }

    public void CoopToMainMenu()
    {
        if (coopMenu.activeSelf)
        {
            CoopMenu.Instance.CloseMenu();
            StartCoroutine(ExecuteFunction(() => {
                mainMenu.SetActive(true);
                if (MainMenu.Instance) MainMenu.Instance.OpenMenu();
            }, 0.7f));
        }
    }

    public void CoopToReadyMenu()
    {
        if (coopMenu.activeSelf)
        {
            CoopMenu.Instance.CloseMenu();
            StartCoroutine(ExecuteFunction(() => {
                readyMenu.SetActive(true);
                if (ReadyMenu.Instance) ReadyMenu.Instance.OpenMenu();
            }, 0.7f));
        }
    }

    public IEnumerator ExecuteFunction(Action function, float delay)
    {
        yield return new WaitForSeconds(delay);

        function();
    }
}
