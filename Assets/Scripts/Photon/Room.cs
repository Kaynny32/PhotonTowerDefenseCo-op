using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI _nameRoom;
    string _roomName;

    public void JoindRoom()
    {
        CreateAndJoin.instance.JoindRoomList(_roomName);
    }

    public void SetRoomName(string name)
    {
        _nameRoom.text = name; 
        _roomName = name;
    }
}
