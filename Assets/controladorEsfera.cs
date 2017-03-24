using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controladorEsfera : MonoBehaviour {

public float speed;

private int count;
public Text  text;
public Text  winText;

void Start()
{
	
	count = 0;
	updateCounter();
	winText.text = "";
}

	// Update is called once per frame
	void FixedUpdate () {
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		Vector3 direction = new Vector3(horizontal,0,vertical);

		GetComponent<Rigidbody>().AddForce(direction * speed);

	}
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "pickup")
		{
			Destroy(other.gameObject);
			count++;

			updateCounter();

		}
	}
	void updateCounter()
	{
		text.text = "puntos : " + count;
		int numPickup  = GameObject.FindGameObjectsWithTag("pickup").Length;
		if(numPickup == 1)
		{
			winText.text = "Has Ganado";
		}
	}
}
