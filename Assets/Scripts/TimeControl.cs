using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class TimeControl : MonoBehaviour
{
    public ZeroBooster zeroBooster;
    public UIController uIController;
    public GameManager gameManager;
    public float zamanbaslang�c;
    public float zamancarpan� = 1f;
    public float freezeeebaslang�c = 0f;

    public TextMeshProUGUI sayacyazd�r;
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
   
        if (freezeeebaslang�c == 0 && !uIController.ilkPanel.activeSelf)
        {

            zamanbaslang�c -= Time.deltaTime * zamancarpan�;
            ibreImage.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (freezeeebaslang�c >= 1)
        {
            uIController.audioSource.Stop();
            freezeeebaslang�c += Time.deltaTime * zamancarpan�;
            zamanbaslang�c -= Time.deltaTime * 0f;
            ibreImage.transform.Rotate(0, 0, -82 * Time.deltaTime, Space.World);
            timeStopImage.enabled = true;
            timebutton.SetActive(false);
            currenttime -= Time.deltaTime * zamancarpan�;
            Countdown.text = "" + Mathf.Round(currenttime) + "s";
            CountImage.GetComponentInChildren<Image>().fillAmount -= Time.deltaTime * 0.2f;//Startta d�zenle
            CountdownObject.SetActive(true);


            if (freezeeebaslang�c >= 6)
            {
                
                zamanbaslang�c -= Time.deltaTime * zamancarpan�;
                freezeeebaslang�c = 0f;
                timeStopImage.enabled = false;
                timebutton.SetActive (true);
                CountdownObject.SetActive(false);
                CountImage.GetComponentInChildren<Image>().fillAmount = 1f;//Startta d�zenle
                currenttime = 5f;
            }
        }
        if (Mathf.Round(zamanbaslang�c) == 6)
        {

            uIController.audioSource.Play();

        }

        Gameover();

        sayacyazd�r.text = "" + Mathf.Round(zamanbaslang�c) + "s";
    }
    public void Gameover()
    {
        if (zamanbaslang�c <= 0f)
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