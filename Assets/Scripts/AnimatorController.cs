using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimatorController : MonoBehaviour
{

	[SerializeField] private Animator animator;
	[SerializeField] private UnityEvent onJetpackActive, OnJetpackOff;

	private Movement movement;
	private Rigidbody2D rb;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		movement = GetComponent<Movement>();
	}

	private void Update()
	{
		//Animations
		animator.SetFloat("AbsoluteHorizontalVelocity",Mathf.Abs(rb.velocity.x));
		animator.SetFloat("AbsoluteVerticalVelocity",Mathf.Abs(rb.velocity.y));
		animator.SetFloat("HorizontalVelocity",rb.velocity.x);
		animator.SetFloat("VerticalVelocity",rb.velocity.y);
		
		animator.SetBool("OnGround", movement.collision.onGround);
		animator.SetBool("IsClimbing", movement.wallClimb.active);
		animator.SetBool("IsCrouching", movement.crouch.active);
		
		//Events
		if(movement.jetpack.active)
			onJetpackActive.Invoke();
		else
			OnJetpackOff.Invoke();
	}
}
