using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DontDestroy;

public class Interface : MonoBehaviour {

    Text texto;
	// Use this for initialization
	void Start () {
        texto = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        texto.text = Singleton.vida.ToString();
	}
}
