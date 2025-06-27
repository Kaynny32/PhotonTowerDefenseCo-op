using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPicker : MonoBehaviour
{
    [SerializeField]
    float _distance = 5f;
    [SerializeField]
    public float moveSpeed = 10f;

    [SerializeField]
    Camera cam;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
                TryObject();
        }
    }

    void TryObject()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, _distance))
        {            
            GameObject go = hit.transform.gameObject;
            if(go.GetComponent<TowerPoint>() != null && go.GetComponent<TowerPoint>().GetIsState() != true)
            {
                TowerFactory.instance.CreateBase(InputManager.instance.GetTypeTower(), hit.point, go.GetComponent<TowerPoint>());
            }
        }
    }
}
