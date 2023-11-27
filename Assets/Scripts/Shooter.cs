using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] Movement movement; // used to access right-ness

    [SerializeField] GameObject arrow;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            Debug.Log("Fire1 Pressed!" + Time.fixedTime);
            Fire();
        }
    }

    private void FixedUpdate(){
        
    }

    void Fire(){
        if (Time.timeScale == 0.0f) return;
        Vector2 position = new Vector2(transform.position.x, transform.position.y);
        
        if (movement.facingRight()) {
            GameObject newProjectile = Instantiate(arrow, position, Quaternion.identity);
        } else {
            GameObject newProjectile = Instantiate(arrow, position, Quaternion.Euler(new Vector3(0, 180, 0)));
        }
    }
}
