using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlopeScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)//если объект входит в триггер, 
    {
        other.transform.up = gameObject.transform.up; //поменять направление нормали объекта на направиление нормали рампы
    }
    private void OnTriggerExit(Collider other)//если объект выходит из триггера, 
    {
        other.transform.up = Vector3.up;//вернуть направление нормали
    }
}
