using ArkSaveEditor.Deserializer.DotArk;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.Entities.LowLevel.DotArk.ArkProperties
{
    public class ArrayProperty<T> : DotArkProperty
    {
        public ArkClassName arrayType;
        public List<T> items;

        public ArrayProperty()
        {
            
        }

        
    }
}
