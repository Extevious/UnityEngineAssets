using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rocket.Physics {
    public class MoveTowards : MonoBehaviour {
        public Rigidbody[] rigidbodies;
        public float rate;

        private void FixedUpdate () {
            for (int i = 0; i < rigidbodies.Length; i++) {
                if (rigidbodies[i] == null || !rigidbodies[i].gameObject.activeSelf) continue;

                rigidbodies[i].AddForce((transform.position - rigidbodies[i].position).normalized * rate);
            }
        }
    }
}
