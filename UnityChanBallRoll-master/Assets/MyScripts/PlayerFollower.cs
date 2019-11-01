using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    Vector3 offset;
    void Start()
    {
        offset = this.transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position = offset + player.transform.position;
    }
}
