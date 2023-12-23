using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsMenu : MonoBehaviour
{
    public static InstructionsMenu Instance;

    [SerializeField] private GameObject background;
    private float backgroundY = 0f;

    [SerializeField] private GameObject instructions;
    private float instructionsY = 0f;

    [SerializeField] private GameObject closeButton;
    private float closeButtonY = 0.635f;

    private void Awake()
    {
        Instance = this;
    }


    void Start()
    {
        //OpenMenu();
    }

    public void OpenMenu()
    {
        background.transform.LeanSetLocalPosY(-3f);
        instructions.transform.LeanSetLocalPosY(-1f);
        closeButton.transform.LeanSetLocalPosY(closeButtonY + 0.2f);

        KillOpacity(background);
        KillOpacity(closeButton);
        KillOpacity(instructions);

        LeanTween.moveLocalY(background, backgroundY, 0.3f).setEase(LeanTweenType.easeInOutCubic);
        TurnOnOpacity(background, 0f);

        LeanTween.moveLocalY(closeButton, closeButtonY, 0.3f).setEase(LeanTweenType.easeInOutCubic).setDelay(0.25f);
        TurnOnOpacity(closeButton, 0.25f);

        LeanTween.moveLocalY(instructions, instructionsY, 0.3f).setEase(LeanTweenType.easeInOutCubic).setDelay(0.15f);
        TurnOnOpacity(instructions, 0.15f);
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
                LeanTween.alphaCanvas(canvasGroup, 1f, 0.3f).setEase(LeanTweenType.easeInCubic).setDelay(delay);
            }
        }
    }
}
