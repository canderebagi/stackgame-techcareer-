using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class TimeControl : MonoBehaviour
{
    public ZeroBooster zeroBooster;
    public UIController uIController;
    public GameManager gameManager;
    public float zamanbaslangıc;
    public float zamancarpanı = 1f;
    public float freezeeebaslangıc = 0f;

    public TextMeshProUGUI sayacyazdır;
    public Image CountImage, ibreImage;
    public Image timeStopImage;
    public GameObject timebutton;
    public float currenttime;
    public TextMeshProUGUI Countdown;
    public GameObject CountdownObject;
    void Start()
    {
        currenttime = 5f;
       
    }
    void Update()
    {
   
        if (freezeeebaslangıc == 0 && !uIController.ilkPanel.activeSelf)
        {

            zamanbaslangıc -= Time.deltaTime * zamancarpanı;
            ibreImage.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (freezeeebaslangıc >= 1)
        {
            uIController.audioSource.Stop();
            freezeeebaslangıc += Time.deltaTime * zamancarpanı;
            zamanbaslangıc -= Time.deltaTime * 0f;
            ibreImage.transform.Rotate(0, 0, -82 * Time.deltaTime, Space.World);
            timeStopImage.enabled = true;
            timebutton.SetActive(false);
            currenttime -= Time.deltaTime * zamancarpanı;
            Countdown.text = "" + Mathf.Round(currenttime) + "s";
            CountImage.GetComponentInChildren<Image>().fillAmount -= Time.deltaTime * 0.2f;//Startta düzenle
            CountdownObject.SetActive(true);


            if (freezeeebaslangıc >= 6)
            {
                
                zamanbaslangıc -= Time.deltaTime * zamancarpanı;
                freezeeebaslangıc = 0f;
                timeStopImage.enabled = false;
                timebutton.SetActive (true);
                CountdownObject.SetActive(false);
                CountImage.GetComponentInChildren<Image>().fillAmount = 1f;//Startta düzenle
                currenttime = 5f;
            }
        }
        if (Mathf.Round(zamanbaslangıc) == 6)
        {

            uIController.audioSource.Play();

        }

        Gameover();

        sayacyazdır.text = "" + Mathf.Round(zamanbaslangıc) + "s";
    }
    public void Gameover()
    {
        if (zamanbaslangıc <= 0f)
        {
            Debug.Log("timeout");
            if (gameManager.standBoosterSayi == 0)
            {

                zeroBooster.ReklamadsaddStick.transform.position = zeroBooster.standAdsPosition.position;
            }
            if (gameManager.timeBoosterSayi == 0)
            {
                zeroBooster.Reklamadsaddtime.transform.position = zeroBooster.timeAdsPosition.position;
            }
            uIController.audioSource.Stop();
            uIController.gameOverPop.SetActive(true);
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