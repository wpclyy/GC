using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goudiw.sdk.client.primitive
{
    public class NullableByte : NullablePrimitiveObject
    {
        public NullableByte(byte value)
        {
            this.value = value;
            this.isNull = false;
        }

        byte value;
        private Boolean isNull;

        public Boolean IsNull
        {
            get { return isNull; }
        }

        public void setValue(byte value)
        {
            this.value = value;
            this.isNull = false;
        }

        public byte getValue()
        {
            return this.value;
        }
    }
}
