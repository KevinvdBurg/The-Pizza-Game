using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TheRealGameManager : MonoBehaviour {

    private Pizza currentPizza;
    int score;
    private Dictionary<string, int> _currentIngredients = new Dictionary<string, int>();
    public PlayerScore playerScore;

	// Use this for initialization
	void Start () {
        currentPizza = new Pizza();
        score = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnPizzaClick(GameObject clickedPane)
    {
        Debug.Log(clickedPane.name);
        int aantal = 1;
        if (clickedPane.GetComponent<Renderer>().material.mainTexture.name.Contains("doughPizza"))
        {
            if (_currentIngredients.ContainsKey("dough"))
            {
                aantal = _currentIngredients["dough"] + 1;
                _currentIngredients.Remove("dough");
            }
            _currentIngredients.Add("dough", aantal);
            Debug.Log("Dough: " + _currentIngredients["dough"]);
        }
        else if (clickedPane.GetComponent<Renderer>().material.mainTexture.name.Contains("tomatoPizza"))
        {
            if (_currentIngredients.ContainsKey("tomato"))
            {
                aantal = _currentIngredients["tomato"] + 1;
                _currentIngredients.Remove("tomato");
            }
            _currentIngredients.Add("tomato", aantal);
            Debug.Log("Tomato: " + _currentIngredients["tomato"]);
        }
        else if (clickedPane.GetComponent<Renderer>().material.mainTexture.name.Contains("kaasPizza"))
        {
            if (_currentIngredients.ContainsKey("cheese"))
            {
                aantal = _currentIngredients["cheese"] + 1;
                _currentIngredients.Remove("cheese");
            }
            _currentIngredients.Add("cheese", aantal);
            Debug.Log("Cheese: " + _currentIngredients["cheese"]);
        }
        else if (clickedPane.GetComponent<Renderer>().material.mainTexture.name.Contains("pepperoniPizza"))
        {
            if (_currentIngredients.ContainsKey("pepperoni"))
            {
                aantal = _currentIngredients["pepperoni"] + 1;
                _currentIngredients.Remove("pepperoni");
            }
            _currentIngredients.Add("pepperoni", aantal);
            Debug.Log("Pepperoni: " + _currentIngredients["pepperoni"]);
        }
        else if (clickedPane.GetComponent<Renderer>().material.mainTexture.name.Contains("hamPizza"))
        {
            if (_currentIngredients.ContainsKey("ham"))
            {
                aantal = _currentIngredients["ham"] + 1;
                _currentIngredients.Remove("ham");
            }
            _currentIngredients.Add("ham", aantal);
            Debug.Log("Ham: " + _currentIngredients["ham"]);
        }
        else if (clickedPane.GetComponent<Renderer>().material.mainTexture.name.Contains("champignonPizza"))
        {
            if (_currentIngredients.ContainsKey("champignon"))
            {
                aantal = _currentIngredients["champignon"] + 1;
                _currentIngredients.Remove("champignon");
            }
            _currentIngredients.Add("champignon", aantal);
            Debug.Log("Champignon: " + _currentIngredients["champignon"]);
        }
        else if (clickedPane.GetComponent<Renderer>().material.mainTexture.name.Contains("olivesPizza"))
        {
            if (_currentIngredients.ContainsKey("olive"))
            {
                aantal = _currentIngredients["olive"] + 1;
                _currentIngredients.Remove("olive");
            }
            _currentIngredients.Add("olive", aantal);
            Debug.Log("Olive: " + _currentIngredients["olive"]);
        }
        else if (clickedPane.GetComponent<Renderer>().material.mainTexture.name.Contains("rawchickenPizza"))
        {
            if (_currentIngredients.ContainsKey("chicken"))
            {
                aantal = _currentIngredients["chicken"] + 1;
                _currentIngredients.Remove("chicken");
            }
            _currentIngredients.Add("chicken", aantal);
            Debug.Log("Chicken: " + _currentIngredients["chicken"]);
        }
    }

    public void servePizza()
    {
        int difference = (currentPizza._neededIngredients["Dough"] - _currentIngredients["dough"]);
        if (difference < 0) { difference *= -1; }
        score += _currentIngredients["dough"] -= difference * 2;
        difference = (currentPizza._neededIngredients["Tomato"] - _currentIngredients["tomato"]);
        if (difference < 0) { difference *= -1; }
        score += _currentIngredients["tomato"] -= difference * 2;
        difference = (currentPizza._neededIngredients["Cheese"] - _currentIngredients["cheese"]);
        if (difference < 0) { difference *= -1; }
        score += _currentIngredients["cheese"] -= difference * 2;
        difference = (currentPizza._neededIngredients["Salami"] - _currentIngredients["pepperoni"]);
        if (difference < 0) { difference *= -1; }
        score += _currentIngredients["pepperoni"] -= difference * 2;
        difference = (currentPizza._neededIngredients["Ham"] - _currentIngredients["ham"]);
        if (difference < 0) { difference *= -1; }
        score += _currentIngredients["ham"] -= difference * 2;
        difference = (currentPizza._neededIngredients["Mushroom"] - _currentIngredients["champignon"]);
        if (difference < 0) { difference *= -1; }
        score += _currentIngredients["champignon"] -= difference * 2;
        difference = (currentPizza._neededIngredients["Olive"] - _currentIngredients["olive"]);
        if (difference < 0) { difference *= -1; }
        score += _currentIngredients["olive"] -= difference * 2;
        difference = (currentPizza._neededIngredients["Chicken"] - _currentIngredients["chicken"]);
        if (difference < 0) { difference *= -1; }
        score += _currentIngredients["chicken"] -= difference * 2;

        playerScore.UpdateScore(score);
        currentPizza = new Pizza();
    }
}
