using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stand : MonoBehaviour
{
    public GameObject HareketPozisyonu;
    public GameObject[] Soketler;
    public int doluSoket;
    public List<GameObject> cemberler;
   
    [SerializeField] HedefStand hedefStand;
    int CemberTamamlanmaSayisi;
    public GameObject EnUsttekiCemberiVer()
    {
        return cemberler[cemberler.Count - 1];
    }
    public GameObject MusaitSoketiVer()
    {
        return Soketler[doluSoket];
    }
    public void SoketDegistirmeIslemleri(GameObject SilinecekObje)
    {
        cemberler.Remove(SilinecekObje);
        if (cemberler.Count != 0)
        {
            doluSoket--;
            cemberler[cemberler.Count - 1].GetComponent<Cember>().hareketEdebilirmi = true;
        }
        else
        {
            doluSoket = 0;
        }
    }
    public void CemberleriKontrolEt()
    {
        if (cemberler.Count == 4)
        {
            string Renk = cemberler[0].GetComponent<Cember>().Renk;
            foreach (var item in cemberler)
            {
                if (Renk == item.GetComponent<Cember>().Renk)
                {
                    CemberTamamlanmaSayisi++;
                }
            }
            if (CemberTamamlanmaSayisi == 4)
            {
                
                hedefStand.StandTamamlandi();
                TamamlanmisStandIslemleri();
            }
            else
            {
                CemberTamamlanmaSayisi = 0;
            }
        }
    }
    void TamamlanmisStandIslemleri()
    {
        foreach (var item in cemberler)
        {
            item.GetComponent<Cember>().hareketEdebilirmi = false;
            Color32 color = item.GetComponent<MeshRenderer>().material.GetColor("_Color");
            color.a = 150;
            item.GetComponent<MeshRenderer>().material.SetColor("_Color", color);
            gameObject.tag = "TamamlanmýsStand";
        }
    }
}