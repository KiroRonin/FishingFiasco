using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public GameObject player;

    void Update()
    {
        Vector3 targetPos = new Vector3(player.transform.position.x, this.transform.position.y, player.transform.position.z);

        transform.LookAt(targetPos);

    }
}
