using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Player : MonoBehaviour
{
	[Header("Speed setup")]
	public Rigidbody2D myRigidbody;
	public Vector2 friction = new Vector2(.1f, 0);
	public float speed;
	public float speedRun;
	public float forceJump = 2;
	private float _currentSpeed;

	[Header("Animation")]
	public float jumpScaleY = 1.5f;
	public float jumpScaleX = 0.7f;
	public float animationDuration = .3f;
	public Ease ease = Ease.OutBack;

	[Header("Animation player")]
	public string triggerRun = "Run";
	public Animator animator;

	private bool _isRunning = false;
	private void Update()
	{
		HandleMoviment();
		HandleJump();
	}


	private void HandleMoviment()
	{
		if (Input.GetKey(KeyCode.LeftShift))
			_currentSpeed = speedRun;
		else
			_currentSpeed = speed;


		if (Input.GetKey(KeyCode.LeftArrow))
		{
			myRigidbody.velocity = new Vector2(-_currentSpeed, myRigidbody.velocity.y);
			if(myRigidbody.transform.localScale.x != -1)
			{
				myRigidbody.transform.DOScaleX(-1, .1f);
            }
			animator.SetBool(triggerRun, true);
		}

		else if (Input.GetKey(KeyCode.RightArrow))
		{
			myRigidbody.velocity = new Vector2(_currentSpeed, myRigidbody.velocity.y);
			if (myRigidbody.transform.localScale.x != -1)
			{
				myRigidbody.transform.DOScaleX(1, .1f);
			}
			animator.SetBool(triggerRun, true);
		}
		else 
		{
			animator.SetBool(triggerRun, false);
		}

		if (myRigidbody.velocity.x > 0)
		{
			myRigidbody.velocity += friction;
		}
		else if (myRigidbody.velocity.x < 0)
		{
			myRigidbody.velocity -= friction;
		}
	}

	private void HandleJump()
	{
        if (Input.GetKey(KeyCode.Space)) {
		myRigidbody.velocity = Vector2.up * forceJump;
		myRigidbody.transform.localScale = Vector2.one;
		DOTween.Kill(myRigidbody.transform);
		/*HadleScaleJump();*/
		}
	}

   /* private void HadleScaleJump()
    {
		myRigidbody.transform.DOScaleY(jumpScaleY, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
		myRigidbody.transform.DOScaleY(jumpScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
	}*/
}
