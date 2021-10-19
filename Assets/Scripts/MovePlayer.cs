using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public Vector3 characterVelocity { get; set; }
    public GameObject CharModel;
    public GameObject Spawn;
    public bool isGrounded;
    public Rigidbody rb;
    private CharacterController CharacterController;
    private Animator animator;
    public Vector3 playerVelocity;
    private float jumpHeight = 1.0f;
    private float gravityValue = -18f;
    private bool groundedPlayer;
    private bool Dchecked;
    private bool Achecked;
    [SerializeField]
    private float moveSpeed=15f;
    [SerializeField]
    private float turnSpeed=0.5f;
    private float timer;
    public AudioSource Jump;


    private void Awake()
    {
        Dchecked = false;
        Achecked = false;
        Cursor.visible = false;

        CharacterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Start is called before the first frame update
    // Update is called once per frame

    void Update()
    {

        groundedPlayer = CharacterController.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        var horizontalK = Input.GetAxis("Horizontal");
        
        var horizontalM = Input.GetAxis("Mouse X");

        //Debug.Log(horizontalM);
        var horizontal = horizontalM;
        if (horizontal > 1.2)
        {
            horizontal = 1.2f;
        }
        else if (horizontal < -1.2)
        {
            horizontal = -1.2f;
        }
        var vertical = Input.GetAxis("Vertical");



        var mv = transform.forward * moveSpeed * vertical;

        

        animator.SetFloat("speed", vertical);
        transform.Rotate(Vector3.up, horizontal * turnSpeed * Time.deltaTime);
        //timer += Time.deltaTime ;
        float angle = Vector3.Angle(transform.forward, CharModel.transform.forward) -90;
        timer += Time.deltaTime;

        //Debug.Log(timer);

        if (Input.GetKeyDown(KeyCode.D) && Achecked==false)
        {
            Dchecked = true;
            StartCoroutine(Rotate(Vector3.up, -angle + 45, 0.15f));
            //CharModel.transform.Rotate(Vector3.up, 30);
            //Spawn.transform.Rotate(Vector3.up, 15);
            //timer = 0;
        }

        if (Input.GetKeyDown(KeyCode.A) && Dchecked == false)
        {
            Achecked = true;

            StartCoroutine(Rotate(Vector3.up, -angle - 45, 0.15f));
            //CharModel.transform.Rotate(Vector3.up, -30);
            //Spawn.transform.Rotate(Vector3.up, -15);
            //timer = 0;
        }
        

        

        if (Input.GetKeyUp(KeyCode.D) && Dchecked==true)
        {
            Dchecked = false;
            StartCoroutine(Rotate(Vector3.up, -angle, 0.1f));
            timer = 0;
            ///CharModel.transform.Rotate(Vector3.up, -30);
            //Spawn.transform.Rotate(Vector3.up, 15);
        }
        if (Input.GetKeyUp(KeyCode.A) && Achecked == true)
        {
            Achecked = false;
            timer = 0;

            StartCoroutine(Rotate(Vector3.up, -angle, 0.1f));
            //CharModel.transform.Rotate(Vector3.up, 30);
            //Spawn.transform.Rotate(Vector3.up, -15);
        }
        if (Achecked == false && Dchecked == false)
        {
            //float Sangle = Vector3.Angle(transform.forward, Spawn.transform.forward)-5.665f;
            //Debug.Log(Sangle);
            //Spawn.transform.Rotate(Vector3.up, -Sangle);

            StartCoroutine(Rotate(Vector3.up, -angle, 0.1f));
        }

        if (vertical > 0)
        {
            if (Achecked == true || Dchecked == true){

                CharacterController.Move(transform.right * 3f * horizontalK * Time.deltaTime);
            }
            
            CharacterController.Move(mv * Time.deltaTime);

            //CharacterController.Move(mv*Time.deltaTime);

        }
        
        
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            Jump.Play();
            //Debug.Log("Clicked");

  
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -2.2f * gravityValue);

        }
        playerVelocity.y += gravityValue * Time.deltaTime;

        CharacterController.Move(playerVelocity * Time.deltaTime);
        //Debug.Log("Why the f");










    }
    IEnumerator Rotate(Vector3 axis, float angle, float duration = 1.0f)
    {
        Quaternion from = CharModel.transform.rotation;
        Quaternion to = CharModel.transform.rotation;
        to *= Quaternion.Euler(axis * angle);

        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            CharModel.transform.rotation = Quaternion.Slerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        CharModel.transform.rotation = to;
    }
}
