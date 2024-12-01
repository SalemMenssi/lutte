using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{

    private PlayerManager playerManager ;

    private void Start()
    {
        playerManager = GetComponentInParent<PlayerManager>();
    }

    
}
