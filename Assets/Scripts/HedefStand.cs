using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;


public class HedefStand : MonoBehaviour
{
    public ZeroBooster zeroBooster;
    public GameManager gameManager;
    public UIController uIController;
    public int TamamlananStandSayisi;
    public int HedefStandSayisi;
    TimeControl timeControl;

    private void Start()
    {
        timeControl = FindObjectOfType<TimeControl>();
    }
    public void StandTamamlandi()
    {
        TamamlananStandSayisi++;
        if (TamamlananStandSayisi == HedefStandSayisi)
        {
            Debug.Log("Level Comp Müzik");
            if (gameManager.standBoosterSayi == 0)
            {

                zeroBooster.ReklamadsaddStick.transform.position = zeroBooster.standAdsPosition.position;
            }
            if (gameManager.timeBoosterSayi == 0)
            {
                zeroBooster.Reklamadsaddtime.transform.position = zeroBooster.timeAdsPosition.position;
            }
            timeControl = FindObjectOfType<TimeControl>();
            timeControl.freezeeebaslangýc = 0f;
            timeControl.timeStopImage.enabled = false;
            timeControl.timebutton.SetActive(true);
            timeControl.CountdownObject.SetActive(false);
            timeControl.CountImage.GetComponentInChildren<Image>().fillAmount = 1;

            gameManager.audioSource.Play();
            uIController.audioSource.Stop();
            gameManager.gemSayi += 10;
            PlayerPrefs.SetInt("Gem", gameManager.gemSayi);
            gameManager.gemSayiTxt.text = gameManager.gemSayi.ToString();
            uIController.levelCompPop.SetActive(true);
            uIController.blurImage.SetActive(true);
            uIController.gameScreen.SetActive(false);
            uIController.pauseBtn.interactable = false;
            uIController.resumeBtn.interactable = false;
            uIController.restartBtn.interactable = false;
            uIController.skipLvlBtn.interactable = false;
            uIController.standBoosterBtn.interactable = false;
            uIController.timeBoosterBtn.interactable = false;
            uIController.backBtn.interactable = false;
 
        }
    }
}
