using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyMenu : MonoBehaviour
{
    public static ReadyMenu Instance;

    [SerializeField] public GameObject menu;
    
    public void OpenMenu()
    {
        menu.transform.LeanSetLocalPosY(-20f);
        LeanTween.moveLocalY(menu, 0f, 0.8f).setEase(LeanTweenType.easeInCubic);
    }
}
