using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //[SerializeField] private Vector3 offset = new Vector3(0f, 5f, -10f);
    public GameObject player;
    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - player.transform.position;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position= player.transform.position + offset;
        
    }
}
