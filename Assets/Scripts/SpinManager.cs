

using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class SpinManager : MonoBehaviour
{
 
    public GameManager gameManager;
    public Button spinBtn;
    public GameObject spinCircle;
    public float genSpeed, subSpeed, finalAngel;
    public TextMeshProUGUI dailySpinText;
    public int dailyClaim = 2;
    public bool isSpin = false;
    public bool odulver = false;

    void Start()
    {
        if (PlayerPrefs.HasKey("DailyClaim"))
        {
            dailyClaim = PlayerPrefs.GetInt("DailyClaim");

        }
    }

    void Update()
    {
        RewardControl();
        if (isSpin == true)
        {
            spinCircle.transform.Rotate(0, 0, genSpeed * Time.deltaTime, Space.World);
            genSpeed -= subSpeed * Time.deltaTime;
            spinBtn.interactable = false;
        }

        if (genSpeed <= 0)
        {
            genSpeed = 0;
            isSpin = false;
            spinBtn.interactable = true;
        }

        if (dailyClaim == 0)
        {
            spinBtn.interactable = false;
        }

    }
    public void SpinWheel()
    {

       
        gameManager.timeBoosterSayiTxt.text = gameManager.timeBoosterSayi.ToString();
        dailyClaim -= 1;
        PlayerPrefs.SetInt("DailyClaim", dailyClaim);
        dailySpinText.text = "SPIN! " + "\n" + dailyClaim.ToString() + "/2";
        genSpeed = Random.Range(600.0f, 700.0f);
        subSpeed = Random.Range(100.0f, 200.0f);
        isSpin = true;
        odulver = true;






    }
    public void RewardControl()
    {


        finalAngel = Mathf.RoundToInt(spinCircle.transform.eulerAngles.z);

        if (isSpin == false && odulver == true)
        {

            if (finalAngel >= 22.6 && finalAngel <= 67.6)
            {
                Debug.Log("time x1");

                gameManager.timeBoosterSayi += 1;
                PlayerPrefs.SetInt("Time", gameManager.timeBoosterSayi);
                gameManager.timeBoosterSayiTxt.text = gameManager.timeBoosterSayi.ToString();
                odulver = false;


            }
            if (finalAngel > 67.6 && finalAngel <= 112.6)
            {
                Debug.Log("gem x50");

                gameManager.gemSayi += 50;
                PlayerPrefs.SetInt("Gem", gameManager.gemSayi);
                gameManager.gemSayiTxt.text = gameManager.gemSayi.ToString();
                odulver = false;

            }
            if (finalAngel > 112.6 && finalAngel <= 157.6)
            {
                Debug.Log("stick x2");

                gameManager.standBoosterSayi += 2;
                PlayerPrefs.SetInt("Stand", gameManager.standBoosterSayi);
                gameManager.standBoosterSayiTxt.text = gameManager.standBoosterSayi.ToString();

                odulver = false;
            }
            if (finalAngel > 157.6 && finalAngel <= 202.6)
            {
                Debug.Log("time x2");
                gameManager.timeBoosterSayi += 2;
                PlayerPrefs.SetInt("Time", gameManager.timeBoosterSayi);
                gameManager.timeBoosterSayiTxt.text = gameManager.timeBoosterSayi.ToString();
                odulver = false;
            }
            if (finalAngel > 202.6 && finalAngel <= 247.6)
            {
                Debug.Log("gem100");

                gameManager.gemSayi += 100;
                PlayerPrefs.SetInt("Gem", gameManager.gemSayi);
                gameManager.gemSayiTxt.text = gameManager.gemSayi.ToString();
                odulver = false;

            }
            if (finalAngel > 247.6 && finalAngel <= 292.6)
            {
                Debug.Log("stick x3");

                gameManager.standBoosterSayi += 3;
                PlayerPrefs.SetInt("Stand", gameManager.standBoosterSayi);
                gameManager.standBoosterSayiTxt.text = gameManager.standBoosterSayi.ToString();

                odulver = false;

            }
            if (finalAngel > 292.6 && finalAngel < 337.6)
            {
                Debug.Log("time x3");

                gameManager.timeBoosterSayi += 3;
                PlayerPrefs.SetInt("Time", gameManager.timeBoosterSayi);
                gameManager.timeBoosterSayiTxt.text = gameManager.timeBoosterSayi.ToString();
                odulver = false;
            }
            if ((finalAngel > 337.6 && finalAngel <= 360) || (finalAngel >= 0 && finalAngel < 22.6))
            {
                Debug.Log("stick x1");

                gameManager.standBoosterSayi += 1;
                PlayerPrefs.SetInt("Stand", gameManager.standBoosterSayi);
                gameManager.standBoosterSayiTxt.text = gameManager.standBoosterSayi.ToString();

                odulver = false;
            }
        }

    }

}
