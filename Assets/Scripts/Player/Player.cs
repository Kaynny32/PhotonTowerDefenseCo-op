using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using Photon.Pun;

public class Player : MonoBehaviour
{
    [SerializeField]
    FirstPersonController _firstPersonController;
    [SerializeField]
    ObjectPicker _objectPicker;
    [SerializeField]
    Camera _camera;

    public void SetScripts(FirstPersonController firstPersonController, ObjectPicker ObjectPicker, Camera camera)
    {
        if (GetComponent<PhotonView>().IsMine == true)
        {
            _firstPersonController = firstPersonController;
            _camera = camera;
            _objectPicker = ObjectPicker;
        }        
    }
}
