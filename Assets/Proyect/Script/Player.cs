using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float jumpDist;
    bool jumped;
    Vector2 screen;
    Vector3 startingPosition;
	// Use this for initialization
	void Start () {
        
        screen.x = (Screen.width/100f)/2f / Camera.main.aspect;
        screen.y = (Screen.height/100f)/2f / Camera.main.aspect; 
        startingPosition = transform.position;
    }
	
	// Update is called once per frame
	void Update () {

        float horizontalMov = Input.GetAxis("Horizontal");
        float verticalMov = Input.GetAxis("Vertical");
        
        if (!jumped)
        {
            Vector2 targetPos = Vector2.zero;
            bool wantMove = false;
            if (horizontalMov != 0 )
            {
                wantMove = true;
                targetPos = new Vector2(
                    
                    transform.position.x + (horizontalMov > 0 ? jumpDist : -jumpDist),
                    transform.position.y
                    );
            }
            if (verticalMov != 0)
            {
                wantMove = true;
                targetPos = new Vector2(
                    transform.position.x ,
                    transform.position.y + (verticalMov > 0 ? jumpDist : -jumpDist)
                    );
            }
            Collider2D hitCol = Physics2D.OverlapCircle(targetPos, 0.1f);

            if (wantMove && hitCol == null)
            {
                transform.position = targetPos;
                jumped = true;
            }
           
        }
        else
        {
            if(horizontalMov==0 && verticalMov == 0)
            {
                jumped = false;
            }
        }

        //comprobar si se sale de los limites

        if (transform.position.y < -screen.y)
        {
            transform.position = new Vector2(transform.position.x,transform.position.y+jumpDist);
        }else if (transform.position.y > screen.y)
        {
            transform.position = startingPosition;
        }
        if (transform.position.x < -screen.x)
        {
            transform.position = new Vector2(transform.position.x + jumpDist, transform.position.y );
        }
        else if (transform.position.x > screen.x)
        {
            transform.position = new Vector2(transform.position.x - jumpDist, transform.position.y);
        }

    }
}
