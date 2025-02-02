﻿using System.Collections.Generic;

using UnityEngine;
public class EnemieSpawner : MonoBehaviour
 {
    List<GameObject> enemiesonScreen = new List<GameObject>();

    private void FixedUpdate()
    {
        if (GameManager.State != GameState.INGAME)
            return;
        if (enemiesonScreen.Count < 5)
        {
            //Spawn();
        }
    }

    private void Spawn()
    {
        GameObject Enemy = ItemAssets.Singleton.Enemies[0].EnemiePrefab;
        Enemy.AddComponent<Rigidbody2D>();
        enemiesonScreen.Add(Enemy);
        Enemy.transform.position = GlobalVariables.LocalPlayerPos;
        Instantiate(Enemy);
    }
}

