﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {

    private int currWave; //welke wave het is.
    public int currEnemy; //hoeveel enemies er zijn gespawned.
    public int maxEnemy; //maximale enemies op de map.
    public float waveEnemy; //hoeveel enemies per wave.
    public float extraSpawn; //hoeveel extra enemies er zijn na de enemy cap.
    public GameObject zombie; //de zombie.
    public List<GameObject> spawnLoc = new List<GameObject>(); //in deze list komen de spawnpoints voor de zombies.
    public float waveTime; //hoeveel tijd er tussen de waves zit.
    public float spawnTime; //hoeveel tijd er tussen de spawning van zombies zit.

    private bool coroutineActive;
    private bool canSpawnExtra;

	void Start () {
        waveEnemy = 6; //verrander deze als je het aantal begin enemies wilt verranderen
        currWave = 0; //hoef je niet aan te passen
        maxEnemy = 30; //maximum aantal enemies dat in 1 keer op de map kunnen zitten
	}
	
	void Update () {
        EnemyCheck();
        ExtraEnemy ();
        if (Input.GetButtonDown ("Cancel")) {
            currEnemy--;
            //dit word aangepast met EnemyStats (Voor --)
        }
	}

    void EnemyCheck () {

        if (currEnemy == 0 && !coroutineActive) {
            currWave++;
            waveEnemy = Mathf.Ceil (waveEnemy *= 1.1f); //elke wave gaat het aantal zombies omhoog, afgerond naar boven.
            coroutineActive = true;
            StartCoroutine ("NextWave");
            if (waveEnemy > maxEnemy) {
                extraSpawn = waveEnemy - maxEnemy;
            }
        }
    }

    void ExtraEnemy () {
        int randomSpawnLoc = Random.Range (0, spawnLoc.Count);
        if (canSpawnExtra == true) {
            if (extraSpawn > 0 && currEnemy < maxEnemy) {
                Instantiate (zombie, spawnLoc [randomSpawnLoc].transform.position, Quaternion.identity);
                currEnemy++;
                extraSpawn--;
            }
        }
    }

    IEnumerator NextWave() {
        canSpawnExtra = false;
        yield return new WaitForSeconds(waveTime);

        for (int i = 0; i < waveEnemy; i++) {
            if (currEnemy < maxEnemy) {
                int randomSpawnLoc = Random.Range (0, spawnLoc.Count);
                yield return new WaitForSeconds (spawnTime);
                Instantiate (zombie, spawnLoc [randomSpawnLoc].transform.position, Quaternion.identity);
                currEnemy++;
            }
        }
        canSpawnExtra = true;
        coroutineActive = false;
    }
}
