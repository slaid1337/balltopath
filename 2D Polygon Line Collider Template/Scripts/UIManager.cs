﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * 2D Polygon Line Collider Package
 *
 * @license		    Unity Asset Store EULA https://unity3d.com/legal/as_terms
 * @author		    Indie Studio - Baraa Nasser
 * @Website		    https://indiestd.com
 * @Asset Store     https://assetstore.unity.com/publishers/9268
 * @Unity Connect   https://connect.unity.com/u/5822191d090915001dbaf653/column
 * @email		    info@indiestd.com
 *
 */

[DisallowMultipleComponent]
public class UIManager : MonoBehaviour {

	public static UIManager instance;
	public Text vechicleSpeed;

	void Awake(){
		if (instance == null) {
			instance = this;
		}
	}
}
