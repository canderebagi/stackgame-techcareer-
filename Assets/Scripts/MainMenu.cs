using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    
    public SpinManager spinManager;
    public GameObject shopBg,settingsPopup,playBtn,spinPopup;
    public Button settingsBtn, shopBtn, spinBtn, quitBtn;

    public void ResumeLevel()
    {
        SceneManager.LoadScene(1);
        //SceneManager.LoadScene(level);
    }
    public void Shop()
    {
        shopBg.SetActive(true);

    }
    public void ShopQuit()
    {
        shopBg.SetActive(false);
    }
    public void SettingsPop()
    {
        
        settingsPopup.SetActive(true);
        playBtn.SetActive(false);
        settingsBtn.interactable = false;
        shopBtn.interactable = false;
        spinBtn.interactable = false;
        quitBtn.interactable = false;
        

    }
    public void SettingsPopClose()
    {

        settingsPopup.SetActive(false);
        playBtn.SetActive(true);
        settingsBtn.interactable = true;
        shopBtn.interactable = true;
        spinBtn.interactable = true;
        quitBtn.interactable = true;
    }
    public void SpinPop()
    {
        
        spinPopup.SetActive(true);
        playBtn.SetActive(false);
        settingsBtn.interactable = false;
        shopBtn.interactable = false;
        spinBtn.interactable = false;
        quitBtn.interactable = false;
    }
    public void SpinPopClose()
    {
        if (spinManager.isSpin==false)
        {
            //if (/*spinManager.isClick==false*/)
            //{
            //    //spinManager.isClick = true;
            //}
            spinPopup.SetActive(false);
            playBtn.SetActive(true);
            settingsBtn.interactable = true;
            shopBtn.interactable = true;
            spinBtn.interactable = true;
            quitBtn.interactable = true;
        }
        
    }


    public void QuitApp()
    {
        Application.Quit();
    }
    
}
