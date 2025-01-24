using UnityEngine;
using UnityEngine.InputSystem;

public class Swipe : MonoBehaviour
{
    float timeSwiping;
    public float swipeThresholdMax;
    public float swipeThresholdMin;

    float XInitial;
    float YInitial;
    float XFinal;
    float YFinal;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            XInitial = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            YInitial = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
        }

        if (Input.GetMouseButton(0))
        {
            timeSwiping += Time.deltaTime;
        }

        //Control de dirección del swipe
        if (Input.GetMouseButtonUp(0))
        {
            XFinal = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            YFinal = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;

            if (timeSwiping < swipeThresholdMax && timeSwiping >= swipeThresholdMin)
            {
                //Horizontal
                if (Mathf.Abs(XFinal - XInitial) > Mathf.Abs(YFinal - YInitial))
                {
                    //Izquierda
                    if (XInitial > XFinal)
                    {
                        Debug.Log("Izquierda");
                    }

                    //Derecha
                    else
                    {
                        Debug.Log("Derecha");
                    }
                }

                else 
                {
                    //Abajo
                    if (YInitial > YFinal)
                    {
                        Debug.Log("Abajo");
                    }

                    //Arriba
                    else
                    {
                        Debug.Log("Arriba");
                    }
                }
            }

            timeSwiping = 0;
            XInitial = 0; 
            YInitial = 0;
            XFinal = 0;
            YFinal = 0;

        }
        
    }
}
