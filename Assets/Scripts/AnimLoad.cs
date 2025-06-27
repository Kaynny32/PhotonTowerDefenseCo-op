using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimLoad : MonoBehaviour
{
    [SerializeField]
    Ease _easePanels;
    [SerializeField]
    RectTransform _imageLoad;

    public void LoadAnim(bool isActive)
    {
        _imageLoad.transform.DOKill();

        if (isActive)
        {
            _imageLoad.GetComponent<Image>().DOFade(1, 0.5f).SetEase(_easePanels);
            _imageLoad.transform.DORotate(new Vector3(0, 0, -360), 1f, RotateMode.FastBeyond360).SetRelative(true).SetEase(Ease.Linear).SetLoops(-1);
        }

        else
        {
            _imageLoad.GetComponent<Image>().DOFade(0, 0.5f).SetEase(_easePanels);
            _imageLoad.transform.DOPause();
        }

    }
}
