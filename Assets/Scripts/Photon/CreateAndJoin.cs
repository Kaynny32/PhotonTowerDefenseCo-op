using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreateAndJoin : MonoBehaviourPunCallbacks
{
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


    int _maxPlayers;
    bool _isVisible;
    bool _isOpen;


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
        PhotonNetwork.LoadLevel(1);
    }
}
