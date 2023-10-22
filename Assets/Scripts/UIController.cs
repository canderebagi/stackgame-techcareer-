
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public ZeroBooster zeroBooster;
    public AudioSource audioSource;
    public LevelCreator levelCreator;
    
    public ÖdüllüReklam ödüllüReklam;
    public GameManager gameManager;
    TimeControl timeControl;
    BoosterControl boosterControl;
    public SpinManager spinManager;
    public GameObject gameScreen, settingsPopup, blurImage, ilkPanel, gamePanel, spinPopup, resumeGame, levelCompPop, gameOverPop;
    public Button settingsBtn, spinBtn, backBtn, pauseBtn, resumeBtn, restartBtn, skipLvlBtn, standBoosterBtn, timeBoosterBtn, spinpopspinBtn;
    public TextMeshProUGUI tapToStartTXT;


    void Start()
    {
        audioSource = audioSource.GetComponent<AudioSource>();
        spinManager.dailySpinText.text = "SPIN! " + "\n" + spinManager.dailyClaim.ToString() + "/2";
        boosterControl = FindObjectOfType<BoosterControl>();
        timeControl = FindObjectOfType<TimeControl>();
        if (gameManager.standBoosterSayi == 0)
        {
            standBoosterBtn.interactable = false;
        }
        if (gameManager.timeBoosterSayi == 0)
        {
            timeBoosterBtn.interactable = false;
        }
    }
    public void BackButton()
    {
        SceneManager.LoadScene(0);
    }
    public void SettingsPop()
    {
        blurImage.SetActive(true);
        settingsPopup.SetActive(true);
        gameScreen.SetActive(false);

        tapToStartTXT.enabled = false;
        settingsBtn.interactable = false;
        spinBtn.interactable = false;
        backBtn.interactable = false;
    }
    public void SettingsPopClose()
    {
        blurImage.SetActive(false);
        settingsPopup.SetActive(false);
        gameScreen.SetActive(true);

        tapToStartTXT.enabled = true;
        settingsBtn.interactable = true;
        spinBtn.interactable = true;
        backBtn.interactable = true;
    }
    public void SpinPop()
    {
        blurImage.SetActive(true);
        spinPopup.SetActive(true);
        gameScreen.SetActive(false);
        tapToStartTXT.enabled = false;
        settingsBtn.interactable = false;
        spinBtn.interactable = false;
        backBtn.interactable = false;
    }
    public void SpinPopClose()
    {
        if (spinManager.isSpin == false)
        {
            if (spinManager.dailyClaim == 0)
            {
                gameManager.saniye = 59;
                gameManager.dakika = 59;
                spinManager.dailyClaim = 2;
                PlayerPrefs.SetInt("DailyClaim", spinManager.dailyClaim);
                spinManager.dailySpinText.text = "SPIN!" + "\n" + spinManager.dailyClaim.ToString() + "/2";

            }
            if (gameManager.standBoosterSayi >= 0)
            {
                standBoosterBtn.interactable = true;
            }
            if (gameManager.timeBoosterSayi >= 0)
            {
                timeBoosterBtn.interactable = true;
            }
            blurImage.SetActive(false);
            spinPopup.SetActive(false);
            gameScreen.SetActive(true);

            tapToStartTXT.enabled = true;
            settingsBtn.interactable = true;
            spinBtn.interactable = true;
            backBtn.interactable = true;
        }
    }
    public void TapToStart()
    {
        ilkPanel.SetActive(false);
        gamePanel.SetActive(true);
        Time.timeScale = 1;
        zeroBooster.hýzcarpanýstand = 200;
        zeroBooster.hýzcarpanýtime = 200;
        if (gameManager.standBoosterSayi == 0)
        {
            standBoosterBtn.interactable = false;
        }
        if (gameManager.timeBoosterSayi == 0)
        {
            timeBoosterBtn.interactable = false;
        }
    }
    public void PauseGame()
    {
        resumeGame.SetActive(true);
        gameScreen.GetComponent<BoxCollider>().enabled = true;
        standBoosterBtn.interactable = false;
        timeBoosterBtn.interactable = false;
        zeroBooster.ReklamadsaddStick.interactable = false;
        zeroBooster.Reklamadsaddtime.interactable = false;
        AudioListener.volume = 0;
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        resumeGame.SetActive(false);
        gameScreen.GetComponent<BoxCollider>().enabled = false;


        if (gameManager.standBoosterSayi > 0)
        {
            standBoosterBtn.interactable = true;
        }
        if (gameManager.timeBoosterSayi > 0)
        {
            timeBoosterBtn.interactable = true;
        }
        zeroBooster.ReklamadsaddStick.interactable = true;
        zeroBooster.Reklamadsaddtime.interactable = true;
        AudioListener.volume = 1;
        Time.timeScale = 1;
    }
    public void StandAdd()
    {
        boosterControl = FindObjectOfType<BoosterControl>();
        if (boosterControl.sayac < boosterControl.bosstand.Length)
        {
            boosterControl.bosstand[boosterControl.sayac].SetActive(true);
            boosterControl.sayac++;
            gameManager.standBoosterSayi--;
            PlayerPrefs.SetInt("Stand", gameManager.standBoosterSayi);
            gameManager.standBoosterSayiTxt.text = gameManager.standBoosterSayi.ToString();


        }

        if (gameManager.standBoosterSayi == 0)
        {
            standBoosterBtn.interactable = false;
        }
    }

    public void ZamanDurdurma()
    {
        timeControl = FindObjectOfType<TimeControl>();
        timeControl.freezeeebaslangýc = 1f;
        gameManager.timeBoosterSayi--;
        PlayerPrefs.SetInt("Time", gameManager.timeBoosterSayi);
        gameManager.timeBoosterSayiTxt.text = gameManager.timeBoosterSayi.ToString();
        if (gameManager.timeBoosterSayi == 0)
        {
            timeBoosterBtn.interactable = false;
        }
    }
    public void Restart()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void SkipLevelAdv()
    {

        gameManager.standBoosterSayi -= 1;
        PlayerPrefs.SetInt("Stand", gameManager.standBoosterSayi);
        gameManager.standBoosterSayiTxt.text = gameManager.standBoosterSayi.ToString();
        gameManager.timeBoosterSayi -= 1;
        PlayerPrefs.SetInt("Time", gameManager.timeBoosterSayi);
        gameManager.timeBoosterSayiTxt.text = gameManager.timeBoosterSayi.ToString();

        levelCreator.NextLevel();



    }
    public void TestButton()
    {
        gameManager.standBoosterSayi = 3;
        PlayerPrefs.SetInt("Stand", gameManager.standBoosterSayi);
        gameManager.timeBoosterSayi = 3;
        PlayerPrefs.SetInt("Time", gameManager.timeBoosterSayi);
        gameManager.saniye = 10;
        PlayerPrefs.SetFloat("Saniye", gameManager.saniye);
        gameManager.dakika = 0;
        PlayerPrefs.SetInt("Dakika", gameManager.dakika);

    }
}
