using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FreeDraw.Model
{
    [Serializable]
    public class AppMatrix : ISerializable
    {
        [NonSerialized]
        public Matrix matrix = new Matrix();

        public AppMatrix() { }

        public AppMatrix(Matrix matrix)
        {
            this.matrix = matrix;
        }
        public AppMatrix(SerializationInfo info, StreamingContext context)
        {
            float[] m = (float[])info.GetValue("matrix", typeof(float[]));
            matrix = new Matrix(m[0], m[1], m[2], m[3], m[4], m[5]);
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("matrix", matrix.Elements, typeof(float[]));
        }

    }
}
