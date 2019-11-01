using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController_Complete : MonoBehaviour
{

    Rigidbody rb;
    public float speed;
    int count;
    public Text countText;
    AudioSource getSE;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        getSE = GetComponent<AudioSource>();
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
        if (other.gameObject.CompareTag("A"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
            getSE.Play();
        }
        else if (other.gameObject.CompareTag("B"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }

    void SetCountText()
    {
        countText.text = "ゲット数：" + count.ToString();
    }
}
