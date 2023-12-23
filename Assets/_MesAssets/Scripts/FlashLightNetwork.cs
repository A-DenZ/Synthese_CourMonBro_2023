using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class FlashLightNetwork : NetworkBehaviour
{
    [SerializeField] private GameObject SpotLight;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void FlashLightClick()
    {
        if(SpotLight != null)
        {
            if(SpotLight.activeSelf == true)
            {
                SpotLight.SetActive(false);
                audioSource.Play();
            }
            else
            {
                SpotLight.SetActive(true);
                audioSource.Play();
            }
        }
    }
}
