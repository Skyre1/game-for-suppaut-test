using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBackground : MonoBehaviour
{
    private int animationVelocity;

    private int rotationVelocity;

    private int delay;

    private Vector3 originalPosition;

    private int rotationDirection;

    [SerializeField]
    private bool addRotationToAnimation;

    [SerializeField]
    private bool addDelayToAnimation;

    [SerializeField]
    private bool addMovingAnimation;

    [SerializeField]
    private bool addScalingAnimation;

    private Vector3 originalScale;


    private void Awake()
    {
        originalPosition = transform.position;
        originalScale = transform.localScale;
        Animation();


        SetRandomValues();

    }
    private void Update()
    {
        RotateAnimation();
        
    }
    public void Animation()
    {

        if (addMovingAnimation)
        {
            LeanTween.moveLocalX(gameObject, 10f, animationVelocity).setOnComplete(ResetPosition).setDelay(delay);
        }

        if (addScalingAnimation)
        {
            float randomScale = Random.Range(0.1f, 0.3f);

            Vector3 newScale = originalScale + new Vector3(randomScale, randomScale);

            LeanTween.scale(gameObject, newScale, 1f).setEaseInBack().setDelay(delay).setOnComplete(ScaleToNormal);
           
        }

        
    }

    private void ScaleToNormal()
    {
        SetRandomValues();
        LeanTween.scale(gameObject, originalScale, 1f).setEaseOutBack().setDelay(delay).setOnComplete(Animation);
    }

    private void ResetPosition()
    {
        transform.position = originalPosition;
        SetRandomValues();
        Animation();
    }


    private void SetRandomValues()
    {
        int[] directions = { -1, 1 };

        int randomIndex = Random.Range(0, directions.Length);

        animationVelocity = Random.Range(5, 30);
        rotationVelocity = Random.Range(5, 30);
        rotationDirection = directions[randomIndex];
        delay = addDelayToAnimation ? Random.Range(1, 5) : 0;
    }

    private void RotateAnimation()
    {
        if (addRotationToAnimation)
        {
            transform.Rotate(Vector3.forward * rotationDirection, Time.deltaTime * rotationVelocity);
        }
    }
}
