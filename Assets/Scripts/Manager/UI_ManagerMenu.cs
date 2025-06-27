using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ManagerMenu : MonoBehaviour
{
    [SerializeField]
    AnimLoad animLoad;
    [SerializeField]
    Animation_ManagerMenu animManagerMenu;

    // Start is called before the first frame update
    void Start()
    {
        animManagerMenu.ShowAndHideLoadPanel(true);
        animLoad.LoadAnim(true);
    }

    public void StartMenu()
    {
        animManagerMenu.ShowAndHideLoadPanel(false);
        animManagerMenu.ShowAndHideStartPanel(true);
        animLoad.LoadAnim(false);
    }
}
