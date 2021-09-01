using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody rb;
    public Joystick joystick; //используемый джостик

    Vector3 myposition;

    private float zMovement; //направление по оси Z
    private float xMovement;//направление по оси X
    bool followPath = false;//перемещается ли по тапу?

    public float speed = 3.0f;//скорость перемещения
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
        if (Input.GetMouseButton(0))//если тап
        {
            Ray touchRayToPosition = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
            RaycastHit hit;
            if (Physics.Raycast(touchRayToPosition, out hit))//стреляем лучом
            {
                myposition = new Vector3(hit.point.x, transform.position.y, hit.point.z);//позиция для передвижения получается из точки попадания луча в коллайдер
                followPath = true;
            }

        }
        if (myposition == transform.position) followPath = false;//если прибыли в точку, то прекратить следовать пути
        if (joystick.Direction != Vector2.zero)//если есть инпут с джойстика
        {
            followPath = false; //прекратить следовать пути
            xMovement = joystick.Horizontal; //направление по оси x соответствует оси x джойстика
            zMovement = joystick.Vertical; //направление по оси z соответствует оси y джойстика

            rb.AddRelativeForce(new Vector3(xMovement, 0, zMovement) * speed);//прикладываем силу в указанном направдении
        }
    }

    private void FixedUpdate()
    {
        rb.AddRelativeForce(new Vector3(xMovement, 0, zMovement) * speed);//прикладываем силу в указанном направдении
        if (followPath)//если следуем пути
        {
            transform.position = Vector3.Lerp(transform.position, myposition, Time.deltaTime);//новая позиция из линейной интерполяции между текущей позицией и конечной
        }
    }
}
