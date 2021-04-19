using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CARRIL { Izq, Cen, Der }

public class kartController : MonoBehaviour
{
    public CARRIL m_Carril = CARRIL.Cen;
    public bool movDer, movIzq;
    public float XVal;
    public float velMov = 1f;
    private CharacterController m_char;
    public Transform[] centrosPistaIzq;
    public Transform[] centrosPistaCen;
    public Transform[] centrosPistaDer;
    private Transform[] centrosActual;
    [Range(0,1)]
    public float valorMov;

    void Start()
    {
        m_char = GetComponent<CharacterController>();
        centrosActual = centrosPistaCen;
    }


    void Update()
    {
        movIzq = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
        movDer = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);
        if (valorMov < 1)
        {
            valorMov += ((Time.deltaTime / 20) * velMov);
        }
        
        iTween.PutOnPath(this.gameObject, centrosActual, valorMov);
        this.transform.LookAt(iTween.PointOnPath(centrosActual, valorMov));


        if (movIzq)
        {
            if (m_Carril == CARRIL.Cen)
            {
                centrosActual = centrosPistaIzq;
                m_Carril = CARRIL.Izq;
            }
            else if (m_Carril == CARRIL.Der)
            {
                centrosActual = centrosPistaCen;
                m_Carril = CARRIL.Cen;
            }
        }
        if (movDer)
        {
            if (m_Carril == CARRIL.Cen)
            {
                centrosActual = centrosPistaDer;
                m_Carril = CARRIL.Der;
            }
            else if (m_Carril == CARRIL.Izq)
            {
                centrosActual = centrosPistaCen;
                m_Carril = CARRIL.Cen;
            }
        }
        
        
        RaycastHit hit;
        Vector3 frente = transform.TransformDirection(Vector3.forward);
        bool col = Physics.Raycast(new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z), frente, out hit, 15f, 8);
        
        if (col)
        {
            iTween.RotateBy(this.gameObject, iTween.Hash(
                    "y", -0.25f,
                    "time", 3f
                )
            );
        }
    }

    private void OnDrawGizmos()
    {
        iTween.DrawPath(centrosPistaIzq, Color.yellow);
        iTween.DrawPath(centrosPistaCen, Color.blue);
        iTween.DrawPath(centrosPistaDer, Color.red);
        
    }




}
