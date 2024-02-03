using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject endSceenPanel;
    [SerializeField] GameObject progressSlider;
    [SerializeField] GameEvent buttonPressedEvent;
    void Start()
    {
        endSceenPanel.SetActive(false);
    }

    void DeactivateAll()
    {
        endSceenPanel.SetActive(false);
        progressSlider.SetActive(false);
    }

    void ShowWinScreen()
    {
        DeactivateAll();
        endSceenPanel.SetActive(true);
    }

    #region Buttons
    public void RestartButton()
    {
        buttonPressedEvent.Raise(this,2); //2 --> Restart
        DeactivateAll();
        progressSlider.SetActive(true);
    }

    public void NextLevelButton()
    {
        buttonPressedEvent.Raise(this,3); //3 --> Next Level
        DeactivateAll();
        progressSlider.SetActive(true);
    }

    #endregion


    #region Events

    public void EventOnGameWin(Component sender,object data)
    {
        if(data is bool)
        {
            if((bool)data)
            {
                Invoke("ShowWinScreen",3);
            }
        }
    }

    public void EventOngameOver(Component sender,object data)
    {
        if((bool)data)
        {
            Invoke("ShowWinScreen",2);
        }
    }



    #endregion
}
