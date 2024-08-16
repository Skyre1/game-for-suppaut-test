using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class ButtonEventHandler : MonoBehaviour
{
    private List<Button> buttons = new List<Button>();
    private GameObject ui;
    [SerializeField] private GameObject darkenedBg;

    private void Awake()
    {
        ui = GameObject.Find("UI");
        buttons = ui.GetComponentsInChildren<Button>(true).ToList();
    }

    public void DebugTesting()
    {
        Debug.Log("Testing button " + name);
    }

    public void DisableButtonsOnUI()
    {
        foreach(Button button in buttons)
        {
            button.enabled = false;
        }
    }
    private void EnableButtonsOnUI()
    {
        foreach (Button button in buttons)
        {
            button.enabled = true;
        }
    }


    public void OnPopUpClose()
    {
        EnableButtonsOnUI();
        darkenedBg.SetActive(false);
        LeanTween.move(gameObject, new Vector3(30f, 0f, 0f), 0.5f);
    }

    public void OnPopUpOpen()
    {
        gameObject.SetActive(true);
        DisableButtonsOnUI();
        LeanTween.moveX(gameObject, 0f, 0.8f).setEaseInOutBack().setOnComplete(EnableDarkBg);
    }

    public void OnPopUpOpenAbove()
    {
        DisableButtonsOnUI();
        LeanTween.moveY(gameObject, 0f, 0.5f).setEaseInOutBack().setOnComplete(EnableDarkBg);
    }

    public void OnPopUpCloseAbove()
    {
        EnableButtonsOnUI();
        darkenedBg.SetActive(false);
        LeanTween.moveY(gameObject, 20f, 0.5f).setEaseInOutBack();
    }


    public void QuitApplication()
    {
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }




    public void OnLoadScene(string sceneName)
    {

        SceneManager.LoadScene(sceneName);
    }

    private void EnableDarkBg()
    {
        darkenedBg.SetActive(true);
    }



    private void DisableDarkBg()
    {
        darkenedBg.SetActive(false);
    }

}
