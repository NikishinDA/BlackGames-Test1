using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody rb;
    public Joystick joystick; //������������ �������

    Vector3 myposition;

    private float zMovement; //����������� �� ��� Z
    private float xMovement;//����������� �� ��� X
    bool followPath = false;//������������ �� �� ����?

    public float speed = 3.0f;//�������� �����������
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
        if (Input.GetMouseButton(0))//���� ���
        {
            Ray touchRayToPosition = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
            RaycastHit hit;
            if (Physics.Raycast(touchRayToPosition, out hit))//�������� �����
            {
                myposition = new Vector3(hit.point.x, transform.position.y, hit.point.z);//������� ��� ������������ ���������� �� ����� ��������� ���� � ���������
                followPath = true;
            }

        }
        if (myposition == transform.position) followPath = false;//���� ������� � �����, �� ���������� ��������� ����
        if (joystick.Direction != Vector2.zero)//���� ���� ����� � ���������
        {
            followPath = false; //���������� ��������� ����
            xMovement = joystick.Horizontal; //����������� �� ��� x ������������� ��� x ���������
            zMovement = joystick.Vertical; //����������� �� ��� z ������������� ��� y ���������

            rb.AddRelativeForce(new Vector3(xMovement, 0, zMovement) * speed);//������������ ���� � ��������� �����������
        }
    }

    private void FixedUpdate()
    {
        rb.AddRelativeForce(new Vector3(xMovement, 0, zMovement) * speed);//������������ ���� � ��������� �����������
        if (followPath)//���� ������� ����
        {
            transform.position = Vector3.Lerp(transform.position, myposition, Time.deltaTime);//����� ������� �� �������� ������������ ����� ������� �������� � ��������
        }
    }
}
