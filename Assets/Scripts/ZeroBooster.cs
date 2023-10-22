
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZeroBooster : MonoBehaviour
{
    public ÖdüllüReklam ödüllüReklam;
    public GameManager gameManager;
    public UIController uIController;
    public Button Reklamadsaddtime, ReklamadsaddStick;
    public Transform timeAdsPosition, standAdsPosition;
    public int hýzcarpanýtime = 200;
    public int hýzcarpanýstand = 200;
    void Update()
    {
        if (gameManager.standBoosterSayi == 0 && !uIController.ilkPanel.activeSelf)
        {

            ReklamadsaddStick.transform.Translate(new Vector3(1, 0, 0) * hýzcarpanýstand * Time.deltaTime);
        }

        if (gameManager.timeBoosterSayi == 0 && !uIController.ilkPanel.activeSelf)
        {

            Reklamadsaddtime.transform.Translate(new Vector3(1, 0, 0) * hýzcarpanýtime * Time.deltaTime);
        }

        if (Reklamadsaddtime.transform.position.x >= 32)
        {
            hýzcarpanýtime = 0;
        }
        if (ReklamadsaddStick.transform.position.x >= 32)
        {
            hýzcarpanýstand = 0;
        }

    }
    public void ZeroBoosterAdsClickTime()
    {

        Reklamadsaddtime.transform.position = timeAdsPosition.position;

        gameManager.timeBoosterSayi += 1;//Kalkacak bura
        PlayerPrefs.SetInt("Time", gameManager.timeBoosterSayi);
        gameManager.timeBoosterSayiTxt.text = gameManager.timeBoosterSayi.ToString();
        gameManager.standBoosterSayiTxt.text = gameManager.standBoosterSayi.ToString();
        if (gameManager.timeBoosterSayi >= 1)
        {
            uIController.timeBoosterBtn.interactable = true;
        }


    }
    public void ZeroBoosterAdsClickStick()
    {



        ReklamadsaddStick.transform.position = standAdsPosition.position;

        gameManager.standBoosterSayi += 1;//Kalkacak bura
        PlayerPrefs.SetInt("Stand", gameManager.standBoosterSayi);
        gameManager.standBoosterSayiTxt.text = gameManager.standBoosterSayi.ToString();
        gameManager.timeBoosterSayiTxt.text = gameManager.timeBoosterSayi.ToString();
        if (gameManager.standBoosterSayi >= 1)
        {
            uIController.standBoosterBtn.interactable = true;
        }


    }

}
