using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OnomGames : GamesHandler
{
    [SerializeField] 
    private List<OnomGameData> gameData = new List<OnomGameData>();
    
    private AnimationUI descriptiveTextAnim;

    [SerializeField] 
    private TextMeshProUGUI descriptiveText;

    [SerializeField]
    private TextMeshProUGUI nameText;

    private AudioSource audioSource;

    [SerializeField]
    private VolumeUI volume;

    protected override void Awake()
    {
        base.Awake();

        audioSource = GetComponent<AudioSource>();
        descriptiveTextAnim = descriptiveText.GetComponent<AnimationUI>();
        audioSource.volume = PlayerPrefs.GetFloat("Volume", 0.8f);
    }

    private void Update()
    {
        audioSource.volume = volume.GetValue;
    }

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
            return;
        }
        popUpFinish.OnPopUpOpen();
    }



    protected override void SetGameData()
    {
        base.SetGameData();

        btn.image.sprite = gameData[gameDataCounter].sprite;
        audioSource.clip = gameData[gameDataCounter].audioClip;
        descriptionText.text = gameData[gameDataCounter].audioName;
        nameText.text = gameData[gameDataCounter].animalName;

    }

    public void PlayAudio()
    {
        descriptiveText.text = gameData[gameDataCounter].descriptiveText;
        descriptiveTextAnim.DescriptiveTextAnimation();
        audioSource.Play();
    }

}
