using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GamesHandler : MonoBehaviour
{
   
    [SerializeField] protected List<AnimationUI> screenElements = new List<AnimationUI>();

    protected TextMeshProUGUI descriptionText;
    protected Button btn;
    protected ButtonEventHandler popUpFinish;
    protected ButtonEventHandler popUpInstructions;

    protected int gameDataCounter;

    private GameObject backButton;

    private Vector3 backButtonOriginalScale;

    protected virtual void Awake()
    {
        gameObject.SetActive(true);
        gameDataCounter = 0;
        descriptionText = GetComponentInChildren<TextMeshProUGUI>();
        btn = GetComponentInChildren<Button>();
        popUpFinish = GameObject.Find("Pop Up Finish").GetComponent<ButtonEventHandler>();
        popUpInstructions = GameObject.Find("Pop Up Instructions").GetComponent<ButtonEventHandler>();
        backButton = GameObject.Find("Back Game Button");


    }

    protected virtual void Start()
    {
        SetGameData();
        popUpInstructions.OnPopUpOpenAbove();
        backButtonOriginalScale = new Vector3(0.8f,0.8f,1f);
    }

    public virtual void OnNextClick()
    {

    }

    public virtual void OnBackClick()
    {
        if (gameDataCounter > 0)
        {
            gameDataCounter--;

            foreach (AnimationUI screenElement in screenElements)
            {
                screenElement.RescaleAnimation();
            }
            ScaleBackButtonToZero();
            SetGameData();
            return;
        }
        return;
    }

    protected virtual void SetGameData()
    {
       
    }

    protected void ScaleBackButtonToZero()
    {
        if (gameDataCounter == 0)
        {
            LeanTween.scale(backButton, Vector2.zero, 0.3f).setEaseOutBack();
        }
    }

    public void ScaleBackButtonOnHover()
    {
        if (gameDataCounter > 0)
        {
            Vector3 newScale = backButtonOriginalScale + new Vector3(0.1f, 0.1f);

            LeanTween.scale(backButton, newScale, 0.3f).setEaseInBack();
            return;
        }
        ScaleBackButtonToZero();
    }
    public void ScaleBackButtonToNormal()
    {
        if (gameDataCounter > 0)
        {
            LeanTween.scale(backButton, backButtonOriginalScale, 0.3f).setEaseOutBack();
            return;
        }
        ScaleBackButtonToZero();
    }
}
