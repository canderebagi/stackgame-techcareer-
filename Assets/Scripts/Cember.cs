using RDG;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cember : MonoBehaviour
{
    public Settings settings;
    public AudioClip cemberSecAudio, cemberGeriOturAudio, cemberGitAudio;
    AudioSource audioSource;

    public GameObject aitOlduguStand;
    public GameObject aitOlduguCemberSoketi;
    public bool hareketEdebilirmi;
    public string Renk;
    public GameManager gameManager;
    GameObject hareketPozisyonu, gidecegiStand;
    bool secildi, posDegistir, soketOtur, soketeGeriGit;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    public void HareketEt(string islem, GameObject Stand = null, GameObject Soket = null, GameObject GidilecekObje = null)
    {
        switch (islem)
        {
            case "Secim":
                hareketPozisyonu = GidilecekObje;
                secildi = true;
                break;
            case "PozisyonDegistir":
                gidecegiStand = Stand;
                aitOlduguCemberSoketi = Soket;
                hareketPozisyonu = GidilecekObje;
                posDegistir = true;
                break;
            case "SoketeGeriGit":
                soketeGeriGit = true;
                break;

        }
    }
    // Update is called once per frame
    void Update()
    {
        if (secildi)
        {
            transform.position = Vector3.Lerp(transform.position, hareketPozisyonu.transform.position, .7f);
            if (Vector3.Distance(transform.position, hareketPozisyonu.transform.position) < .10f)
            {
                Vibration.Vibrate(settings.haptic1, settings.haptic2);
                audioSource.PlayOneShot(cemberSecAudio);
                secildi = false;
            }
        }
        if (posDegistir)
        {
            transform.position = Vector3.Lerp(transform.position, hareketPozisyonu.transform.position, .7f);
            if (Vector3.Distance(transform.position, hareketPozisyonu.transform.position) < .10f)
            {
                audioSource.PlayOneShot(cemberGitAudio);
                posDegistir = false;
                soketOtur = true;
            }
        }
        if (soketOtur)
        {
            transform.position = Vector3.Lerp(transform.position, aitOlduguCemberSoketi.transform.position, .7f);
            if (Vector3.Distance(transform.position, aitOlduguCemberSoketi.transform.position) < .10f)
            {
                Vibration.Vibrate(settings.haptic1, settings.haptic2);
                transform.position = aitOlduguCemberSoketi.transform.position;
                soketOtur = false;
                aitOlduguStand = gidecegiStand;
                if (aitOlduguStand.GetComponent<Stand>().cemberler.Count > 1)
                {
                    aitOlduguStand.GetComponent<Stand>().cemberler[aitOlduguStand.GetComponent<Stand>().cemberler.Count - 2].GetComponent<Cember>().hareketEdebilirmi = false;
                }
                gameManager.HareketVar = false;
            }
        }
        if (soketeGeriGit)
        {
            transform.position = Vector3.Lerp(transform.position, aitOlduguCemberSoketi.transform.position, .7f);
            if (Vector3.Distance(transform.position, aitOlduguCemberSoketi.transform.position) < .10f)
            {
                Vibration.Vibrate(settings.haptic1, settings.haptic2);
                Debug.Log(settings.haptic1);
                Debug.Log(settings.haptic2);
                transform.position = aitOlduguCemberSoketi.transform.position;
                soketeGeriGit = false;
                audioSource.PlayOneShot(cemberGeriOturAudio);
                gameManager.HareketVar = false;
            }
        }
    }
}