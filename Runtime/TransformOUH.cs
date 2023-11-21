using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using OpenUnityHelp;


namespace OpenUnityHelp
{
	public static class TransformOUH
    {
		#region Transform.position

		public static void SetXYZ(this Transform transform, float x, float y, float z)
		{
			transform.position = new Vector3(x, y, z);
		}

		public static void SetLocalXYZ(this Transform transform, float x, float y, float z)
		{
			transform.localPosition = new Vector3(x, y, z);
		}

		public static void SetXY(this Transform transform, float x, float y)
		{
			transform.position = new Vector3(x, y, transform.position.z);
		}

		public static void SetXY(this Transform transform, Vector3 pos)
		{
			transform.position = new Vector3(pos.x, pos.y, transform.position.z);
		}

		public static void SetLocalXY(this Transform transform, float x, float y)
		{
			transform.localPosition = new Vector3(x, y, transform.localPosition.z);
		}

		public static void SetLocalXY(this Transform transform, Vector3 pos)
		{
			transform.localPosition = new Vector3(pos.x, pos.y, transform.localPosition.z);
		}

		public static void SetXZ(this Transform transform, float x, float z)
		{
			transform.position = new Vector3(x, transform.position.y, z);
		}

		public static void SetXZ(this Transform transform, Vector3 pos)
		{
			transform.position = new Vector3(pos.x, transform.position.y, pos.z);
		}

		public static void SetLocalXZ(this Transform transform, float x, float z)
		{
			transform.localPosition = new Vector3(x, transform.localPosition.y, z);
		}

		public static void SetLocalXZ(this Transform transform, Vector3 pos)
		{
			transform.localPosition = new Vector3(pos.x, transform.localPosition.y, pos.z);
		}

		public static void SetYZ(this Transform transform, float y, float z)
		{
			transform.position = new Vector3(transform.position.x, y, z);
		}

		public static void SetYZ(this Transform transform, Vector3 pos)
		{
			transform.position = new Vector3(transform.position.x, pos.y, pos.z);
		}

		public static void SetLocalYZ(this Transform transform, float y, float z)
		{
			transform.localPosition = new Vector3(transform.localPosition.x, y, z);
		}

		public static void SetLocalYZ(this Transform transform, Vector3 pos)
		{
			transform.localPosition = new Vector3(transform.localPosition.x, pos.y, pos.z);
		}

		public static void SetX(this Transform transform, float x)
		{
			transform.position = new Vector3(x, transform.position.y, transform.position.z);
		}

		public static void SetLocalX(this Transform transform, float x)
		{
			transform.localPosition = new Vector3(x, transform.localPosition.y, transform.localPosition.z);
		}

		public static void SetY(this Transform transform, float y)
		{
			transform.position = new Vector3(transform.position.x, y, transform.position.z);
		}

		public static void SetLocalY(this Transform transform, float y)
		{
			transform.localPosition = new Vector3(transform.localPosition.x, y, transform.localPosition.z);
		}

		public static void SetZ(this Transform transform, float z)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y, z);
		}

		public static void SetLocalZ(this Transform transform, float z)
		{
			transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, z);
		}

		public static void IncX(this Transform transform, float dx)
		{
			SetX(transform, transform.position.x + dx);
		}

		public static void IncLocalX(this Transform transform, float dx)
		{
			SetLocalX(transform, transform.localPosition.x + dx);
		}

		public static void IncY(this Transform transform, float dy)
		{
			SetY(transform, transform.position.y + dy);
		}

		public static void IncLocalY(this Transform transform, float dy)
		{
			SetLocalY(transform, transform.localPosition.y + dy);
		}

		public static void IncZ(this Transform transform, float dz)
		{
			SetZ(transform, transform.position.z + dz);
		}

		public static void IncLocalZ(this Transform transform, float dz)
		{
			SetLocalZ(transform, transform.localPosition.z + dz);
		}

		#endregion

		#region Transform.localScale

		public static void SetScale(this Transform transform, float scale)
		{
			transform.localScale = Vector3.one * scale;
		}

		public static void SetScaleX(this Transform transform, float scaleX)
		{
			transform.localScale = new Vector3(scaleX, transform.localScale.y, transform.localScale.z);
		}

		public static void SetScaleY(this Transform transform, float scaleY)
		{
			transform.localScale = new Vector3(transform.localScale.x, scaleY, transform.localScale.z);
		}

		public static void SetScaleZ(this Transform transform, float scaleZ)
		{
			transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, scaleZ);
		}

		#endregion

		#region Transform.rotation

		public static void SetRotation(this Transform transform, float angle)
		{
			transform.rotation = new Quaternion();
			transform.Rotate(Vector3.forward, angle);
		}

		#endregion
	}
}

