using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [Header("Scripts Managers")]
    [SerializeField]
    UI_Manager ui_Manager;


    [SerializeField]
    TowerType _activeType;


    private void Start()
    {
        Invoke("DefaultActiveType",0.5f);   
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ui_Manager.ClickInput(TowerType.Fire);
            _activeType = TowerType.Fire;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ui_Manager.ClickInput(TowerType.Ice);
            _activeType = TowerType.Ice;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ui_Manager.ClickInput(TowerType.Bullet);
            _activeType = TowerType.Bullet;
        }
    }

    public TowerType GetTypeTower()
    {
        return _activeType;
    }

    public void DefaultActiveType()
    {
        ui_Manager.ClickInput(TowerType.Fire);
        _activeType = TowerType.Fire;
    }
}
