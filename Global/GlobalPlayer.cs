using System;
using System.Collections.Generic;
using UnityEngine;

namespace Global
{
    public class GlobalPlayer : MonoBehaviour
    {
        public static GlobalPlayer instance;
        public List<Card> deck;

        private void Awake()
        {
            instance = this;
        }
    }
}