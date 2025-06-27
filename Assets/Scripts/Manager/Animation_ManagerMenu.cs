using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_ManagerMenu : MonoBehaviour
{
    [SerializeField]
    Ease easeShow;
    [SerializeField]
    Ease easeHide;

    [Header("CanvasGroup")]
    [SerializeField]
    CanvasGroup _startPanel;
    [SerializeField]
    CanvasGroup _menuPanel;
    [SerializeField]
    CanvasGroup _loadPanel;


    [Header("Menu UI Elements")]
    [SerializeField]
    RectTransform _conBtn;
    [SerializeField]
    RectTransform _popapSettings;
    [SerializeField]
    RectTransform _popapRoom;
    [SerializeField]
    RectTransform _popapListRoom;


    private void Start()
    {
    }


    public void ShowAndHideListRoomPopap(bool isActive = true)
    {
        if (isActive)
        {
            ShowAndHideCon(_popapListRoom, -20);
        }
        else
        {
            ShowAndHideCon(_popapListRoom, 800, false);
        }
    }

    public void ShowAndHideStartPanel(bool isActive = true)
    {
        _startPanel.DOKill();
        if (isActive)
        {
            _startPanel.DOFade(1, 0.5f).SetEase(easeShow);
            _startPanel.interactable = isActive;
            _startPanel.blocksRaycasts = isActive;
        }
        else
        {
            _startPanel.DOFade(0, 0.5f).SetEase(easeHide);
            _startPanel.interactable = isActive;
            _startPanel.blocksRaycasts = isActive;

            Loom.QueueOnMainThread(() =>
            {
                ShowAndHideMenuPanel(true);
            }, 0.5f);
        }
    }

    public void ShowAndHideLoadPanel(bool isActive = true)
    {
        _loadPanel.DOKill();
        if (isActive)
        {
            _loadPanel.DOFade(1, 0.5f).SetEase(easeShow);
            _loadPanel.interactable = isActive;
            _loadPanel.blocksRaycasts = isActive;
        }
        else
        {
            _loadPanel.DOFade(0, 0.5f).SetEase(easeHide);
            _loadPanel.interactable = isActive;
            _loadPanel.blocksRaycasts = isActive;
        }
    }

    public void ShowAndHideMenuPanel(bool isActive = true)
    {
        _menuPanel.DOKill();

        if (isActive)
        {
            _menuPanel.DOFade(1, 0.5f).SetEase(easeShow);
            _menuPanel.interactable = isActive;
            _menuPanel.blocksRaycasts = isActive;
            ShowAndHideCon(_conBtn, 20, true);
        }
        else
        {
            _menuPanel.DOFade(0, 0.5f).SetEase(easeHide);
            _menuPanel.interactable = isActive;
            _menuPanel.blocksRaycasts = isActive;
            ShowAndHideCon(_conBtn, -585, false);
        }
    }

    public void ShoAndHideSettings(bool isActve = true)
    {
        if (isActve)
        {
            ShowAndHideCon(_popapSettings, -20, true);
        }
        else
        {
            ShowAndHideCon(_popapSettings, 800, false);
        }
    }

    public void ShowAndHideRoomPopap(bool isActve = true)
    {
        if (isActve)
        {
            ShowAndHideCon(_popapRoom, -20, true);
        }
        else
        {
            ShowAndHideCon(_popapRoom, 800, false);
        }
    }

    void ShowAndHideCon(RectTransform rectTransform, float posX, bool isActve = true)
    {
        rectTransform.DOKill();
        if (isActve)
        {
            rectTransform.GetComponent<CanvasGroup>().DOFade(1f, 0.5f).SetEase(easeShow);
            rectTransform.DOAnchorPosX(posX, 0.5f).SetEase(easeShow);
            rectTransform.GetComponent<CanvasGroup>().interactable = isActve;
            rectTransform.GetComponent<CanvasGroup>().blocksRaycasts = isActve;
        }
        else
        {
            rectTransform.GetComponent<CanvasGroup>().interactable = isActve;
            rectTransform.GetComponent<CanvasGroup>().blocksRaycasts = isActve;
            rectTransform.DOAnchorPosX(posX, 0.5f).SetEase(easeShow);
            rectTransform.GetComponent<CanvasGroup>().DOFade(0f, 0.5f).SetEase(easeShow);
        }
    }
}
