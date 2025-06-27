using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                towerObject = Instantiate(_prefFireTower, pos, Quaternion.identity);
                towerPoint.SetTowerGo(towerObject);
                break;
            case TowerType.Ice:
                towerObject = Instantiate(_prefIceTower, pos, Quaternion.identity);
                towerPoint.SetTowerGo(towerObject);
                break;
            case TowerType.Bullet:
                towerObject = Instantiate(_prefBulletTower, pos, Quaternion.identity);
                towerPoint.SetTowerGo(towerObject);
                break;
        }
        return towerObject.GetComponent<TowerBase>();
    }
}
