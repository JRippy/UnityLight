using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clignot : MonoBehaviour {

		float waitingTime=0.05f; //20 times a second
        float normalRange =3.0f; //normal range of light
        float flRange =0.5f; //flickering range
        YieldInstruction yield;
        public GameObject light1;
        public Light lightc;

    // Use this for initialization
    void Start () {

        light1 = GameObject.Find("Point_Light");
        //lightc = light1.AddComponent<Light>();
        StartCoroutine(waiter());
        }
	
	
	// Update is called once per frame
	void Update () {

	}

    IEnumerator waiter()
    {
        // Make a game object
        GameObject lightGameObject = new GameObject("The Light");

        // Add the light component
        Light lightComp = lightGameObject.AddComponent<Light>();

        // Set color and position
        lightComp.color = Color.blue;

        lightComp.intensity = 10.0f;

        // Set the position (or any transform property)
        lightGameObject.transform.position = new Vector3(1.0f, 1.0f, -0.5f);

        while (true)
        {
            if (lightComp.range == normalRange)
                lightComp.range = flRange;
            else lightComp.range = normalRange;

            lightc.enabled = !(lightc.enabled);

            yield return new WaitForSeconds(waitingTime);

            lightc.color = Color.white;

            Debug.Log("Result Light : " + lightc);
            Debug.Log("Result Light boolean: " + lightc.enabled);

            yield return new WaitForSeconds(waitingTime);
        }
    }
}
