using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
	public Animator _currentPlayer;
	public Rigidbody2D myRigidbody;
	private float _currentSpeed;
	private bool _isRunning = false;

	[Header("Setup")]
	public SOPlayerSetup soPlayerSetup;

	[Header("Animation player")]
	public string triggerRun = "Run";



    private void Update()
	{
		HandleMoviment();
		HandleJump();
	}


	private void HandleMoviment()
	{
		if (Input.GetKey(KeyCode.LeftShift))
			_currentSpeed = soPlayerSetup.speedRun;
		else
			_currentSpeed = soPlayerSetup.speed;


		if (Input.GetKey(KeyCode.LeftArrow))
		{
			myRigidbody.velocity = new Vector2(-_currentSpeed, myRigidbody.velocity.y);
			if(myRigidbody.transform.localScale.x != -1)
			{
				myRigidbody.transform.DOScaleX(-1, .1f);
            }
			_currentPlayer.SetBool(triggerRun, true);
		}

		else if (Input.GetKey(KeyCode.RightArrow))
		{
			myRigidbody.velocity = new Vector2(_currentSpeed, myRigidbody.velocity.y);
			if (myRigidbody.transform.localScale.x != -1)
			{
				myRigidbody.transform.DOScaleX(1, .1f);
			}
			_currentPlayer.SetBool(triggerRun, true);
		}
		else 
		{
			_currentPlayer.SetBool(triggerRun, false);
		}

		if (myRigidbody.velocity.x > 0)
		{
			myRigidbody.velocity += soPlayerSetup.friction;
		}
		else if (myRigidbody.velocity.x < 0)
		{
			myRigidbody.velocity -= soPlayerSetup.friction;
		}
	}

	private void HandleJump()
	{
        if (Input.GetKey(KeyCode.Space)) {
		myRigidbody.velocity = Vector2.up * soPlayerSetup.forceJump;
		myRigidbody.transform.localScale = Vector2.one;
		DOTween.Kill(myRigidbody.transform);
		HadleScaleJump();
		}
	}

    private void HadleScaleJump()
    {
		myRigidbody.transform.DOScaleY(soPlayerSetup.jumpScaleY, soPlayerSetup.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetup.ease);
		myRigidbody.transform.DOScaleY(soPlayerSetup.jumpScaleX, soPlayerSetup.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetup.ease);
	}
}
