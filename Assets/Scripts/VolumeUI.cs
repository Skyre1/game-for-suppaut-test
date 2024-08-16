using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VolumeUI : MonoBehaviour
{
    private Slider slider;

    private TextMeshProUGUI text;

    [SerializeField] private Image soundOff;
    [SerializeField] private Image soundOn;
    [SerializeField] private Image soundDisabled;

    private float volumeValue;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        text = GetComponentInChildren<TextMeshProUGUI>();
        slider.value = PlayerPrefs.GetFloat("Volume", 80f);
        
    }

    private void Update()
    {
        volumeValue = slider.value;
    }

    public void OnSliderValueChanged()
    {
        text.text = slider.value.ToString();

        if(slider.value > 0)
        {
            soundOn.enabled = true;
            soundOff.enabled = false;   
        }
        else
        {
            soundOn.enabled = false;
            soundOff.enabled = true;
        }

        PlayerPrefs.SetFloat("Volume", slider.value);
    }

    public float GetValue { get => volumeValue / 100; }

   
}
