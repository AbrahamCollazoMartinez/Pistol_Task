using UnityEngine;

public class LookToObject : MonoBehaviour
{
	[SerializeField] private Transform look_target;
	[SerializeField] private float rotationSpeed;
	private Vector3 direction;
	private Quaternion targetRotation;

	private void Update()
	{
		direction = look_target.position - transform.position;
		targetRotation = Quaternion.LookRotation(direction);
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
	}

	public void SetNewTarget(Transform new_target) => look_target = new_target;
}
