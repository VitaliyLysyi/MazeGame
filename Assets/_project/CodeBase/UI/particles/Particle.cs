using System;
using System.Collections;
using System.Collections.Generic;
using codeBase.infrastructure.structures;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

namespace codeBase.ui.particles
{
    public class Particle : MonoBehaviour
    {
        [SerializeField] private Color _startColor;
        public Image image;
        public Vector2 sizeRange;
        
        public void active()
        {
            gameObject.SetActive(true);

            image.color = _startColor;
        }
    }
}
