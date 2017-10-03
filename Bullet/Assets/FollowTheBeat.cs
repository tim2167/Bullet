//Tim Chang
using UnityEngine;
using System.Collections;

public class FollowTheBeat : MonoBehaviour {



	
	private const float beatPeriod = 1.485f;
    
	private float rotateCounter = 0.2f;

	
	private float shootCounter = -0.5f - beatPeriod*3;
	private TurretManagerScript turret;
    public void Reset()
    {
        shootCounter = -0.5f - beatPeriod * 3;
        rotateCounter = 0.2f;
    }

    // Use this for initialization
    void Start () {
		turret = this.GetComponent<TurretManagerScript> ();
	}
	// Update is called once per frame
	void Update () {

		rotateCounter += Time.deltaTime;
		shootCounter += Time.deltaTime;

		if (rotateCounter > beatPeriod) {
			turret.PlayRotateAnimation();
			rotateCounter -= beatPeriod;
		}
		if (shootCounter > beatPeriod) {
			turret.PlayShootAnimation();
			shootCounter -= beatPeriod;
		}
	}
}
