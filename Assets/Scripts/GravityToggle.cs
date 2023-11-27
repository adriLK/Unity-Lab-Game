using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GravityToggle : MonoBehaviour
{
    [SerializeField] Toggle toggleObj;
    // Start is called before the first frame update
    void Start()
    {
        if (toggleObj == null) {
            toggleObj = GetComponent<Toggle>();
        }
        toggleObj.isOn = PersistentData.Instance.GetGravity();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleGravity(){
        PersistentData.Instance.SetGravity(toggleObj.isOn);
    }
}
