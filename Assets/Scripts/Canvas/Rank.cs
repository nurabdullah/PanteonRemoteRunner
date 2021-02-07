using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Rank : MonoBehaviour
{
    public List<Transform> enemies;
    public Transform player;
    
    private void Update()
    {
        GetComponent<TMP_Text>().text = "Rank:" + getRank();
    }

    private int getRank()
    {
        int counter = 1;
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i].position.z > player.position.z)
            {
                counter++;
            }
        }

        return counter;
    }
    
}
