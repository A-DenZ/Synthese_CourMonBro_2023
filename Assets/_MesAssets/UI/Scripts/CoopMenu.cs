using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoopMenu : MonoBehaviour
{
    public static CoopMenu Instance;

    [SerializeField] private GameObject backButton;
    private float backButtonY = 0.85f;

    [SerializeField] private GameObject newButton;
    private float newButtonY = 0.25f;

    [SerializeField] private GameObject joinButton;
    private float joinButtonY = -0.25f;

    [SerializeField] private GameObject newLobbyPanel;

    [SerializeField] private GameObject joinLobbyPanel;

    [SerializeField] private TMP_InputField lobbyNameInput;

    void Start()
    {
        Instance = this;
        OpenMenu();
    }

    public void OpenMenu()
    {
        newButton.transform.LeanSetLocalPosY(-4f);
        joinButton.transform.LeanSetLocalPosY(-4f);
        backButton.transform.LeanSetLocalPosY(-4f);

        KillOpacity(newButton);
        KillOpacity(backButton);
        KillOpacity(joinButton);

        LeanTween.moveLocalY(backButton, backButtonY, 0.8f).setEase(LeanTweenType.easeInOutCubic);
        TurnOnOpacity(backButton, 0f);

        LeanTween.moveLocalY(newButton, newButtonY, 0.8f).setEase(LeanTweenType.easeInOutCubic).setDelay(0.15f);
        TurnOnOpacity(newButton, 0.15f);

        LeanTween.moveLocalY(joinButton, joinButtonY, 0.8f).setEase(LeanTweenType.easeInOutCubic).setDelay(0.25f);
        TurnOnOpacity(joinButton, 0.25f);
    }

    public void CloseMenu()
    {
        LeanTween.moveLocalY(joinButton, -3f, 0.5f).setEase(LeanTweenType.easeInOutCirc);
        TurnOffOpacity(joinButton, 0);

        LeanTween.moveLocalY(newButton, -3f, 0.5f).setEase(LeanTweenType.easeInOutCirc).setDelay(0.10f);
        TurnOffOpacity(newButton, 0.10f);

        LeanTween.moveLocalY(backButton, -3f, 0.5f).setEase(LeanTweenType.easeInOutCirc).setDelay(0.20f);
        TurnOffOpacity(backButton, 0.20f);

        if (joinLobbyPanel.activeSelf) LeanTween.moveLocalY(joinLobbyPanel, -3f, 0.5f).setEase(LeanTweenType.easeInOutCirc).setDelay(0.30f).setOnComplete(() => { joinLobbyPanel.SetActive(false); });
        else if (newLobbyPanel.activeSelf) LeanTween.moveLocalY(newLobbyPanel, -3f, 0.5f).setEase(LeanTweenType.easeInOutCirc).setDelay(0.30f).setOnComplete(() => { newLobbyPanel.SetActive(false); });
    }

    private void KillOpacity(GameObject element)
    {
        if (element != null)
        {
            CanvasGroup canvasGroup = element.GetComponent<CanvasGroup>();
            if (canvasGroup != null)
            {
                canvasGroup.alpha = 0f;
            }
        }
    }

    private void TurnOnOpacity(GameObject element, float delay)
    {
        if (element != null)
        {
            CanvasGroup canvasGroup = element.GetComponent<CanvasGroup>();
            if (canvasGroup != null)
            {
                LeanTween.alphaCanvas(canvasGroup, 1f, 0.8f).setEase(LeanTweenType.easeInCubic).setDelay(delay);
            }
        }
    }

    private void TurnOffOpacity(GameObject element, float delay)
    {
        if (element != null)
        {
            CanvasGroup canvasGroup = element.GetComponent<CanvasGroup>();
            if (canvasGroup != null)
            {
                LeanTween.alphaCanvas(canvasGroup, 0f, 0.5f).setEase(LeanTweenType.easeInCubic).setDelay(delay);
            }
        }
    }

    private void SlideOutMenu(GameObject menu)
    {
        LeanTween.moveY(menu, 10f, 0.6f).setEase(LeanTweenType.easeInCubic).setOnComplete(() =>
        {
            menu.transform.LeanSetPosY(-4f);
            menu.SetActive(false);
        });
    }

    public void SlideNewLobby()
    {
        if (joinLobbyPanel.activeSelf)
        {
            SlideOutMenu(joinLobbyPanel);
        }
        if (!newLobbyPanel.activeSelf) SlideMenu(newLobbyPanel);
    }
    public void SlideJoinLobby()
    {
        if (newLobbyPanel.activeSelf)
        {
            SlideOutMenu(newLobbyPanel);
        }
        if (!joinLobbyPanel.activeSelf) SlideMenu(joinLobbyPanel);
    }

    private void SlideMenu(GameObject menu)
    {
        menu.SetActive(true);
        menu.transform.LeanSetLocalPosY(-4f);
        LeanTween.moveLocalY(menu, 0f, 0.6f).setEase(LeanTweenType.easeInCubic);
    }

    public void CreateLobby()
    {
        LobbyManager.LobbyData lobbyData = new LobbyManager.LobbyData
        {
            maxPlayer = 2,
            lobbyName = lobbyNameInput.text
        };

        LobbyManager.Instance.CreateLobby(lobbyData);
    }
}
