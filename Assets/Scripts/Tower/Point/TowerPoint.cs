using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPoint : MonoBehaviour
{
    [SerializeField]
    bool _isState = false;
    [SerializeField]
    GameObject _towerGo;

    public void SetTowerGo(GameObject go)
    {
        _towerGo = go;
        _isState = true;
    }

    public bool GetIsState()
    { 
        return _isState;
    }

    public GameObject GetTowerGo()
    {
        return _towerGo;
    }
}
