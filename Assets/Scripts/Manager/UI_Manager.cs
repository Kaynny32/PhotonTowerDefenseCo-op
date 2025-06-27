using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    List<TowerTypeBtn> _towerTypeBtns = new List<TowerTypeBtn>();

    


    private void Start()
    {
        ResetUITowerType();
    }

    public void ResetUITowerType()
    {
        foreach (TowerTypeBtn towerTypeBtn in _towerTypeBtns)
        {
            towerTypeBtn.GetCanvasGroup().alpha = 0.25f;
        }
    }

    public void ClickInput(TowerType towerType)
    {
        foreach (TowerTypeBtn towerTypeBtn in _towerTypeBtns)
        {
            if (towerType == towerTypeBtn.GetType())            
                towerTypeBtn.GetCanvasGroup().alpha = 1f;
            else
                towerTypeBtn.GetCanvasGroup().alpha = 0.25f;

        }
    }
}
