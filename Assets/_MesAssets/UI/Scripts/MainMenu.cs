using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    public static MainMenu Instance;

    [SerializeField] private GameObject logo;
    private float logoY = 0.25f;

    [SerializeField] private GameObject soloButton;
    private float soloButtonY = -0.608f;

    [SerializeField] private GameObject coopButton;
    private float coopButtonY = -0.608f;

    [SerializeField] private GameObject instructionsButton;
    private float instructionsButtonY = -0.608f;

    void Start()
    {
        Instance = this;
        OpenMenu();
    }

    public void OpenMenu()
    {
        logo.transform.LeanSetLocalPosY(-4f);
        soloButton.transform.LeanSetLocalPosY(-3f);
        coopButton.transform.LeanSetLocalPosY(-3f);
        instructionsButton.transform.LeanSetLocalPosY(-3f);

        KillOpacity(logo);
        KillOpacity(coopButton);
        KillOpacity(soloButton);

        LeanTween.moveLocalY(logo, logoY, 0.8f).setEase(LeanTweenType.easeInOutCubic);
        TurnOnOpacity(logo, 0f);

        LeanTween.moveLocalY(soloButton, soloButtonY, 0.8f).setEase(LeanTweenType.easeInOutCubic).setDelay(0.25f);
        TurnOnOpacity(soloButton, 0.15f);

        LeanTween.moveLocalY(coopButton, coopButtonY, 0.8f).setEase(LeanTweenType.easeInOutCubic).setDelay(0.15f);
        TurnOnOpacity(coopButton, 0.25f);

        LeanTween.moveLocalY(instructionsButton, instructionsButtonY, 0.3f).setEase(LeanTweenType.easeInOutCubic).setDelay(0.15f);
        TurnOnOpacity(instructionsButton, 0.25f);
    }

    public void CloseMenu()
    {
        LeanTween.moveLocalY(coopButton, -3f, 0.5f).setEase(LeanTweenType.easeInOutCirc);
        TurnOffOpacity(coopButton, 0);

        LeanTween.moveLocalY(soloButton, -3f, 0.5f).setEase(LeanTweenType.easeInOutCirc).setDelay(0.15f);
        TurnOffOpacity(soloButton, 15);

        LeanTween.moveLocalY(instructionsButton, -3f, 0.5f).setEase(LeanTweenType.easeInOutCirc).setDelay(0.30f);
        TurnOffOpacity(instructionsButton, 30);

        LeanTween.moveLocalY(logo, -3f, 0.5f).setEase(LeanTweenType.easeInOutCirc).setDelay(0.40f);
        TurnOffOpacity(logo, 40);
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
}
