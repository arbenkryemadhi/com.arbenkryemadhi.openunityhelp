using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace OpenUnityHelp
{
    public class TimerOUH
    {

        public float delay = 1;
        public float currentTime;

        void Update()
        {
            if (currentTime > 0)
            {
                currentTime -= Time.deltaTime;

                if (currentTime < 0) currentTime = 0;
            }

            if (currentTime == 0)
            {
                //Do stuff here
                currentTime = delay;
            }
        }

    }
}
