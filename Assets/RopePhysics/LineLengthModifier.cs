﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LineBoneDeployer))]
public class LineLengthModifier : MonoBehaviour {
	public const float EPSILON = 1e-6f;

	public float length;

	private LineBoneDeployer _deployer;
	private float _prevLength = -1f;

	void Start() {
		_deployer = GetComponent<LineBoneDeployer>();
	}

	public void Update () {
		if (length != _prevLength) {
			length = Mathf.Max(EPSILON, length);
			_prevLength = length;
			var restLength = length / _deployer.segmentCount;
			foreach (var pmass in _deployer.line)
				pmass.restLength = restLength;
		}
	}
}
