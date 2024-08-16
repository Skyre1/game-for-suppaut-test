using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnimationUI : MonoBehaviour
{
  
    [SerializeField] private float timeAnimation;

    [SerializeField] private bool setLocalScaleToZero;
    [SerializeField] private bool setEaseOutBack;
    [SerializeField] private bool setEaseOutBounce;

    private Vector3 originalPosition;
    private Vector3 originalScale;

    private bool descriptiveTextShowing;

    private void Awake()
    {
        originalScale = transform.localScale;
        if (setLocalScaleToZero)
        {
            transform.localScale = Vector3.zero;
        }
        originalPosition = transform.position;
        
    }

    
    private void Start()
    {
        OnAwakeScaleButton();
        originalPosition = transform.localPosition;
    }


    private void OnDisable()
    {
        transform.localScale = originalScale;
    }

    public void OnClickAnimation()
    {
        LeanTween.cancel(gameObject);
        Vector3 newScale = originalScale + new Vector3(0.2f, 0.2f);
        LeanTween.scale(gameObject, newScale, 0.5f).setEaseOutElastic();
    }


    public void OnAwakeScaleButton()
    {
        if (setEaseOutBack)
        {
            LeanTween.scale(gameObject, originalScale, timeAnimation).setEaseOutBack();
            return;
        }

        if (setEaseOutBounce)
        {
            LeanTween.scale(gameObject, originalScale, timeAnimation).setEaseOutBounce();
            return;
        }
    }


    public void RescaleAnimation()
    {
        transform.localScale = Vector3.zero;
        LeanTween.scale(gameObject, new Vector3(1, 1, 1), timeAnimation).setEaseOutBack();
    }

    public void MoveOffScreenRight()
    {
        Vector3 offScreenPos = new Vector3(Screen.width, 0, 0);
        LeanTween.move(gameObject, offScreenPos, 15f);
    }

    public void MoveIntoScreen()
    {
        LeanTween.move(gameObject, new Vector2(0, 0), 0.5f);
    }

    public void MoveOffScreenLeft()
    {
        Vector3 offScreenPos = new Vector3(-Screen.width, 0, 0);
        LeanTween.move(gameObject, offScreenPos, 15f);
    }

    public void DescriptiveTextAnimation()
    {
        if (descriptiveTextShowing)
            return;

        gameObject.SetActive(true);
        descriptiveTextShowing = true;
        LeanTween.moveLocalX(gameObject, transform.localPosition.x + 50f, 0.5f).setLoopPingPong();
        LeanTween.moveLocalY(gameObject, transform.localPosition.y + 150f, 0.8f).setOnComplete(ResetPosition);
    }

    public void OnHoverScale()
    {
        Vector3 newScale = originalScale + new Vector3(0.1f, 0.1f);

        LeanTween.scale(gameObject, newScale, 0.3f).setEaseInBack();
    }

    private void ResetPosition()
    {
        gameObject.SetActive(false);
        descriptiveTextShowing = false;
        transform.localPosition = originalPosition;
    }

    public void ScaleToZero() => transform.localScale = Vector3.zero;

    public void ScaleToOriginal()
    {
        LeanTween.scale(gameObject, originalScale, 0.3f).setEaseOutBack();
    }

    public void ScaleToNormal()
    {
        LeanTween.scale(gameObject, originalScale, timeAnimation).setEaseOutBack().setDelay(0.6f);
    }


}