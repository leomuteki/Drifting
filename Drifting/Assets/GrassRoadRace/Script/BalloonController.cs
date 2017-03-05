using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalloonController : MonoBehaviour {

    public GameObject Title;
    public GameObject Win;
    public Slider myslider;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject heart4;
    public GameObject heart5;
    public int life = 5;

    public float MoveSpeed = -10;
    private float LastSpeed;
    public float JumpPower = 1f;
    //public float Force = 1f;
    public GameObject Camera;
    public bool SideView = false;
    public Vector3 Pos0;
    public float Rotx;
    public float Roty;
    public float Rotz;
    public Vector3 Scale0;

    private void Start()
    {
        Win.SetActive(false);
        transform.localPosition = new Vector3 ( 0, 2, 27 );
        //transform.localPosition = new Vector3(0, 2, -185);
        Pos0 = transform.position;
        Rotx = transform.localRotation.x;
        Rotx = transform.localRotation.y;
        Rotx = transform.localRotation.z;
        Scale0 = transform.localScale;
        StartCoroutine(Show());
       
    }

    IEnumerator Show()
    {
        yield return new WaitForSeconds(3f);
        Title.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Respawn") {
           transform.localPosition = new Vector3(0, 2, 27);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Spike" && life > 0) {
            life--;
            LastSpeed = MoveSpeed;
            MoveSpeed = 5f;
            MoveObj();
            StartCoroutine(Slow());
        }
        if (collision.gameObject.tag == "Finish" && life > 0) {
            Win.SetActive(true);
        }
    }

    private IEnumerator Slow()
    {
        yield return new WaitForSeconds(0.5f);
        MoveSpeed = LastSpeed;
    }

    void MoveObj()
    {
        float moveAmount = Time.smoothDeltaTime * MoveSpeed * -1;
        transform.Translate(0f, moveAmount, 0f);
        //GetComponent<Rigidbody>().AddForce(new Vector3(0f, 0f, Force));
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (life >= 1)
            heart1.SetActive(true);
        else
            heart1.SetActive(false);
        if (life >= 2)
            heart2.SetActive(true);
        else
            heart2.SetActive(false);
        if (life >= 3)
            heart3.SetActive(true);
        else
            heart3.SetActive(false);
        if (life >= 4)
            heart4.SetActive(true);
        else
            heart4.SetActive(false);
        if (life >= 5)
            heart5.SetActive(true);
        else
            heart5.SetActive(false);

        if (life > 0) {
            transform.localRotation = Quaternion.Euler(-90, 0, 0);

            float moveAmount;

            //move object forward
            MoveObj();

            //jump
            if (Input.GetKey(KeyCode.Space)) {

                moveAmount = Time.smoothDeltaTime * MoveSpeed * -1;
                transform.Translate(0f, 0f, JumpPower * moveAmount);
            }

            if (Input.GetKey(KeyCode.R)) {
                transform.position = Pos0;
                transform.localRotation = Quaternion.Euler(Rotx, Roty, Rotz);
            }
            if (Input.GetKey(KeyCode.A)) {
                moveAmount = Time.smoothDeltaTime * MoveSpeed * -1;
                transform.Translate(moveAmount, 0f, 0f);
            }
            if (Input.GetKey(KeyCode.D)) {
                moveAmount = Time.smoothDeltaTime * MoveSpeed * -1;
                transform.Translate(-1 * moveAmount, 0f, 0f);
            }

            if (SideView && Input.GetKeyDown(KeyCode.Tab)) {
                ChangeView01();
            }

            if (!SideView && Input.GetKeyDown(KeyCode.Tab)) {
                ChangeView02();
            }
        }
    }

    void ChangeView01()
    {
        SideView = false;
        transform.position = new Vector3(0, 2, 10);
        // x:0, y:1, z:52
        Camera.transform.localPosition = new Vector3(-8, 2, 0);
        Camera.transform.localRotation = Quaternion.Euler(14, 90, 0);
    }

    void ChangeView02()
    {
        SideView = true;
        transform.position = new Vector3(0, 2, 10);
        // x:0, y:1, z:52
        Camera.transform.localPosition = new Vector3(0, 0, 0);
        Camera.transform.localRotation = Quaternion.Euler(19, 180, 0);
        MoveSpeed = -20f;

    }
}
