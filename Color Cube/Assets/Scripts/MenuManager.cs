using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    private bool guideOn;

    void Start()
    {
        //Setting default values
        guideOn = true;
        GameData.RotationSensitivity = 5;
        GameData.MovementSensitivity = 3;
        GameData.MusicVolume = 0.7f;

    }

    public void PlayGame()
    {
        if(guideOn)
            SceneManager.LoadScene("Level00");
        else
            SceneManager.LoadScene("Level01");
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
 
}
