using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    //public List<Texture> pizza;
    //public List<Texture> restaurant;
    public GameObject go; //your plane
    public PlayerScore ps;
    private string currentImg;
    

                          
    void Start ()
    {
        //ApplyTextureRestaurant();
    }
	
	// Update is called once per frame
	void Update () {
	
	}


//    public void ApplyTexturePizza()
//    {
//        GetComponent<Renderer>().material.mainTexture = pizza[Random.Range(0, pizza.Count)];
//        if (GetComponent<Renderer>().material.mainTexture.name.Contains("Calzone"))
//        {
//            
//            StartCoroutine(OMGCalzone(20f));
//        }
//        else if (GetComponent<Renderer>().material.mainTexture.name.Contains("Pizza"))
//        {
//            StartCoroutine(NooPizza(20f));
//        }
//        currentImg = GetComponent<Renderer>().material.mainTexture.name;
//    }

//    public void ApplyTextureRestaurant()
//    {
//        
//        GetComponent<Renderer>().material.mainTexture = restaurant[Random.Range(0, restaurant.Count)];
//        currentImg = GetComponent<Renderer>().material.mainTexture.name;
//        StartCoroutine(WaitforPizza(Random.Range(1, 40)));
//
//    }


//    public void OnPizzaClick()
//    {
//
//        if (GetComponent<Renderer>().material.mainTexture.name.Contains("Pizza"))
//        {
//            Debug.Log("No i want a Calzone!");
//            ApplyTextureRestaurant();
//        }
//
//        else if (GetComponent<Renderer>().material.mainTexture.name.Contains("Calzone"))
//        {
//            Debug.Log("No! Give my Calzone back!");
//            ApplyTextureRestaurant();
//        }
//        else
//        {
//            Debug.Log("Nice, place to eat");
//        }
//
//    }
//
//    IEnumerator WaitforPizza(float waitTime)
//    {
//        Debug.Log("Waiting for" + waitTime);
//        yield return new WaitForSeconds(waitTime);
//        ApplyTexturePizza();
//    }


//    IEnumerator OMGCalzone(float waitTime)
//    {
//        yield return new WaitForSeconds(waitTime);
//        if (currentImg == GetComponent<Renderer>().material.mainTexture.name)
//        {
//            ps.UpdateScore(5);
//            ApplyTexturePizza();
//        }
//        
//    }
//
//    IEnumerator NooPizza(float waitTime)
//    {
//        yield return new WaitForSeconds(waitTime);
//        if (currentImg == GetComponent<Renderer>().material.mainTexture.name)
//        {
//            ps.UpdateScore(-1);
//            ApplyTexturePizza();
//        }
//        
//    }


}
