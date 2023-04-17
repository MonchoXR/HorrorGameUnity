using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public  class PlayerFPS : MonoBehaviour

{

    //Player Movement

    public float velocidadMovimiento = 3f;

    // public Rigidbody rb;

    //Player Look Rotation

    public Vector2 sensibilidadMouse;
    public Transform Camera;


    public  Vector3 posInicial;
    private Vector3 rotate;
    public List<Granada> _inventarioGranada = new List<Granada>();
    public List<Battery> _inventarioBattery = new List<Battery>();
    public Granada myGranada;
    public Battery myBattery;
    public int totalGranada=0;
    public int totalBattery=0;
    public static bool isEnableClamFlash =false;
    public GameObject HudCameraTutoria;
    public GameObject HudFullBatteriesTutorial;
    public GameObject HudObjectiveCamera;
    public GameObject HudObjectiveClowns;

     public GameObject HudObjectiveCameraCompleted;

    
    
    // public int vidaPlayer = 100;
    public static int vidaJugador = 100;
    
  
    void Start()

    {
       posInicial = transform.position;
        BloqueoCusor();

    }

    void Respawn()
    {
        transform.position = posInicial;
    }

    void Update()

    {   
        if(transform.position.y <= -15.0f)
        {
            Respawn();
        }
        Move();

        MouseLook();
        if(isEnableClamFlash)
        {
            HudCameraTutoria.SetActive(false);
        }


    
  
        
    }

    void Move()

    {

        float hor = Input.GetAxis("Horizontal");

        float ver = Input.GetAxis("Vertical");

        Vector3 inputPlayer = new Vector3(hor, 0, ver);

        transform.Translate(new Vector3(hor, 0, ver) * velocidadMovimiento * Time.deltaTime);

        // rb.AddForce(inputPlayer * velocidadMovimiento * Time.deltaTime);

    
    }

void MouseLook()

    {

     float hor = Input.GetAxis("Mouse X");
     float ver = Input.GetAxis("Mouse Y");
     transform.Rotate(Vector3.up*hor* sensibilidadMouse.x);
    //   Camera.Rotate(Vector3.left*ver*sensibilidadMouse.y);
    float angle = (Camera.localEulerAngles.x - ver*sensibilidadMouse.y+360)%360; // aqui se encarga que el angulo este entre 0 y 360
    if(angle>180) {angle -=360;} // hacemos que el angulo este entre -180 a 180
    angle= Mathf.Clamp(angle,-80,80);
    Camera.localEulerAngles = Vector3.right*angle;

    }




public void BloqueoCusor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

 public void OnCollisionEnter(Collision collision)
 {

        if (collision.gameObject.tag == "Grenade")
        {
            _inventarioGranada.Add(myGranada);
            Destroy(collision.gameObject);
            totalGranada++;
        }

        if (collision.gameObject.tag == "Battery")
        {
            if (isEnableClamFlash && totalBattery <= 5)
            {
                totalBattery++;
 
                    HudFullBatteriesTutorial.SetActive(false);
                    _inventarioBattery.Add(myBattery);
                    Destroy(collision.gameObject);
               }
             
         

        }
    }

    public void OnTriggerStay(Collider collision)
	{
          if (collision.gameObject.tag == "Camera")
        {
            HudCameraTutoria.SetActive(true);
             if(Input.GetKey (KeyCode.E))
             {
                isEnableClamFlash = true;
                HudObjectiveCamera.SetActive(false);
                HudObjectiveCameraCompleted.SetActive(true);
                StartCoroutine(Objective());
                
                Destroy(collision.gameObject);
             }
        

        }
       
    }


    	IEnumerator Objective()
	{	
	
			yield return new WaitForSeconds(2.0f);
            HudObjectiveCameraCompleted.SetActive(false);
		    HudObjectiveClowns.SetActive(true);
				
	}


}



