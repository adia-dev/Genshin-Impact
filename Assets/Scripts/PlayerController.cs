using UnityEngine;
using System.Collections;
using TMPro;

public class PlayerController : MonoBehaviour
{

	[SerializeField] bool _hideCursor = true;

	public float walkSpeed = 2;
	public float runSpeed = 6;

	public float turnSmoothTime = 0.2f;
	float turnSmoothVelocity;

	public float speedSmoothTime = 0.1f;
	float speedSmoothVelocity;
	float currentSpeed;

	Animator animator;
	Transform cameraT;

	public TMP_Text scoreText;
	public int score = 0;

	void Start()
	{
		animator = GetComponent<Animator>();
		cameraT = Camera.main.transform;


		if (_hideCursor)
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = _hideCursor;
		}
	}

	void Update()
	{

		Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		Vector2 inputDir = input.normalized;

		if (inputDir != Vector2.zero)
		{
			float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y;
			transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);
		}

		bool running = Input.GetKey(KeyCode.LeftShift);
		float targetSpeed = ((running) ? runSpeed : walkSpeed) * inputDir.magnitude;
		currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);

		transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World);

		float animationSpeedPercent = ((running) ? 1 : .5f) * inputDir.magnitude;
		animator.SetFloat("speedPercent", animationSpeedPercent, speedSmoothTime, Time.deltaTime);

	}
	private void OnTriggerEnter(Collider collider){
		Debug.Log("Trigger Enter");
	}

	private void OnTriggerStay(Collider collider){

		if(Input.GetKey(KeyCode.E)){
			score++;
			scoreText.text = "Score : " + score;
		}
	}
}