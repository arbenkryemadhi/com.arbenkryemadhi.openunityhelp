using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace OpenUnityHelp
{ 
    public static class UtilsOUH
    {
        ///<summary>
        /// Starts any function put through after a delay in seconds.
        ///</summary>
        public static IEnumerator StartFunctionWithDeay(Action function, float delay)
        {
            yield return new WaitForSeconds(delay);
            function();
        }
    }
}
