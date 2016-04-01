using UnityEngine;
using System.Collections;

public class Ingredient : MonoBehaviour {

	public int Id;
	public string Name;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public int GetId(){
		return Id;
	}

	public string GetName(){
		return Name;
	}
}
