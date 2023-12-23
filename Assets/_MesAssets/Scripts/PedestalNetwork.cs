using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;

public class PedestalNetwork : NetworkBehaviour 
{
    private bool gunGrabbed = false;
    private bool flashlightGrabbed = false;
    private bool gameIsStarted = false;
    [SerializeField] List<GameObject> panels;

    private NetworkAnimateHandOnInput _handsModel;

  
    public void GrabFlashlight()
    {
        flashlightGrabbed = true;

        if (gunGrabbed) HidePedestal();
    }

   
    public void GrabGun()
    {
        gunGrabbed = true;

        if (flashlightGrabbed) HidePedestal();
    }

    public void HidePedestal()
    {
        // float[] delays = { 0f, 0.2f, 0.375f, 0.425f, 0.55f, 0.65f, 0.725f };
        float[] delays = { 0f, 0.1f, 0.2f, 0.3f, 0.40f, 0.5f, 0.6f };
        for (int i = 0; i < panels.Count; i++)
        {
            LeanTween.scaleX(panels[i], 0f, 0.6f).setEase(LeanTweenType.easeOutCubic).setDelay(0.05f + delays[i]);
            LeanTween.alpha(panels[i], 0f, 0.6f).setEase(LeanTweenType.easeInCubic).setDelay(0.05f + delays[i]);
            StartCoroutine(PlayUnmountSound(delays[i]));  
        }

        StartCoroutine(OnAnimationComplete());

        if (IsServer && !gameIsStarted)
        {
            SystemSoundsNetwork.Instance.playSpawnSound();
            gameIsStarted = true;

        }
    }
    private IEnumerator PlayUnmountSound(float delay)
    {
        yield return new WaitForSeconds(delay);           
        foreach (GameObject panel in panels)
        {
            AudioSource audio = panel.GetOrAddComponent<AudioSource>();
            audio.Play();
        }
    }

    private IEnumerator OnAnimationComplete()
    {
        yield return new WaitForSeconds(3f);
        foreach (GameObject panel in panels)
        {
            panel.SetActive(false);
        }

        if (IsServer)
        {
            EnemyManagerNetwork.Instance.EnemyStartMoving();
        }


    }

}
