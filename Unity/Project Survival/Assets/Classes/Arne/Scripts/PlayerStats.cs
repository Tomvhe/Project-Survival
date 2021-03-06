﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

	//weapons
	public List<GameObject> weapons = new List<GameObject>();
	public GameObject currentWeapon;

	//health 
	public float maxHP;
	public float health;
	public float healthPercentage;
	UIManager uim;



	private void Awake () {

		uim = GameObject.Find("Canvas").GetComponent<UIManager>();
		maxHP = 100;
		health = maxHP;
	}

	// Use this for initialization
	private void Start () {
		
		
	}
	
	// Update is called once per frame
	private void Update () {
		
	}
	public void PlayerHealth (float dmg) {

		health -= dmg;
		healthPercentage = health / maxHP;
		uim.CheckHealth();

	}
}
