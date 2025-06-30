using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class TowerFactory : MonoBehaviour
{
    public static TowerFactory instance;

    [SerializeField]
    GameObject _prefIceTower;
    [SerializeField]
    GameObject _prefFireTower;
    [SerializeField]
    GameObject _prefBulletTower;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public TowerBase CreateBase(TowerType towerType, Vector3 pos, TowerPoint towerPoint)
    {
        GameObject towerObject = null;
        switch (towerType)
        {
            case TowerType.Fire:
                towerObject = PhotonNetwork.Instantiate(Tower.FireTower.ToString(), pos, Quaternion.identity);
                towerPoint.SetTowerGo(towerObject);
                break;
            case TowerType.Ice:
                towerObject = PhotonNetwork.Instantiate(Tower.IceTower.ToString(), pos, Quaternion.identity);
                towerPoint.SetTowerGo(towerObject);
                break;
            case TowerType.Bullet:
                towerObject = PhotonNetwork.Instantiate(Tower.BulletTower.ToString(), pos, Quaternion.identity);
                towerPoint.SetTowerGo(towerObject);
                break;
        }
        return towerObject.GetComponent<TowerBase>();
    }
}

public enum Tower
{
    FireTower,
    IceTower,
    BulletTower
}
