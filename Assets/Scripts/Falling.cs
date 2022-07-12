using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    [SerializeField]
    public float speed;
    float temp = 3;

    [SerializeField]
    public AudioSource coinSound;

    

    void Start()
    {
        //speed = temp;
        coinSound = GetComponent<AudioSource>();
    
    }

    void Update()
    {
        
        /*
        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            Debug.Log("Online!");
        }
        */
        transform.position += Vector3.down * speed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            temp = speed;
            speed = 0;
            gameObject.SetActive(true);
            gameObject.GetComponent<Animator>().Play("Flip", -1, 0);
            //gameObject.GetComponent<AudioSource>().Play();
            //coinSound.Play();
            StartCoroutine(Delay());
            
        }
        else if(collision.CompareTag("Character"))
        {
            
            CoinsCount.instance.Increase();
            gameObject.GetComponent<Animator>().Play("Idle");
            
            gameObject.SetActive(false);
            speed = temp;
            
        }
       
    }
    
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(5.16f);
        gameObject.SetActive(false);
        speed = temp;

    }
}
