//Tim Chang 
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour { //keeps track of the game score.

	private int _score = 0;
	private Text _uiText;

	public void AddScore(int score)
	{
		_score += score;
		_uiText.text = _score.ToString();
	}
    public void Reset()
    {
        _score = 0;
        _uiText.text = _score.ToString();
    }
    // Use this for initialization
    void Start () {

		_uiText = this.GetComponent<Text> ();
	
	}

}
