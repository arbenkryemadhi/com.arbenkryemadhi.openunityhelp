using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace OpenUnityHelp
{
    public class TimerOUH
    {
        private float _startingTime;
        private float _runningTime;
        private float _upperTimeLimit;
        private float _lowerTimeLimit;
        private float _currentTime;
        private bool _isRunning = false;
        private bool _hasFinished = true;
        private CountingMode _countingMode;

        public enum CountingMode
        {
            CountDown, 
            CountUp
        }
        
        public float StartingTime { get { return _startingTime; } set { _startingTime = value; } }
        public float CurrentTime { get { return _currentTime; } set { _currentTime = value; } }
        public float RunningTime { get { return _runningTime; } set { _runningTime = value; } }
        public float UpperTimeLimit { get { return _upperTimeLimit; } set { _upperTimeLimit = value; } }
        public float LowerTimeLimit { get { return _lowerTimeLimit; } set { _lowerTimeLimit = value; } }

        #region Instance constructors
        /// <summary>
        /// Default countdown timer. Counts down from <paramref name="startingTime"/> to <paramref name="lowerTimeLimit"/> (default = 0) .
        /// </summary>
        public TimerOUH(float startingTime, CountingMode countingMode = CountingMode.CountDown, float lowerTimeLimit = 0f)
        {
            _countingMode = countingMode;
            _startingTime = startingTime;
            _lowerTimeLimit = lowerTimeLimit;
        }


        /// <summary>
        /// Countup timer. Counts up to <paramref name="upperTimeLimit"/> from <paramref name="startingTime"/> (default = 0).
        /// </summary>
        public TimerOUH(CountingMode countingMode, float upperTimeLimit, float startingTime = 0f)
        {
            _countingMode = countingMode;
            _startingTime = startingTime;
            _upperTimeLimit = upperTimeLimit;
        }
        #endregion

        public void StartTimer()
        {
            _currentTime = _startingTime;
            _runningTime = 0f;
            _isRunning = true;
            _hasFinished = false;
        }

        public bool HasFinished() { return _hasFinished; }

        /// <summary>
        /// Updates the timer and does the necesary checks. Should be called every Update.
        /// </summary>
        public void UpdateTimer()
        {
            if (!_isRunning) { return; }

            if (_countingMode == CountingMode.CountDown) { CountDownUpdate(); }
            else { CountUpUpdate(); }

            _runningTime += Time.deltaTime;
        }

        private void CountDownUpdate()
        {
            if (_currentTime <= _lowerTimeLimit) // If timer has reached lower limit.
            {   
                _hasFinished = true;
                _isRunning = false;
                return; 
            }

            _currentTime -= Time.deltaTime;

        }

        private void CountUpUpdate()
        {
            if (_currentTime >= _upperTimeLimit) // If timer has reached upper limit.
            {
                _hasFinished = true;
                _isRunning = false;
                return;
            }

            _currentTime += Time.deltaTime;

        }


    }
}
