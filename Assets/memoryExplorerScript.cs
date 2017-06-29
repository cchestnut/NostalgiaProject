using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class memoryExplorerScript : MonoBehaviour {
    //public 
    Object[] textures;
    int pointTotal;
    int maxSpeed;
    int timer;
    int collisionCount;
    double currentSpeed = 1;
    float spawnFreq = 150;
    Camera face;
    Rigidbody rb;
    GameObject tempCube;
    
    // Use this for initialization
	void Start ()
    {
        face = GetComponentInChildren<Camera>();
        rb = GetComponent<Rigidbody>();
        textures = Resources.LoadAll("pics");
    }
	
	// Update is called once per frame
	void Update () {
        timer++;
        if (timer >= spawnFreq && face)
        {
            spawnPic(face.transform.position + face.transform.forward*4);
            timer = 0;
        }
        if (collisionCount > 20)
        {

        }
        rb.velocity = (int)currentSpeed * face.transform.forward;
    }

    void spawnPic(Vector3 fwd) {

        //Instantiate((Texture2D)textures[0], new Vector3(fwd.x, fwd.y, fwd.z), rb.transform.rotation);
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Material cubeMat = new Material(Shader.Find("Standard"));
        cubeMat.mainTexture = (Texture2D)textures[(int)(Random.Range(0, textures.Length))];
        cube.GetComponent<Renderer>().material = cubeMat;
        cube.transform.position = new Vector3(fwd.x, fwd.y, fwd.z);
        cube.transform.Rotate(Vector3.up, 180);
        cube.transform.localScale = new Vector3(2f, 2f, 2f);
        currentSpeed += .2;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision");
    }
}
