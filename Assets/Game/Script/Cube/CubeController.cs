using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class CubeController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public bool checkTouch=false;
    public bool checkWin = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            checkTouch=true;
        }
    }
    private void FixedUpdate()
    {
        moveCube();
    }
    public void moveCube()
    {
        rb.AddForce(Vector3.forward * speed);
        float h = Input.GetAxis("Horizontal");
        if (checkTouch)
        {
            GameEvent.Instance.txtPlay.transform.DOScale(0, 1f);
            rb.isKinematic = false;
            speed = 10;
            float halfScreen = Screen.width / 2;
            float xPos = (Input.mousePosition.x - halfScreen) / halfScreen;
            //if (Input.GetKey("d") || xPos>0)
            //{
            //    rb.AddForce(Vector3.right * speed);
            //}
            //if (Input.GetKey("a") || xPos<0)
            //{
            //    rb.AddForce(Vector3.left * speed);
            //}
            if (Input.GetMouseButton(0))
            {
                GameEvent.Instance.Player.localPosition = new Vector3(xPos * 5f, transform.position.y, transform.position.z);
            }
        }
        GameEvent.Instance.Point();
    }
    public IEnumerator EndGame()
    {
        yield return new WaitForSeconds(1f);
        //Debug.Log("Hit Trap");
        checkTouch=false;
        checkWin = false;
        speed = 0;
        rb.isKinematic = true;
        GameEvent.Instance.showLosePanel();
    }
  
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            StartCoroutine(EndGame());
        }
        if (collision.gameObject.tag == "Finish")
        {
            GameEvent.Instance.showWinPanel();
            checkTouch = false;
            checkWin = true;
            rb.isKinematic = true;
            speed = 0;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Trap")
        {
            StartCoroutine(EndGame());
        }
    }
}
