using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject player;
    public GameObject killZone;
    public GameObject endZone;
    public float titleDeactivation;
    public Canvas ui;
    private bool playing;

    // Use this for initialization
    void Start () {
        playing = true;


        FindObjectOfType<Camera>().GetComponent<AudioSource>().volume = GameData.MusicVolume;
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
        else
        {
            if (player.transform.position.x < 20)
                ui.transform.Find("MoveGuideText").gameObject.SetActive(true);
            if (player.transform.position.x > 20) 
                ui.transform.Find("MoveGuideText").gameObject.SetActive(false);
            if (player.transform.position.x > 30)
                ui.transform.Find("JumpGuideText").gameObject.SetActive(true);
            if (player.transform.position.x > 40 || player.transform.position.x < 30)
                ui.transform.Find("JumpGuideText").gameObject.SetActive(false);
            if (player.transform.position.x > 50)
                ui.transform.Find("RotateGuideText").gameObject.SetActive(true);
            if (player.transform.position.x > 60 || player.transform.position.x < 50)
                ui.transform.Find("RotateGuideText").gameObject.SetActive(false);
            if (player.transform.position.x > 70)
                ui.transform.Find("RotateGuideText2").gameObject.SetActive(true);
            if (player.transform.position.x > 80 || player.transform.position.x < 70)
                ui.transform.Find("RotateGuideText2").gameObject.SetActive(false);
            if (player.transform.position.x > 85)
                ui.transform.Find("BlackGuideText").gameObject.SetActive(true);
            if (player.transform.position.x > 105 || player.transform.position.x < 85)
                ui.transform.Find("BlackGuideText").gameObject.SetActive(false);
            if (player.transform.position.x > 105)
                ui.transform.Find("EndGuideText").gameObject.SetActive(true);
            if (player.transform.position.x < 105)
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
