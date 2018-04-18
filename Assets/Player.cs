using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DontDestroy;

public class Player : Actors
{
    [SerializeField]
    float speed, jumpForce;

    [SerializeField]
    ButtonManager buttons;

    [SerializeField]
    GameObject win;

    Renderer color;
    Color initialColor;
    private void Start()
    {
        color = GetComponent<Renderer>();
        initialColor = color.material.color;
        win.SetActive(false);
    }

    protected override void Function()
    {
        Movement();
    }

    void Movement()
    {
        transform.position += new Vector3(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0, Input.GetAxisRaw("Vertical") * speed * Time.deltaTime);
        if (Input.GetButton("Jump"))
        {
            if (Mathf.Abs(rig.velocity.y) < 0.001f)
            {
                rig.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            }
            
        }
      
    }
    public override void DamageTaken()
    {
        Singleton.vida--;
        if (Singleton.vida <= 0)
        {
            Singleton.vida = 10;
            buttons.Restart();
        }
        StartCoroutine(ChangeColor());
    }
    IEnumerator ChangeColor()
    {
        color.material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        color.material.color = initialColor;
        yield return new WaitForSeconds(0.1f);
        color.material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        color.material.color = initialColor;
        yield return new WaitForSeconds(0.1f);
        color.material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        color.material.color = initialColor;
    }
    protected override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Win")
        {
            Time.timeScale = 0;
            win.SetActive(true);
        }
        base.OnCollisionEnter(collision);
    }
}
