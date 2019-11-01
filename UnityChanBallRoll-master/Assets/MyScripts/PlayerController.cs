using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    int count;
    public Text countText;
    AudioSource getSE;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        getSE = GetComponent<AudioSource>();
        UpdateScore();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveH, 0, moveV);
        rb.AddForce(move * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        string tag = other.tag;

        if(tag.Equals("Bottom"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        } 
        else if(tag.Equals("Item"))
        {
            other.gameObject.SetActive(false);
            count++;
            getSE.Play();
            UpdateScore();
        }
        
    }

    private void UpdateScore()
    {
        countText.text = "Score: " + count.ToString();
    }

}
