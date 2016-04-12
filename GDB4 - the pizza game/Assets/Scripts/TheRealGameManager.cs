using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine.UI;
//using System.Net.Mail;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

public class TheRealGameManager : MonoBehaviour {

    private Pizza currentPizza;
    int score;
    private Dictionary<string, int> _currentIngredients = new Dictionary<string, int>();
    public PlayerScore playerScore;

	public List<string> PizzaNamePasts;
	public List<Pizza> pizzaList;
	public TextMesh currentPizzaText;
	public TextMesh ConnectedText;
	public TextMesh TimeText;
	public bool isInternet = false;
	public float timerTime;
	string PizzaMenuLocation = "PizzaMenu.txt";


	// Use this for initialization
	void Start () {	
		pizzaList = new List<Pizza> ();
		for (int i = 0; i < 30; i++) {
			bool AlreadyExist = true;
			string pizzaName = "";
			while (AlreadyExist == true) {
				pizzaName = GenRandomPizzaName ();
				AlreadyExist = checkIfNameExist (pizzaName);
			}
			pizzaList.Add (new Pizza(pizzaName));
		}

        resetCurrentIngridients();

        SendEmailMobile();

        //if (Application.platform == RuntimePlatform.Android) {
        //	SendEmailMobile ();
        //}
        //else {
        //	SendEmailDesktop ();
        //		PizzaListToTxt (pizzaList);
        //}	
        currentPizzaText.text = "Game Not Started Yet!";
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.F)) {
			newPizza ();
		}

	}

    public void OnPizzaClick(GameObject clickedPane)
    {
        Debug.Log(clickedPane.name);
        int aantal = 1;
        if (clickedPane.GetComponent<Renderer>().material.mainTexture.name.Contains("doughPizza"))
        {
            aantal = _currentIngredients["dough"] + 1;
            _currentIngredients.Remove("dough");
            _currentIngredients.Add("dough", aantal);
            Debug.Log("Dough: " + _currentIngredients["dough"]);
        }
        else if (clickedPane.GetComponent<Renderer>().material.mainTexture.name.Contains("tomatoPizza"))
        {
            aantal = _currentIngredients["tomato"] + 1;
            _currentIngredients.Remove("tomato");
            _currentIngredients.Add("tomato", aantal);
            Debug.Log("Tomato: " + _currentIngredients["tomato"]);
        }
        else if (clickedPane.GetComponent<Renderer>().material.mainTexture.name.Contains("kaasPizza"))
        {
            aantal = _currentIngredients["cheese"] + 1;
            _currentIngredients.Remove("cheese");
            _currentIngredients.Add("cheese", aantal);
            Debug.Log("Cheese: " + _currentIngredients["cheese"]);
        }
        else if (clickedPane.GetComponent<Renderer>().material.mainTexture.name.Contains("pepperoniPizza"))
        {
            aantal = _currentIngredients["pepperoni"] + 1;
            _currentIngredients.Remove("pepperoni");
            _currentIngredients.Add("pepperoni", aantal);
            Debug.Log("Pepperoni: " + _currentIngredients["pepperoni"]);
        }
        else if (clickedPane.GetComponent<Renderer>().material.mainTexture.name.Contains("hamPizza"))
        {
            aantal = _currentIngredients["ham"] + 1;
            _currentIngredients.Remove("ham");
            _currentIngredients.Add("ham", aantal);
            Debug.Log("Ham: " + _currentIngredients["ham"]);
        }
        else if (clickedPane.GetComponent<Renderer>().material.mainTexture.name.Contains("champignonPizza"))
        {
            aantal = _currentIngredients["champignon"] + 1;
            _currentIngredients.Remove("champignon");
            _currentIngredients.Add("champignon", aantal);
            Debug.Log("Champignon: " + _currentIngredients["champignon"]);
        }
        else if (clickedPane.GetComponent<Renderer>().material.mainTexture.name.Contains("olivesPizza"))
        {
            aantal = _currentIngredients["olive"] + 1;
            _currentIngredients.Remove("olive");
            _currentIngredients.Add("olive", aantal);
            Debug.Log("Olive: " + _currentIngredients["olive"]);
        }
        else if (clickedPane.GetComponent<Renderer>().material.mainTexture.name.Contains("rawchickenPizza"))
        {
            aantal = _currentIngredients["chicken"] + 1;
            _currentIngredients.Remove("chicken");
            _currentIngredients.Add("chicken", aantal);
            Debug.Log("Chicken: " + _currentIngredients["chicken"]);
        }
    }

    public void resetCurrentIngridients()
    {
        _currentIngredients.Remove("dough");
        _currentIngredients.Add("dough", 0);
        _currentIngredients.Remove("tomato");
        _currentIngredients.Add("tomato", 0);
        _currentIngredients.Remove("cheese");
        _currentIngredients.Add("cheese", 0);
        _currentIngredients.Remove("pepperoni");
        _currentIngredients.Add("pepperoni", 0);
        _currentIngredients.Remove("ham");
        _currentIngredients.Add("ham", 0);
        _currentIngredients.Remove("champignon");
        _currentIngredients.Add("champignon", 0);
        _currentIngredients.Remove("olive");
        _currentIngredients.Add("olive", 0);
        _currentIngredients.Remove("chicken");
        _currentIngredients.Add("chicken", 0);
    }

    public void servePizza()
    {
        Debug.Log("KaasBroodje 1" + currentPizza._neededIngredients["Dough"]);
        Debug.Log("KaasBroodje 1" + _currentIngredients["dough"]);
        int difference = (currentPizza._neededIngredients["Dough"] - _currentIngredients["dough"]);
        Debug.Log("KaasBroodje 2");
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
		newPizza ();
        resetCurrentIngridients();
        //currentPizza = new Pizza();
    }

	public void newPizza(){
		currentPizza = pizzaList [UnityEngine.Random.Range (0, pizzaList.Count)];
		currentPizzaText.text = "Test?";
		currentPizzaText.text = currentPizza.Name;
	}

	public string GenRandomPizzaName(){
		string output = "";
		for (int i = 0; i < UnityEngine.Random.Range(1,3); i++) {
			output += PizzaNamePasts [UnityEngine.Random.Range (0, PizzaNamePasts.Count)] + " ";
		}

		if (UnityEngine.Random.value < 0.5f) {
			return "Pizza " + output;
		}
		else {
			return output + "Pizza";
		}
	}

	/*public void PizzaListToTxt(List<Pizza> pizzaList){


		if (!File.Exists (PizzaMenuLocation)) {
			StreamWriter sr = File.CreateText (PizzaMenuLocation);
			sr.Close ();
		} else {
			using (StreamWriter sr = new StreamWriter(PizzaMenuLocation, false))
			{
				sr.WriteLine (" ");
			}
		}

		foreach (Pizza item in pizzaList) {
			WriteMenu(item.ToString());
		}
	}*/

	public bool checkIfNameExist(string name){
		foreach (Pizza item in pizzaList) {
			if (item.Name == name)
				return true;
		}

		return false;
	}

	public bool WriteMenu(string pizza){
		bool result = false;
		using (StreamWriter sr = new StreamWriter(PizzaMenuLocation, true))
		{
			sr.WriteLine ("Pizza {0}", pizza);
			sr.WriteLine (" ");
			result = true;
		}
		return result;
	}

	/*public void SendEmailDesktop(){
		currentPizzaText.text = "sendMail()";
		MailMessage mail = new MailMessage();

		mail.From = new MailAddress("kevintestmail123@gmail.com");
		mail.To.Add("kevintestmail123@gmail.com");
		mail.Subject = "Pizza Menu";

		string output = "";
		foreach (Pizza item in pizzaList) {
			output += item.ToString ();
			output += System.Environment.NewLine;
		}
		
		mail.Body = output;
		SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
		smtpServer.Port = 587;
		smtpServer.Credentials = new System.Net.NetworkCredential("kevintestmail123@gmail.com", "KevinsTestAccount") as ICredentialsByHost;
		smtpServer.EnableSsl = true;
		ServicePointManager.ServerCertificateValidationCallback = 
			delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) 
		{ return true; };
		smtpServer.Send(mail);
	}*/

	public void SendEmailMobile ()
	{
		string output = "";
		foreach (Pizza item in pizzaList) {
			output += item.ToString ();
			output += System.Environment.NewLine;
		}

		string email = "kevintestmail123@gmail.com";
		string subject = MyEscapeURL("Pizza Menu");
		string body = MyEscapeURL(output);
		Application.OpenURL("mailto:" + email + "?subject=" + subject + "&body=" + body);
	}

	string MyEscapeURL (string url)
	{
		return WWW.EscapeURL(url).Replace("+","%20");
	}
		
	public void StartGame(){

		timerTime -= Time.deltaTime;
		score = 0;
		newPizza ();
		StartCoroutine (StartTimer (timerTime));
	}

	void GameOver(){
		currentPizzaText.text = "GameOver! Score: " + score;
		score = 0;
		//Game over Reset all varibales
	}
	IEnumerator StartTimer(float time){
		time -= Time.deltaTime;
		TimeText.text = "Time Left:" + Mathf.Round(time);
		if(time < 0)
		{
			GameOver ();
		}

		yield return null;

	}

}
