using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerFPS : MonoBehaviour

{

    //Player Movement

    public float velocidadMovimiento = 3f;

    // public Rigidbody rb;

    //Player Look Rotation

    public Vector2 sensibilidadMouse;
    public Transform Camera;
    public Transform playerBody;

    private Vector3 rotate;
    public List<Granada> _inventarioGranada = new List<Granada>();
    public Granada myGranada;
    public int totalGranada=0;
    void Start()

    {
    BloqueoCusor();
    }

    void Update()

    {

        Move();

        MouseLook();
        

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

 private void OnCollisionEnter(Collision collision)
 {

    if(collision.gameObject.tag ==  "Grenade")
    {
         _inventarioGranada.Add(myGranada);
         Destroy(collision.gameObject);
         totalGranada ++;
    }
  
 }
}



