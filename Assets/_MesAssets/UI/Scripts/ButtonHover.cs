using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using System.Collections;
using System.Diagnostics;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Adjust this value to set the hover depth
    [SerializeField] GameObject button;
    public float hoverDepth = 0.1f;
    public float transitionDuration = 0.2f; // Set the duration of the transition

    private RectTransform rectTransform;
    private float originalZPosition;

    private bool isTransitioning;
    private bool exitedBeforeTransitionEnd = false;

    [SerializeField] AudioSource sfx;

    private void Start()
    {
        // Get the RectTransform of the TextMeshPro Button
        rectTransform = GetComponent<RectTransform>();

        // Store the original Z position
        originalZPosition = rectTransform.localPosition.z;
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        exitedBeforeTransitionEnd = false;
        sfx.Play();
        // Move the button forward on the Z-axis with easing when hovered
        if (button.activeSelf)
        {
            LeanTween.moveLocalZ(gameObject, originalZPosition - hoverDepth, transitionDuration)
                .setEase(LeanTweenType.easeInOutCubic)
                .setOnStart(() => { isTransitioning = true; }) // Set isTransitioning to true on animation start
                .setOnComplete(() => { 
                    isTransitioning = false; 
                    if (button.activeSelf) StartCoroutine(OnAnimationComplete()); 
                }); // Start coroutine to reset isTransitioning
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (isTransitioning)
        {
            exitedBeforeTransitionEnd = true;
        }
        else
        {
            // Reset the button position with easing when the mouse exits
            LeanTween.moveLocalZ(gameObject, originalZPosition, transitionDuration)
                .setEase(LeanTweenType.easeInOutCubic);
        }
    }

    private IEnumerator OnAnimationComplete()
    {
        // Wait for a short delay to allow potential OnPointerExit to set the flag
        yield return new WaitForSeconds(0.1f);

        // Check if pointer exited during the animation
        if (button.activeSelf && exitedBeforeTransitionEnd)
        {
            // Reset the button position with easing after a delay
            LeanTween.moveLocalZ(gameObject, originalZPosition, transitionDuration)
                .setEase(LeanTweenType.easeOutCubic);
        }
    }
}