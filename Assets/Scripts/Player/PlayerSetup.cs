using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    [SerializeField]
    ObjectPicker _objectPicker;
    [SerializeField]
    MovmentPlayer _movmentPlayer;
    [SerializeField]
    GameObject _cam;
    [SerializeField]
    Animator _animator;

    public void IsLocalPlayer()
    {
        _objectPicker.enabled = true;
        _movmentPlayer.enabled = true;
        _cam.SetActive(true);
        _animator.enabled = true;
    }
}
