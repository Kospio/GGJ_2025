using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Cervatana : MonoBehaviour
{
    float XInitial;
    float YInitial;

    string previousMovementDirection;

    Vector2 shootingDirection;

    public GameObject bulletInstanciate; 

    MinigameManager minigameManager;

    private void Start()
    {
        minigameManager = GameObject.FindFirstObjectByType<MinigameManager>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && minigameManager.timeLeft > 0)
        {
            XInitial = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            YInitial = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;

            Vector3 shootingDirectionFixed = new Vector3(XInitial, YInitial - transform.position.y, 0);
            this.gameObject.transform.up = shootingDirectionFixed.normalized;

            ShootingBullet(); 
        }
    }

    void ShootingBullet()
    {
        Instantiate(bulletInstanciate, transform.position, this.transform.rotation);
    }
    
}
