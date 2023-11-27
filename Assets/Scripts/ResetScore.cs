using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PersistentData.Instance.SetScore(0);
        PersistentData.Instance.SetTime(0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
