using System;
using System.Collections.Generic;
using UnityEngine;

namespace codeBase.ui.animations
{
    public class SimpleRotateUI : MonoBehaviour
    {
        [SerializeField] private List<RotateObject> _rotateObjects;

        private void Update()
        {
            foreach (RotateObject rotateObjuect in _rotateObjects)
                rotateObjuect.transform.Rotate(rotateObjuect.axis * rotateObjuect.rotateAngle * Time.deltaTime);
        }

        [Serializable]
        private struct RotateObject
        {
            public Transform transform;
            public float rotateAngle;
            public Vector3 axis;
        }
    }
}