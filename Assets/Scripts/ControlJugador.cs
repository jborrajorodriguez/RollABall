using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ControlJugador : MonoBehaviour {
    public float speed;
	private Rigidbody rb;
    private int cuenta;
    public Text marcador;
    public Text victoria;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
        cuenta = 0;
        marcador.text = "marcador : " + cuenta.ToString();
        victoria.text = "";

	}	
		
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal,0.0f,moveVertical);
		rb.AddForce (movement * speed);


	}
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickups"))
        {
            other.gameObject.SetActive(false);
            cuenta = cuenta + 1;
            marcador.text = "marcador : " + cuenta.ToString();
        }
        if (cuenta > 11)
        {
            victoria.text = "GANASTE";
        }


    }
    void SetCountText()
    {
        marcador.text = "marcador : " + cuenta.ToString();
       

    }
}
