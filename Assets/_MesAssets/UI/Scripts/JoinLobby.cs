using System.Collections;
using System.Collections.Generic;
using Unity.Services.Lobbies.Models;
using Unity.Services.Lobbies;
using UnityEngine;
using TMPro;

public class JoinLobby : MonoBehaviour
{
    [SerializeField] private TMP_Text nameTMP;
    [SerializeField] private GameObject noLobbyTMP;
    [SerializeField] private TMP_Text countTMP;
    [SerializeField] private GameObject joinButton;

    private float timer = 0;
    private float refreshTime = 3f;

    private void OnEnable()
    {
        UpdateLobby();
    }

    private void Update()
    {
        // Lance le update à chaque temps de rafraichissement
        if (timer > refreshTime)
        {
            UpdateLobby();
            timer -= refreshTime;
        }
        timer += Time.deltaTime;
    }

    public async void UpdateLobby()
    {
        QueryLobbiesOptions options = new QueryLobbiesOptions();
        options.Count = 1;

        QueryResponse response = await Lobbies.Instance.QueryLobbiesAsync(options);

        if (response.Results.Count > 0) {
            Debug.Log("On a un lobby");
            noLobbyTMP.SetActive(false);
            joinButton.SetActive(true);
            Lobby lobby = response.Results[0];
            nameTMP.text = lobby.Name;
            countTMP.text = "1 / 1";
        } else
        {
            Debug.Log("Pas encore de lobby");
            countTMP.text = "0 / 1";
            noLobbyTMP.SetActive(true);
            joinButton.SetActive(false);
        }
    }
}
