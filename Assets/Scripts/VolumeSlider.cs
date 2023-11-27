using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    //[SerializeField] AudioListener audioL;
    [SerializeField] Slider slideObj;

    // Start is called before the first frame update
    void Start()
    {
        //if (audioL == null)
        //{
        //    audioL = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioListener>();
        //}
        if (slideObj == null) {
            slideObj = GetComponent<Slider>();
        }

        //slideObj.value = PersistentData.Instance.GetVolume();
        if (PlayerPrefs.HasKey("Volume")) {
            slideObj.value = PlayerPrefs.GetFloat("Volume");
        } else {
            PlayerPrefs.SetFloat("Volume", 0.5f);
            slideObj.value = PlayerPrefs.GetFloat("Volume");
        }
        UpdateVolume();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateVolume() {
        AudioListener.volume = slideObj.value;
        //PersistentData.Instance.SetVolume(slideObj.value);
        PlayerPrefs.SetFloat("Volume", slideObj.value);
    }
}
