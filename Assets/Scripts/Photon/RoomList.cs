using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RoomList : MonoBehaviourPunCallbacks
{
    [SerializeField]
    GameObject _perfabRoomBtn;
    [SerializeField]
    Transform _con;

    [SerializeField]
    List<GameObject> _allRooms;

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (GameObject go in _allRooms)
        {
            if (_allRooms != null)
            {
                Destroy(go);
            }            
        }
        _allRooms = new List<GameObject>();
        foreach (RoomInfo room in roomList)
        {
            if (room.IsOpen && room.IsVisible && room.PlayerCount > 0)
            {
                GameObject cloneGo = Instantiate(_perfabRoomBtn, _con);
                cloneGo.GetComponent<Room>().SetRoomName(room.Name);
                _allRooms.Add(cloneGo);
            }
            
        }
    }
}