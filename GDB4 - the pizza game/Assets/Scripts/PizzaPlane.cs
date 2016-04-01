using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PizzaPlane : MonoBehaviour {

	public List<Pizza> thePizzas;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < 5; i++) {
			Pizza newPizza = new Pizza ();
			thePizzas.Add (newPizza);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
