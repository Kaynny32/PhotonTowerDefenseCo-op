using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTypeBtn : MonoBehaviour
{
    [SerializeField]
    TowerType _type;
    [SerializeField]
    CanvasGroup _canvasGroup;

    //private void Start()
    //{
    //    _canvasGroup = GetComponent<CanvasGroup>();
    //}

    public TowerType GetType()
    {
        return _type;
    }

    public CanvasGroup GetCanvasGroup()
    { 
        return _canvasGroup;
    }
}
