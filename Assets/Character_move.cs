using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_move : MonoBehaviour
{
    public float move_speed;

    void Update() {
        bool is_pressing_A = Input.GetKey(KeyCode.A);
        bool is_pressing_D = Input.GetKey(KeyCode.D);

        if(transform.position.z >= 1.25f){
            transform.position = new Vector2(transform.position.x, 1.24f);
        } else if (is_pressing_A){
            transform.Translate(Vector2.right * Time.deltaTime * move_speed);
        }
        
        if(transform.position.z <= -1.25f){
            transform.position = new Vector2(transform.position.x, -1.24f);
        }else if(is_pressing_D){
            transform.Translate(Vector2.left * Time.deltaTime * move_speed);
        }
    }
}
