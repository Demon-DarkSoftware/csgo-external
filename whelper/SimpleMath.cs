using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whelper
{
    static class SimpleMath
    {
        public static float GetFOVAngles(float[] eyePos, float[] headPos, float[] entityHeadPos)
        {
            float[] res = DifferenceBetween(headPos, entityHeadPos);
            float yaw = (float)Math.Sin(Math.Abs(eyePos[1] - res[1]) * Math.PI / 180) * DistanceBetween(headPos, entityHeadPos);
            float pitch = (float)Math.Sin(Math.Abs(eyePos[0] - res[0]) * Math.PI / 180) * DistanceBetween(headPos, entityHeadPos);
            return (float)Math.Sqrt(Math.Pow(yaw, 2) + Math.Pow(pitch, 2));
        }
        public static float[] DifferenceBetween(float[] coords1, float[] coords2)
        {
            float[] result = new float[] {
                coords2[0] - coords1[0],
                coords2[1] - coords1[1],
                coords2[2] - coords1[2]
            };
            return result;
        }
        public static float Normalize(float ang) {
            while (ang < -180f) ang += 180f;
            while (ang > 180f) ang -= 180f;
            return ang;
        }
        public static float[] CalcAngles(float[] myPos, float[] bonePos, float[] angles) {
            float[] delta = new float[3];
            delta[0] = myPos[0] - bonePos[0];
            delta[1] = myPos[1] - bonePos[1];
            delta[2] = myPos[2] - bonePos[2];
            double hyper = Math.Sqrt((delta[0] * delta[0]) + (delta[1] * delta[1]));
            angles[0] = (float)(Math.Atan(delta[2] / hyper) * 57.295779513082f);
            angles[1] = (float)(Math.Atan(delta[1] / delta[0]) * 57.295779513082f);
            angles[2] = 0.0f;
            if (delta[0] >= 0.0) {
                angles[1] += 180.0f;
            }
            return angles;
        }
        public static float[] ClampAngles(float[] ang) {
            ang[0] = Normalize(ang[0]);
            ang[1] = Normalize(ang[1]);
            if (ang[0] > 89.0f) ang[0] = 89.0f;
            else if (ang[0] < -89.0f) ang[0] -= 89.0f;
            ang[2] = 0.0f;
            return ang;
        }


        public static float[] Normalized(float[] angle)
        {
            if (angle[0] >= 89.0f && angle[0] <= 180.0f)
            {
                angle[0] = 89.0f;
            }
            while (angle[0] > 180.0f) { if (angle[0] <= 180.0f) break; angle[0] -= 360.0f; }
            while (angle[0] < 89.0f) { if (angle[0] >= 89.0f) break; angle[0] = -89.0f; }
            while (angle[1] > 180.0f) { if (angle[1] <= 180.0f) break; angle[1] -= 360.0f; }
            while (angle[1] < -180.0f) { if (angle[1] >= -180.0f) break; angle[1] += 360.0f; }
            angle[2] = 0.0f;
            return angle;

        }

        public static float DistanceBetween(float[] coord1, float[] coord2)
        {
            return (float)Math.Sqrt(
                Math.Pow(coord2[0] - coord1[0], 2) +
                Math.Pow(coord2[1] - coord1[1], 2) +
                Math.Pow(coord2[2] - coord1[2], 2)
                );
        }
        public static float[] CalculateAngles(float[] coords1, float[] coords2)
        {
            float[] result1 = DifferenceBetween(coords1, coords2);
            float[] result2D = result1;
            result2D[2] = 0.0f;
            float[] newAngles = new float[] {
                (float)(Math.Atan2(-result1[2], Magnitude(result2D)) * 180 / Math.PI),
                (float)(Math.Atan2(result1[1], result1[0]) * 180 / Math.PI),
                0.0f
            };
            return newAngles;
        }
        public static float Magnitude(float[] coord)
        {
            return (float)Math.Sqrt(
                (Math.Pow(coord[0], 2)) +
                (Math.Pow(coord[1], 2)) +
                (Math.Pow(coord[2], 2))
                );
        }
        public static float[] SmoothnNormalize(float[] viewAngles, float[] newViewAngles, float smoothFactor)
        {
            return DifferenceBetween(
                Multiply(viewAngles, -1.0f),
                Multiply(DifferenceBetween(viewAngles, newViewAngles), 1 / smoothFactor)
                );
        }
        public static float[] Multiply(float[] coord, float factor)
        {
            return new float[] { coord[0] *= factor, coord[1] *= factor, coord[2] *= factor };
        }
    }
}
