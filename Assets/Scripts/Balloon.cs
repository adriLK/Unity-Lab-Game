using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    [SerializeField] float Speed = 0.1f;
    [SerializeField] bool isFacingRight = true;
    [SerializeField] GameObject controller; 
    [SerializeField] AudioSource popSound;

    private int AvailablePoints = 5;

    private void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        if (controller == null)
        {
            controller = GameObject.FindGameObjectWithTag("GameController");
        }
        if (popSound == null)
        {
            popSound = GetComponent<AudioSource>();
        }

        InvokeRepeating("Embiggen", 5.0f, 5.0f);
        controller.GetComponent<Scorekeeper>().AddBalloon();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate(){
        transform.Translate(Speed, 0, 0);
    }

    void OnBecameInvisible(){
        if ((transform.position.y > 0) == isFacingRight) {
            Flip();
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        //Debug.Log("BAM!");
        if (other.CompareTag("FriendlyProjectile")) {
            Pop();
        }
    }

    private void Pop(){
        controller.GetComponent<Scorekeeper>().AddPoints(AvailablePoints);
        AudioSource.PlayClipAtPoint(popSound.clip, transform.position);
        controller.GetComponent<Scorekeeper>().RemoveBalloon();
        Destroy(gameObject);
    }

    private void Embiggen(){
        if (AvailablePoints == 1) {
            Destroy(gameObject);
        } else {
            AvailablePoints -= 1;
            gameObject.transform.localScale += new Vector3(0.05f, 0.05f, 0.05f);
        }
    }
}
