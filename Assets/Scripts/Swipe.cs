using System.Collections;
using Unity.VisualScripting;
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

    public float dogMovementSpeed;
    bool canMove;

    string previousMovementDirection;

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
                    if (XInitial > XFinal && previousMovementDirection != "Izquierda")
                    {
                        Debug.Log("Izquierda");
                        canMove = true;
                        StartCoroutine(MovementDog("Izquierda"));
                    }

                    //Derecha
                    else if (previousMovementDirection != "Derecha")
                    {
                        Debug.Log("Derecha");
                        canMove = true;
                        StartCoroutine(MovementDog("Derecha"));
                    }
                }

                else
                {
                    //Abajo
                    if (YInitial > YFinal && previousMovementDirection != "Abajo")
                    {
                        Debug.Log("Abajo");
                        canMove = true;
                        StartCoroutine(MovementDog("Abajo"));
                    }

                    //Arriba
                    else if (previousMovementDirection != "Arriba")
                    {
                        Debug.Log("Arriba");
                        canMove = true;
                        StartCoroutine(MovementDog("Arriba"));
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        canMove = false;
    }

    IEnumerator MovementDog(string movementDirection)
    {

        while (canMove)
        {
            switch (movementDirection)
            {
                case "Derecha":
                    transform.position += new Vector3(dogMovementSpeed * Time.deltaTime, 0, 0);
                    break;
                case "Izquierda":
                    transform.position += new Vector3(-dogMovementSpeed * Time.deltaTime, 0, 0);
                    break;
                case "Arriba":
                    transform.position += new Vector3(0, dogMovementSpeed * Time.deltaTime, 0);
                    break;
                case "Abajo":
                    transform.position += new Vector3(0, -dogMovementSpeed * Time.deltaTime, 0);
                    break;
            }

            previousMovementDirection = movementDirection;

            yield return null;
        }
    }

}
