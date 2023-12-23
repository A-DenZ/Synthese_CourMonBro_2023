using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public class NetworkUI : MonoBehaviour
{
    // Représente les 3 boutons de notre scène
    [SerializeField] private Button hostButton = default;
    //[SerializeField] private Button serverButton = default;
    [SerializeField] private Button clientButton = default;
    [SerializeField] private GameObject _canvasUIMenu = default;
    [SerializeField] private GameObject _mainGaucheXRModel = default;
    [SerializeField] private GameObject _mainDroiteXRModel = default;

    [SerializeField] private string _joinCode;
    
    private void Start()
    {
        // souscrit à l'évènement sur le click du bouton Host et démarrer la session Host
        hostButton.onClick.AddListener(() =>RelayManager.Instance.CreateRelayGame(12));
        hostButton.onClick.AddListener(() => FermerUI());

        // souscrit à l'évènement sur le click du bouton Host et démarrer la session Host
        //serverButton.onClick.AddListener(() => NetworkManager.Singleton.StartServer());

        // souscrit à l'évènement sur le click du bouton Host et démarrer la session Host
        clientButton.onClick.AddListener(() => RelayManager.Instance.JoinRelayGame(_joinCode));
        clientButton.onClick.AddListener(() => FermerUI());
    }

    public void FermerUI()
    {
        _canvasUIMenu.SetActive(false);
        _mainDroiteXRModel.SetActive(false);
        _mainGaucheXRModel.SetActive(false);
    }
}
