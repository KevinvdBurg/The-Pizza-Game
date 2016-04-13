using UnityEngine;
using System.Collections;

public class PlayerScore : MonoBehaviour
{


    public int score = 0;
    public GameObject scoreText;
    public PlayerScore instance;

	// Use this for initialization
	void Start ()
	{
	    instance = this;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void UpdateScore(int uScore)
    {
        scoreText.transform.localScale = new Vector3(0.1f,0.1f,0.1f);
        score += uScore;
        scoreText.GetComponent<TextMesh>().text = score + "";
        StartCoroutine(HideScore());


    }

    public IEnumerator HideScore()
    {
        yield return new WaitForSeconds(4f);
        scoreText.transform.localScale = new Vector3(0f, 0f, 0f);
    }
}
