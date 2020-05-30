using UnityEngine;
using System.Collections;

public class ShotBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += transform.forward * Time.deltaTime * 200f;
	
	}

    void CleanHit()
    {
        Destroy(gameObject);
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Obstacle")
    //    {
    //        collision.gameObject.SendMessage("CleanHit");
    //        Debug.Log("Hit!");
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Breakable")
        {
            other.gameObject.SendMessage("CleanHit");
        }
    }
}
