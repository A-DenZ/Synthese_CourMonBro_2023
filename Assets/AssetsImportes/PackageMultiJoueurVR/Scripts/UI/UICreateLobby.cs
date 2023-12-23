using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UICreateLobby : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputNomLobby = default;
    [SerializeField] private int _nbJoueurs = 2;
    [SerializeField] private Button _btnCreateLobby = default;

    private void Start()
    {
        _btnCreateLobby.onClick.AddListener(CreateLobbyFromUI);
    }

    private void Update()
    {
        // Rends le bouton actif seulement s'il y a du texte dans le input field
        _btnCreateLobby.gameObject.SetActive(_inputNomLobby.text.Trim() != "");
    }

    public void CreateLobbyFromUI()
    {
        LobbyManager.LobbyData lobbyData = new LobbyManager.LobbyData();
        lobbyData.maxPlayer = _nbJoueurs;
        lobbyData.lobbyName = _inputNomLobby.text;

        LobbyManager.Instance.CreateLobby(lobbyData);
    }
}

