using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class scr_PlusBall : MonoBehaviour
{





    


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 13 ||collision.gameObject.layer == 10 || collision.gameObject.layer == 11 || collision.gameObject.layer == 12)
        {
           
            if (transform.position.x < 0)
            {
                gameObject.transform.position = new Vector3(Random.Range(-1, -7.5f), Random.Range(-1, 1.5f), 0);
                
            }
            else
            {
                gameObject.transform.position = new Vector3(Random.Range(1.5f, 8), Random.Range(-1, 1.5f), 0);
                
            }
        }

        
    }
}
