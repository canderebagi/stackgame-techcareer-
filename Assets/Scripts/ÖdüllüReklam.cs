
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ÖdüllüReklam : MonoBehaviour
{
    public GameManager gameManager;


    public int hızcarpanıtime = 200;
    public int hızcarpanıstand = 200;
    void Start()
    {


    }


    public void OdulAgaci()
    {
        gameManager.standBoosterSayi += 1;
        PlayerPrefs.SetInt("Stand", gameManager.standBoosterSayi);
        gameManager.standBoosterSayiTxt.text = gameManager.standBoosterSayi.ToString();
        gameManager.timeBoosterSayi += 1;
        PlayerPrefs.SetInt("Time", gameManager.timeBoosterSayi);
        gameManager.timeBoosterSayiTxt.text = gameManager.timeBoosterSayi.ToString();
    }


}
