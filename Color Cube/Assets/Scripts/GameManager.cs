using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject player;
    public GameObject killZone;
    public GameObject endZone;
    public float titleDeactivation;
    public Canvas ui;
    private bool playing;
    private int currentScore;
    private int platformScore = 55;
    public Text scoreText;
    
    // Use this for initialization
    void Start () {
        PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex);
        playing = true;
        FindObjectOfType<Camera>().GetComponent<AudioSource>().volume = GameData.MusicVolume;

//        if (GameData.SoundVolume > 0)
  //      {
            PlatformCollider[] platforms = FindObjectsOfType<PlatformCollider>();
            Debug.Log("PlatformColliders found: " + platforms.Length);

        //Jag vet inte vad jag håller på med här...
        if (PlayerPrefs.HasKey("Score"))
                currentScore = PlayerPrefs.GetInt("Score") - platforms.Length*platformScore;
            else
                currentScore = 0 - platforms.Length * platformScore;

       if(scoreText!=null)
            scoreText.text = currentScore.ToString();

            Debug.Log("Setting volume to: " + GameData.SoundVolume);
            foreach (var platform in platforms)
                platform.GetComponent<PlatformCollider>().audioSource.volume = GameData.SoundVolume;
    //    }
	}

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            playing = false;
            SceneManager.LoadScene("MainMenu");
        }

        //Cheat
        if(Input.GetKey(KeyCode.C))
        {
            playing = false;
            SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 2);
        }

    }

    void FixedUpdate () {
        if (player.transform.position.y < killZone.transform.position.y && playing)
            RestartLevel();
        if (player.transform.position.x > endZone.transform.position.x && playing)
            NextLevel();

        if (titleDeactivation > 0)
        {
            if (player.transform.position.x > titleDeactivation)
                ui.transform.Find("TitleText").gameObject.SetActive(false);
        }
        else // Guide Text on Tutorial Level
        {
            if (player.transform.position.x > -20) //Start
                ui.transform.Find("MoveGuideText").gameObject.SetActive(true);
            if (player.transform.position.x > 20)  //Stop
                ui.transform.Find("MoveGuideText").gameObject.SetActive(false);
            if (player.transform.position.x > 25)  //Start
                ui.transform.Find("JumpGuideText").gameObject.SetActive(true);
            if (player.transform.position.x > 40 || player.transform.position.x < 25) //Stop
                ui.transform.Find("JumpGuideText").gameObject.SetActive(false);
            if (player.transform.position.x > 60) //Start
                ui.transform.Find("RotateGuideText").gameObject.SetActive(true);
            if (player.transform.position.x > 95 || player.transform.position.x < 60) //Stop
                ui.transform.Find("RotateGuideText").gameObject.SetActive(false);
            if (player.transform.position.x > 180)  //Start
                ui.transform.Find("EndGuideText").gameObject.SetActive(true);
            if (player.transform.position.x > 200 || player.transform.position.x < 180) //Stop
                ui.transform.Find("EndGuideText").gameObject.SetActive(false);
        }
    }

    void RestartLevel()
    {
        playing = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void NextLevel()
    {
        playing = false;
        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextLevel < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(nextLevel);
        else
            Debug.Log("next level = " + nextLevel + " and scene count = " + SceneManager.sceneCountInBuildSettings);
    }

}
