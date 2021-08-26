using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody rb;
    private Joystick joystick;

    Vector3 myposition;

    private float zMovement;
    private float xMovement;
    bool followPath = false;

    public float speed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        joystick = FindObjectOfType<Joystick>();
    }

    //Update is called once per frame
    void Update()
    {
        
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Ray touchRayToPosition = Camera.main.ScreenPointToRay(new Vector3(touch.position.x, touch.position.y));
            RaycastHit hit;
            if (Physics.Raycast(touchRayToPosition, out hit))
            {
                myposition = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                followPath = true;
            }

        }
        if (myposition == transform.position) followPath = false;
        if (joystick.Direction != Vector2.zero)
        {
            followPath = false; 
            xMovement = joystick.Horizontal;
            zMovement = joystick.Vertical;

            rb.AddRelativeForce(new Vector3(xMovement, 0, zMovement) * speed);
        }
    }

    private void FixedUpdate()
    {
        if (followPath)
        {
            transform.position = Vector3.Lerp(transform.position, myposition, Time.deltaTime);
        }
    }
}
