using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");

        transform.position = player.transform.position;
    }
}
