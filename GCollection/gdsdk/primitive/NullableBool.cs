using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goudiw.sdk.client.primitive
{
    public class NullableBool : NullablePrimitiveObject
    {
        public NullableBool(bool value)
        {
            this.value = value;
            this.isNull = false;
        }

        bool value;
        private Boolean isNull = true;

        public Boolean IsNull
        {
            get { return isNull; }
        }

        public void setValue(bool value)
        {
            this.value = value;
            this.isNull = false;
        }

        public bool getValue()
        {
            return this.value;
        }
    }
}
