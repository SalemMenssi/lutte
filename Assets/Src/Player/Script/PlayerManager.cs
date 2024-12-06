using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public Player player;
    




    void Start()
    {
        player = new Player("Slimre");
        player.DisplayPlayerInfo();
    }

    

    
   
}
