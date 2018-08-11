﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsSpawner : MonoBehaviour {

    public GameObject[] itemsToSpawn;
    public float        spawnTime = 2;

    public int width  = 50;
    public int height = 50;


    public void Start() { StartCoroutine(SpawnItems()); }


    private IEnumerator SpawnItems() {
        while ( true ) {
            yield return new WaitForSeconds(spawnTime);

            Vector2 pos = GetRandomPos();
            SpawnOne(pos);
        }
    }


    private void SpawnOne(Vector2 pos) {
        if ( itemsToSpawn.Length == 0 )
            return;

        Instantiate(itemsToSpawn[Random.Range(0,itemsToSpawn.Length)], pos, Quaternion.identity);
    }


    private Vector2 GetRandomPos() {
        return new Vector2(transform.position.x + Random.Range(-width / 2,  width / 2),
                           transform.position.y + Random.Range(-height / 2, height / 2));
    }


    private void OnDrawGizmos() { Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 1)); }

}