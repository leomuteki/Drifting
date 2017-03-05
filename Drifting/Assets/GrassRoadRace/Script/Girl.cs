using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girl : MonoBehaviour {

    public float direction = 1f;
	
	// Update is called once per frame
	void Update () {
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        float moveAmount = Time.smoothDeltaTime * 1 * direction;
        transform.Translate(moveAmount, 0f, 0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "GameController") {
            direction *= -1f;
        }
    }
}
