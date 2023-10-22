using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    public GameManager gameManager;
    public UIController uIController;
    public TextMeshProUGUI levelyazdir;
    public int level = 0;
    public GameObject[] Levels;

    private void Start()
    {
        PlayerPrefs.DeleteKey("Level");
        if (PlayerPrefs.HasKey("Level"))
        {
            level = PlayerPrefs.GetInt("Level");

        }
        else
        {
            PlayerPrefs.SetInt("Level", 0);
        }
        Levels[level].SetActive(true);
        levelyazdir.text = "Level " + (level+1);
    }
  
    public void NextLevel()
    {
        level++;
        PlayerPrefs.SetInt("Level", level);
        levelyazdir.text = "Level " + (level+1);
        gameManager.audioSource.Stop();
        
        uIController.ilkPanel.SetActive(true);
        uIController.gameScreen.SetActive(true);
        uIController.levelCompPop.SetActive(false);
        
        uIController.gamePanel.SetActive(false);
        uIController.blurImage.SetActive(false);


        uIController.pauseBtn.interactable = true;
        uIController.resumeBtn.interactable = true;
        uIController.restartBtn.interactable = true;
        uIController.skipLvlBtn.interactable = true;
        uIController.standBoosterBtn.interactable = true;
        uIController.timeBoosterBtn.interactable = true;
        uIController.backBtn.interactable = true;

        for (int i = 0; i < Levels.Length; i++)
        {
            if (i == 0)
            {
                Levels[level].SetActive(true);

            }
            else
            {
              
                Levels[level - 1].SetActive(false);
                Levels[level].SetActive(true);

            }

        }

    }
}
