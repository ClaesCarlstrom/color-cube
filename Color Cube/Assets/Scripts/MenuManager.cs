using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    private bool guideOn;
    private int savedLevel = 1; //level goes by buildindex. MainMenu = 0, Level 0 = 1
    public GameObject continueButton;
    void Start()
    {
        //Setting default values
        guideOn = true;

        if (PlayerPrefs.HasKey("Level"))
            savedLevel = PlayerPrefs.GetInt("Level");
        else
        {
            PlayerPrefs.SetInt("Level", 1); // Setting level to buildindex 1 = Level 00
            savedLevel = 1;
        }

        if (savedLevel == 1)
            continueButton.SetActive(false); //Disable Continuebutton if player hasn't reached anywhere

        GameData.RotationSensitivity = 10;
        GameData.MovementSensitivity = 250;
        GameData.MusicVolume = 0.7f;
        GameData.SoundVolume = 0.1f;
    }

    public void PlayGame()
    {
        PlayerPrefs.SetInt("Score", 0);

        if (guideOn)
            SceneManager.LoadScene("Level00");
        else
            SceneManager.LoadScene("Level01");
    }
    public void ContinueGame()
    {
        SceneManager.LoadScene(savedLevel); 
    }

    public void SetGuideOnOff(bool g)
    {
        guideOn = g;
    }

    public void SetRotationSensitivity(float r)
    {
        GameData.RotationSensitivity = r;
    }

    public void SetMovementSensitivity(float m)
    {
        GameData.MovementSensitivity = m;
    }

    public void SetMusicVolume(float v)
    {
        GameData.MusicVolume = v;
    }
    public void SetSoundVolume(float s)
    {
        GameData.SoundVolume = s;
    }

}
