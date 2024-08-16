using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PraxisGames : GamesHandler
{

    [SerializeField] 
    private List<PraxisGameData> gameData = new List<PraxisGameData>();

    [SerializeField]
    private AnimationUI titleUI;

    

    public override void OnNextClick()
    {
        base.OnNextClick();

        if (gameDataCounter < gameData.Count - 1)
        {
            gameDataCounter++;

            foreach (AnimationUI screenElement in screenElements)
            {
                screenElement.RescaleAnimation();
            }
            SetGameData();
            ChangeTitle();
            return;
        }
        popUpFinish.OnPopUpOpen();
    }


    protected override void SetGameData()
    {
        base.SetGameData();

        descriptionText.text = gameData[gameDataCounter].description;
        btn.image.sprite = gameData[gameDataCounter].sprite;
    }

    public override void OnBackClick()
    {
        base.OnBackClick();
        ChangeTitle();
    }

    private void ChangeTitle()
    {

        titleUI.gameObject.GetComponent<TextMeshProUGUI>().text = gameDataCounter >= 10
            ? "EMOCIONES"
            : "PRAXIAS";

    }



}
