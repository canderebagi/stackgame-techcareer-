using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AudioSource audioSource;
    public UIController uIController;
    public SpinManager spinManager;
    GameObject SeciliObje;
    GameObject SeciliStand;
    Cember cember;
    public bool HareketVar;
    public int standBoosterSayi,timeBoosterSayi, gemSayi;
    

    public float saniye;
    public int dakika;
    public TextMeshProUGUI dakikaTxt, saniyeTxt, standBoosterSayiTxt, timeBoosterSayiTxt, gemSayiTxt;
    void Start()
    {
        Application.targetFrameRate = 60;
        audioSource = audioSource.GetComponent<AudioSource>();
       

        if (PlayerPrefs.HasKey("Dakika"))
        {
            dakika = PlayerPrefs.GetInt("Dakika");
        }
        
        if (PlayerPrefs.HasKey("Saniye"))
        {
            saniye = PlayerPrefs.GetFloat("Saniye");
        }
       
        if (PlayerPrefs.HasKey("Time"))
        {
            timeBoosterSayi = PlayerPrefs.GetInt("Time");
            
        }
        else
        {
            PlayerPrefs.SetInt("Time", 3);
        }
        
        if (PlayerPrefs.HasKey("Stand"))
        {
            standBoosterSayi = PlayerPrefs.GetInt("Stand");
            
        }
        else
        {
            PlayerPrefs.SetInt("Stand", 3);
        }

        if (PlayerPrefs.HasKey("Gem"))
        {
            gemSayi = PlayerPrefs.GetInt("Gem");
           
        }
        
        gemSayiTxt.text = gemSayi.ToString();
        timeBoosterSayiTxt.text = timeBoosterSayi.ToString();
        standBoosterSayiTxt.text = standBoosterSayi.ToString();
        
    }


    public void SpinTime()
    {
        dakikaTxt.text = "" + dakika;
        PlayerPrefs.SetFloat("Saniye", saniye);
        PlayerPrefs.SetInt("Dakika", dakika);

        if (saniye <= 0)
        {
            saniye = 59f;
            dakika--;
        }

        if (dakika == -1)
        {           
            saniye = 0;
            dakika = 0;
        }
        if (saniye == 0 && dakika == 0)
        {

            uIController.spinBtn.interactable = true;
            


        }
        if (saniye > 0)
        {
            saniye -= Time.deltaTime;
            uIController.spinBtn.interactable = false;
            


        }

        if (saniye >= 9.50)
        {
            saniyeTxt.text = "" + Mathf.Round(saniye);

        }
        else
        {
            saniyeTxt.text = "" + "0" + Mathf.Round(saniye);
        }
        if (dakika >= 9.50)
        {
            dakikaTxt.text = "" + dakika;

        }
        else
        {
            dakikaTxt.text = "0" + dakika;
        }
    }

    void Update()
    {
        SpinTime();
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 100))
            {
                if (hit.collider != null && hit.collider.CompareTag("Stand"))
                {
                    if (SeciliObje != null && SeciliStand != hit.collider.gameObject)
                    {
                        Stand stand = hit.collider.GetComponent<Stand>();
                        if (stand.cemberler.Count != 4 && stand.cemberler.Count != 0)
                        {
                            if (cember.Renk == stand.cemberler[stand.cemberler.Count - 1].GetComponent<Cember>().Renk)
                            {
                                SeciliStand.GetComponent<Stand>().SoketDegistirmeIslemleri(SeciliObje);
                                cember.HareketEt("PozisyonDegistir", hit.collider.gameObject, stand.MusaitSoketiVer(), stand.HareketPozisyonu);
                                stand.doluSoket++;
                                stand.cemberler.Add(SeciliObje);
                                stand.CemberleriKontrolEt();
                                SeciliObje = null;
                                SeciliStand = null;
                            }
                            else
                            {
                                cember.HareketEt("SoketeGeriGit");
                                SeciliObje = null;
                                SeciliStand = null;
                            }
                        }
                        else if (stand.cemberler.Count == 0)
                        {
                            SeciliStand.GetComponent<Stand>().SoketDegistirmeIslemleri(SeciliObje);
                            cember.HareketEt("PozisyonDegistir", hit.collider.gameObject, stand.MusaitSoketiVer(), stand.HareketPozisyonu);
                            stand.doluSoket++;
                            stand.cemberler.Add(SeciliObje);
                            stand.CemberleriKontrolEt();
                            SeciliObje = null;
                            SeciliStand = null;
                        }
                        else
                        {
                            cember.HareketEt("SoketeGeriGit");
                            SeciliObje = null;
                            SeciliStand = null;
                        }
                    }
                    else if (SeciliStand == hit.collider.gameObject)
                    {
                        cember.HareketEt("SoketeGeriGit");
                        SeciliObje = null;
                        SeciliStand = null;
                    }
                    else
                    {
                        Stand _Stand = hit.collider.GetComponent<Stand>();
                        if (_Stand.doluSoket != 0)
                        {
                            SeciliObje = _Stand.EnUsttekiCemberiVer();
                            cember = SeciliObje.GetComponent<Cember>();
                            HareketVar = true;
                            if (cember.hareketEdebilirmi)
                            {
                                cember.HareketEt("Secim", null, null, cember.aitOlduguStand.GetComponent<Stand>().HareketPozisyonu);
                                SeciliStand = cember.aitOlduguStand;
                            }
                        }
                    }
                }
            }
        }
    }
   
}
    