using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pizza {

	//public Texture Texture;
	public Dictionary<string, int> _neededIngredients = new Dictionary<string, int>();
	public string Name;
// Use this for initialization
//	void Start () {
//		createIngredientList ();
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		
//	}

	public Pizza(string Name){
		this.Name = Name;
		createIngredientList ();
	}

	public void createIngredientList(){
		for (int i = 0; i < Random.Range(3, 5); i++) {
			bool foundIngredient = false;
			string ingredientName = "";
			while (!foundIngredient) {
				switch (Random.Range(1,8)) {
				case 1:
					ingredientName = "Dough";
					break;
				case 2:
					ingredientName = "Tomato";
					break;
				case 3:
					ingredientName = "Cheese";
					break;
				case 4:
					ingredientName = "Salami";
					break;
				case 5:
					ingredientName = "Ham";
					break;
				case 6:
					ingredientName = "Mushroom";
					break;
				case 7:
					ingredientName = "Olive";
					break;
				case 8:
					ingredientName = "Chicken";
					break;
				}

				if (!_neededIngredients.ContainsKey(ingredientName))  {
                    int r = Random.Range(1, 6);
					_neededIngredients.Add(ingredientName, r);
                    //Debug.Log(ingredientName + ": " + r);
					foundIngredient = true;
				}
			}
		}


	}
	public override string ToString ()
	{
		string output = "Name: " + this.Name + " > ";
		foreach(KeyValuePair<string, int> entry in _neededIngredients)
		{
			output += entry.Key + " - " + entry.Value + "     ";
		}
		return output;
	}

//	public string GenPizzaName (){
//		string pizzaName = "";
//		switch (Random.Range(1,8)) {
//		case 1:
//			pizzaName = "Pizza le Kees";
//			break;
//		case 2:
//			pizzaName = "Pizza Train";
//			break;
//		case 3:
//			pizzaName = "Pizza Pikanto";
//			break;
//		case 4:
//			pizzaName = "Pizza with Stuff";
//			break;
//		case 5:
//			pizzaName = "The Pizza";
//			break;
//		case 6:
//			pizzaName = "Pizza Azzip";
//			break;
//		case 7:
//			pizzaName = "Pizza du Menno";
//			break;
//		case 8:
//			pizzaName = "Kevin's Special Pizza";
//			break;
//		}
//        return pizzaName;    
//	}
}
