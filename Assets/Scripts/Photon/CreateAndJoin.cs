using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreateAndJoin : MonoBehaviourPunCallbacks
{
    public static CreateAndJoin instance;

    [SerializeField]
    TMP_InputField _inputCreate;
    [SerializeField]
    TMP_InputField _inputJoin;

    [SerializeField]
    TMP_InputField _inputMaxPlayers;
    [SerializeField]
    Toggle _tgVisible;
    [SerializeField]
    Toggle _tgOpen;

    [SerializeField]
    int _maxPlayers;
    [SerializeField]
    bool _isVisible;
    [SerializeField]
    bool _isOpen;


    private void Awake()
    {
        if (instance == null) 
            instance = this;
    }

    public void CreateRoom()
    {
        _maxPlayers = int.Parse(_inputMaxPlayers.text);
        _isVisible = _tgVisible.isOn;
        _isOpen = _tgOpen.isOn;
        PhotonNetwork.CreateRoom(_inputCreate.text, new RoomOptions() { MaxPlayers = _maxPlayers,  IsVisible = _isVisible, IsOpen = _isOpen}, TypedLobby.Default, null);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(_inputJoin.text);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log(PhotonNetwork.CountOfPlayersInRooms);
        PhotonNetwork.LoadLevel(1);
    }

    public void JoinOrCreateRoom()
    {
        PhotonNetwork.JoinRandomOrCreateRoom(null, 4);
    }

    public void JoindRoomList(string RoomName)
    {
        PhotonNetwork.JoinRoom(RoomName);
    }
}
