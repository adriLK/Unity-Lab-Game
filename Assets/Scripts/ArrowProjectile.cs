using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowProjectile : MonoBehaviour
{
    [SerializeField] const float SPEED = 0.35f;
    
    [SerializeField] AudioSource destroySound;
    [SerializeField] BoxCollider2D bcObj;
    
    // Start is called before the first frame update
    void Start()
    {
        if (bcObj == null) {
            bcObj = GetComponent<BoxCollider2D>();
        }
        UpdateGravity();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGravity();
    }

    public void UpdateGravity(){
        bcObj.isTrigger = !PersistentData.Instance.GetGravity();
    }

    private void FixedUpdate(){
        transform.Translate(SPEED, 0, 0);
    }

    void OnBecameInvisible(){
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("StopProjectile") || other.CompareTag("Ground")) {
            AudioSource.PlayClipAtPoint(destroySound.clip, transform.position);
            Destroy(gameObject);
        }
    }
}
