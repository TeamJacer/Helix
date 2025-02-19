using UnityEngine;
using System.Collections;

[AddComponentMenu("Health/Health Event Indicator")]
public class HealthEventIndicator : MonoBehaviour {

	public float amount;
	public float lifeTime = 2;
	public Vector3 randomForce = Vector3.zero;

	void Start() {
		rigidbody.velocity = Vector3.Scale(new Vector3(1 - (Random.value * 2), (Random.value * 2), 1 - (Random.value * 2)), randomForce);

		SetText();
		Destroy(gameObject, lifeTime);
	}

	void LateUpdate() {
		Transform t = GetComponentInChildren<TextMesh>().transform;

		t.LookAt(Camera.main.transform);
		t.Rotate(Vector3.up * 180, Space.Self);
	}

	void OnHealed(HealthEvent health) {
		amount = health.amount;
	}

	void OnDamaged(HealthEvent health) {
		amount = health.amount;
	}

	void OnDeath(HealthEvent health) {
		amount = health.amount;
	}

	public void SetText() {
		string text = "<color=";
		text += Mathf.Sign(amount) > 0 ? "green" : "red";
		text += ">" + amount + "</color>";

		GetComponentInChildren<TextMesh>().text = text;
	}
}
