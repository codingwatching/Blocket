﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


/// <summary>
/// [TODO - Doesn't work properly]
/// </summary>
 public class EnemieSpawner : MonoBehaviour
 {
    List<GameObject> enemiesonScreen = new List<GameObject>();

    private void FixedUpdate()
    {
        if(enemiesonScreen.Count < 5)
        {
            //Spawn();
        }
    }

    private void Spawn()
    {
        GameObject Enemy = GlobalVariables.Assets.Enemies[0].EnemiePrefab;
        enemiesonScreen.Add(Enemy);
        Enemy.transform.position = GlobalVariables.LocalPlayerPos;
        Instantiate(Enemy);
    }
}

