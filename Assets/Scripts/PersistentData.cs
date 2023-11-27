using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PersistentData : MonoBehaviour
{

    [SerializeField] int playerScore;
    [SerializeField] string playerName;
    [SerializeField] float playerTime;
    [SerializeField] float volume;
    [SerializeField] bool gravityOn;

    public static PersistentData Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        //if (SceneManager.GetActiveScene().name == "menuScene") {
        //    playerScore = 0;
        //    playerName = "";
        //    playerTime = 0f;
        //}
    }

    // Start is called before the first frame update
    void Start()
    {
        playerScore = 0;
        playerName = "";
        playerTime = 0f;
        gravityOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetName(string s)
    {
        playerName = s;
    }

    public void SetScore(int s)
    {
        playerScore = s;
    }

    public void SetTime(float f)
    {
        playerTime = f;
    }

    public void SetVolume(float f) {
        volume = f;
    }
    public void ToggleGravity() {
        gravityOn = !gravityOn;
    }
    public void SetGravity(bool b) {
        gravityOn = b;
    }

    public string GetName()
    {
        return playerName;
    }

    public int GetScore()
    {
        return playerScore;
    }

    public float GetTime() {
        return playerTime;
    }
    public float GetVolume() {
        return volume;
    }
    public bool GetGravity() {
        return gravityOn;
    }



}
