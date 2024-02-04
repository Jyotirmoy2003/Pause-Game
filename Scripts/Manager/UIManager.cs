using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [SerializeField] RectTransform endSceenPanel;
    [SerializeField] CanvasGroup endSceenPanel_canvasGroud;
    [SerializeField] GameObject progressSlider;
    [SerializeField] GameEvent buttonPressedEvent;
    [SerializeField] List<Transform> ItemInsideendPanel=new List<Transform>();
    [SerializeField] float fadeTime=1;
    void Start()
    {
        endSceenPanel_canvasGroud.alpha=0;
        endSceenPanel.transform.localPosition=new Vector3(0f,-1000f,0f);
    }

    void DeactivateAll()
    {
        endSceenPanel_canvasGroud.alpha=1;
        endSceenPanel.transform.localPosition=new Vector3(0f,0f,0f);
        endSceenPanel.DOAnchorPos(new Vector2(0f,-1000f),fadeTime,false).SetEase(Ease.InOutQuint);
        endSceenPanel_canvasGroud.DOFade(0,fadeTime);

        progressSlider.SetActive(false);
    }

    void ShowWinScreen()
    {
        DeactivateAll();
        endSceenPanel_canvasGroud.alpha=0;
        endSceenPanel.transform.localPosition=new Vector3(0f,-1000f,0f);
        endSceenPanel.DOAnchorPos(new Vector2(0f,0f),fadeTime,false).SetEase(Ease.InOutQuint);
        endSceenPanel_canvasGroud.DOFade(1,fadeTime);
        
        StartCoroutine(ShowItems()); //add bouncing effect in all the items//
    }


    IEnumerator ShowItems()
    {
        foreach (var item in ItemInsideendPanel)
        {
            item.localScale=Vector3.zero;
        }
        yield return new WaitForSeconds(1f);

        foreach (var item in ItemInsideendPanel)
        {
            item.DOScale(1f,fadeTime).SetEase(Ease.OutBounce);
            AudioManager.instance.PlaySound("BUN",item.gameObject); //play boucy sound
            yield return new WaitForSeconds(0.25f);
        }
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
