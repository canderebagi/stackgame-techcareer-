using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class TimeControl : MonoBehaviour
{
    public ZeroBooster zeroBooster;
    public UIController uIController;
    public GameManager gameManager;
    public float zamanbaslangýc;
    public float zamancarpaný = 1f;
    public float freezeeebaslangýc = 0f;

    public TextMeshProUGUI sayacyazdýr;
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
   
        if (freezeeebaslangýc == 0 && !uIController.ilkPanel.activeSelf)
        {

            zamanbaslangýc -= Time.deltaTime * zamancarpaný;
            ibreImage.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (freezeeebaslangýc >= 1)
        {
            uIController.audioSource.Stop();
            freezeeebaslangýc += Time.deltaTime * zamancarpaný;
            zamanbaslangýc -= Time.deltaTime * 0f;
            ibreImage.transform.Rotate(0, 0, -82 * Time.deltaTime, Space.World);
            timeStopImage.enabled = true;
            timebutton.SetActive(false);
            currenttime -= Time.deltaTime * zamancarpaný;
            Countdown.text = "" + Mathf.Round(currenttime) + "s";
            CountImage.GetComponentInChildren<Image>().fillAmount -= Time.deltaTime * 0.2f;//Startta düzenle
            CountdownObject.SetActive(true);


            if (freezeeebaslangýc >= 6)
            {
                
                zamanbaslangýc -= Time.deltaTime * zamancarpaný;
                freezeeebaslangýc = 0f;
                timeStopImage.enabled = false;
                timebutton.SetActive (true);
                CountdownObject.SetActive(false);
                CountImage.GetComponentInChildren<Image>().fillAmount = 1f;//Startta düzenle
                currenttime = 5f;
            }
        }
        if (Mathf.Round(zamanbaslangýc) == 6)
        {

            uIController.audioSource.Play();

        }

        Gameover();

        sayacyazdýr.text = "" + Mathf.Round(zamanbaslangýc) + "s";
    }
    public void Gameover()
    {
        if (zamanbaslangýc <= 0f)
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