using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using OpenUnityHelp;

namespace OpenUnityHelp
{
    public static class RandomOUH
    {
        #region Random Number
        ///<summary>
        /// Returns a random float within [minInclusive; maxInclusive] with a specified amount of decimal spaces (default = 2).
        ///</summary>
        public static float RandomNum(float minInclusive, float maxInclusive, int decimalSpaces = 2)
        {
            float tempRandomValue;

            tempRandomValue = (float)Math.Round(UnityEngine.Random.Range(minInclusive, maxInclusive), decimalSpaces);

            // Rounds the value again for cases when rounding didn't work properly.
            return (float)Math.Round(tempRandomValue, decimalSpaces);
        }


        /// <summary>
        /// Returns a random float within [pairMinMax.x; pairMinMax.y] which are stored in pairMinMax Vector2 with a specified amount of decimal spaces.
        /// </summary>
        public static float RandomNum(Vector2 pairMinMax, int decimalSpaces)
		{
			return RandomNum(pairMinMax.x, pairMinMax.y, decimalSpaces);
		}


        /// <summary>
        /// Return a random int between [minInclusive; maxExclusive[.
        /// </summary>
        public static int RandomNum(int minInclusive, int maxExclusive)
        {
            return UnityEngine.Random.Range(minInclusive, maxExclusive);
        }


        /// <summary>
        /// Returns a random int within [pairMinMax.x; pairMinMax.y[ which are stored in pairMinMax Vector2.
        /// </summary>
        public static int RandomNum(Vector2 pairMinMax)
        {
            return RandomNum((int)pairMinMax.x, (int)pairMinMax.y);
        }
        #endregion

        #region Random Numbers
        ///<summary>
        /// Returns a random list of floats within [minInclusive; maxInclusive] with a specified amount of decimal spaces (default = 2).
        ///</summary>
        public static List<float> RandomNums(float minInclusive, float maxInclusive, int numberOfFloats, int decimalSpaces = 2)
        {
            List<float> randomFloats = new List<float>();

            for (int i = 0; i < numberOfFloats; i++)
            {
                // Generates a random float within the parameters and adds it to the return list.
                randomFloats.Add(RandomNum(minInclusive, maxInclusive, decimalSpaces));
            }

            return randomFloats;
        }


        /// <summary>
        /// Returns a random list of floats within [pairMinMax.x; pairMinMax.y] which are stored in pairMinMax Vector2 with a specified amount of decimal spaces.
        /// </summary>
        public static List<float> RandomNums(Vector2 pairMinMax, int numberOfFloats, int decimalSpaces)
		{
			return RandomNums(pairMinMax.x, pairMinMax.y, numberOfFloats, decimalSpaces);
		}


        ///<summary>
        /// Returns a random list of ints within [minInclusive; maxExclusive[ with the ability for the same int to be repeated (default = true).
        ///</summary>
        public static List<int> RandomNums(int minInclusive, int maxExclusive, int numberOfInts, bool allowRepeatedInts = true)
        {
            List<int> randomInts = new List<int>();

            // If a number can be multiple times then just fill the list with as many random ints as user wants.
            if (allowRepeatedInts)
            {
                for (int i = 0; i < numberOfInts; i++)
                {
                    randomInts.Add(RandomNum(minInclusive, maxExclusive));
                }
                
            }
            else
            {
                // Creates a list of possible ints and fills it with all of the possible ints.
                List<int> possibleInts = new List<int>();

                for (int i = minInclusive; i < maxExclusive; i++)
                {
                    possibleInts.Add(i);
                }

                
                for (int i = 0; i < numberOfInts; i++)
                {
                    // Generates a random index
                    int randIndex = RandomNum(0, possibleInts.Count);

                    // Adds an int from the possible ints list to the one to be returned.
                    randomInts.Add(possibleInts[randIndex]);

                    // Removes the number at said index.
                    possibleInts.RemoveAt(randIndex);
                }
            }
            

            return randomInts;
        }


        /// <summary>
        /// Returns a random list of ints within [pairMinMax.x; pairMinMax.y[ which are stored in pairMinMax Vector2 with the ability for the same int to be repeated (default = true).
        /// </summary>
        public static List<int> RandomNums(Vector2 pairMinMax, int numberOfInts, bool allowRepeatedInts = true)
        {
            return RandomNums((int)pairMinMax.x, (int)pairMinMax.y, numberOfInts, allowRepeatedInts);
        }

        #endregion

        /// <summary>
        /// Returns random bool value with 50/50 chance (true/false).
        /// </summary>
        public static bool RandomBool()
		{
			return RandomNum(0, 2) == 0;
		}


        /// <summary>
        /// Returns a bool with given probability in %. If probability is 25% it will return true each 4th time on an average.
        /// </summary>
        public static bool RandomBool(int percentage)
		{
			return RandomNum(0, 100) + 1 <= percentage;
		}

        /// <summary>
        /// Returns a bool with given probability in %. If probability is 25.0% it will return true each 4th time on an average.
        /// </summary>
        public static bool RandomBool(float probability)
		{
			return RandomNum(0f, 100f) <= probability;
		}


		/// <summary>
		/// Returns random item from array.
		/// </summary>
		public static T RandomItem<T>(T[] array)
		{
			return array[RandomNum(0, array.Length)];
		}


		/// <summary>
		/// Returns random item from list.
		/// </summary>
		public static T RandomItem<T>(List<T> list)
		{
			return list[RandomNum(0, list.Count)];
		}

		/// <summary>
		/// Returns random enum item.
		/// </summary>
		public static T RandomItem<T>()
		{
			var values = Enum.GetValues(typeof(T));
			return (T)values.GetValue(RandomNum(0, values.Length));
		}


		/// <summary>
		/// Returns random index of passed list.
		/// </summary>
		public static int RandomIndex<T>(List<T> list)
        {
			return RandomNum(0, list.Count);
        }


		/// <summary>
		/// Returns random index of passed array.
		/// </summary>
		public static int RandomIndex<T>(T[] array)
		{
			return RandomNum(0, array.Length);
		}

		
		/// <summary>
		/// Return sub-list of random items from origin list without repeating.
		/// </summary>
		public static List<T> ReturnRandomItems<T>(IList<T> list, int count)
		{
			List<T> items = new List<T>();
			List<int> remainedIndexes = Enumerable.Range(0, list.Count).ToList();
			for (int i = 0; i < count; i++)
			{
				int selectedIndex = RandomItem(remainedIndexes);
				remainedIndexes.Remove(selectedIndex);
				items.Add(list[selectedIndex]);
			}
			return items;
		}


		/// <summary>
		/// Shuffles list of items.
		/// </summary>
		public static void Shuffle<T>(this List<T> list)
		{
			for (int i = 1; i < list.Count; i++)
			{
				int randInt = RandomNum(0, list.Count);
				T temp = list[i];
				list[i] = list[randInt];
				list[randInt] = temp;
			}
		}

        /// <summary>
        /// Shuffles array of items.
        /// </summary>
        public static void Shuffle<T>(this T[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int indRnd = RandomNum(0, array.Length);
                T temp = array[i];
                array[i] = array[indRnd];
                array[indRnd] = temp;
            }
        }


        /// <summary>
        /// Returns a shuffled list of items from the passed list.
        /// </summary>
        public static List<T> GetShuffledList<T>(List<T> list)
        {
			List<T> shuffledList = list;

			for (int i = 1; i < list.Count; i++)
			{
				int randInt = RandomNum(0, list.Count);
				T temp = shuffledList[i];
				shuffledList[i] = shuffledList[randInt];
				shuffledList[randInt] = temp;
			}

			return shuffledList;
		}


		/// <summary>
		/// Returnns a shuffled array of items from the passed array.
		/// </summary>
		public static T[] GetShuffledArray<T>(T[] array)
		{
			T[] shuffledArray = array;

			for (int i = 1; i < array.Length; i++)
			{
				int randInt = RandomNum(0, array.Length);
				T temp = shuffledArray[i];
				shuffledArray[i] = shuffledArray[randInt];
				shuffledArray[randInt] = temp;
			}

			return shuffledArray;
		}


		/// <summary>
		/// Returns random point on line 2D.
		/// </summary>
		public static Vector2 RandomPointOnLine(Vector2 point1, Vector2 point2)
		{
			float t = RandomNum(0f, 1f);
			return new Vector2(Mathf.Lerp(point1.x, point2.x, t), Mathf.Lerp(point1.y, point2.y, t));
		}


		/// <summary>
		/// Returns random point on line 3D.
		/// </summary>
		public static Vector3 RandomPointOnLine3D(Vector3 point1, Vector3 point2)
		{
			float t = RandomNum(0f, 1f);
			return new Vector3(Mathf.Lerp(point1.x, point2.x, t), Mathf.Lerp(point1.y, point2.y, t), Mathf.Lerp(point1.z, point2.z, t));
		}


		/// <summary>
		/// Get random normalized 2D direction as Vector2.
		/// </summary>
		public static Vector2 RandomDirection2D()
		{
			return UnityEngine.Random.insideUnitCircle.normalized;
		}

		
		/// <summary>
		/// Return random point from rect bound (inside rect).
		/// </summary>
		public static Vector2 RandomPointInsideRect(Rect rect)
		{
			return new Vector2(RandomNum(rect.xMin, rect.xMax), RandomNum(rect.yMin, rect.yMax));
		}


		/// <summary>
		/// Return random point on rect border (perimeter of rect).
		/// </summary>
		public static Vector2 RandomPointOnRectBorder(Rect rect)
		{
			float perimeterLength = (rect.width + rect.height) * 2f;
			float pointOnPerimeter = RandomNum(0f, perimeterLength);

			if (pointOnPerimeter < rect.width)//top border
				return new Vector2(rect.xMin + pointOnPerimeter, rect.yMax);

			pointOnPerimeter -= rect.width;

			if (pointOnPerimeter < rect.height)//right border
				return new Vector2(rect.xMax, rect.yMin + pointOnPerimeter);

			pointOnPerimeter -= rect.height;

			if (pointOnPerimeter < rect.width)//bottom border
				return new Vector2(rect.xMin + pointOnPerimeter, rect.yMin);

			pointOnPerimeter -= rect.width;

			//left border
			return new Vector2(rect.xMin, rect.yMin + pointOnPerimeter);
		}
	}
}
