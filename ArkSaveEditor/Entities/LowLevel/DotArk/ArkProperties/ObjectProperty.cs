using ArkSaveEditor.Deserializer.DotArk;
using ArkSaveEditor.Serializer.DotArk;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.Entities.LowLevel.DotArk.ArkProperties
{
    public class ObjectProperty : DotArkProperty
    {
        public ObjectPropertyType objectRefType;

        public int objectId; //Only used if the above is ObjectPropertyType.TypeID
        public ArkClassName className; //Only used if the above is ObjectPropertyType.TypePath

        [Newtonsoft.Json.JsonIgnoreAttribute]
        public DotArkGameObject gameObjectRef; //Only exists if the above is ObjectPropertyType.TypeID

        public ObjectProperty(DotArkDeserializer d, int index, int length)
        {
            var ms = d.ms;

            //If the length is four (only seems to happen on version 5), this is an integer.
            if(length == 4)
            {
                objectRefType = ObjectPropertyType.TypeID;
                dataFilePosition = ms.position;
                objectId = ms.ReadInt();
            } else if (length >= 8)
            {
                //Read type
                int type = ms.ReadInt();
                if (type > 1 || type < 0)
                    throw new Exception($"Unknown ref type! Expected 0 or 1, but got {type} instead!");
                //Convert this to our enum
                objectRefType = (ObjectPropertyType)type;
                dataFilePosition = ms.position;
                //Depending on the type, read it in.
                if (objectRefType == ObjectPropertyType.TypeID)
                    objectId = ms.ReadInt();
                if (objectRefType == ObjectPropertyType.TypePath)
                    className = ms.ReadArkClassname(d);
            } else
            {
                dataFilePosition = ms.position;
                throw new Exception($"Unknown object ref length! Expected 4 or >= 8, but got {length} instead.");
            }
            //If this is a type ID, I **THINK** this is a refrence to a GameObject
            if(objectRefType == ObjectPropertyType.TypeID)
            {
                if(objectId != -1)
                    gameObjectRef = d.gameObjects[objectId];
            }
        }

        public override void WriteProp(DotArkSerializerInstance s, DotArkGameObject go, DotArkFile f, IOMemoryStream ms)
        {
            base.WriteProp(s, go, f, ms);

            //If the length is four, just write the objectID
            //TODO: Track the referenced GameObject so changing the index doesn't break this.
            if(size == 4)
            {
                ms.WriteInt(objectId);
            } else if (size >= 8)
            {
                //Write the type
                ms.WriteInt((int)objectRefType);

                //Depending on the type, write it
                if (objectRefType == ObjectPropertyType.TypeID)
                    ms.WriteInt(objectId);
                else if (objectRefType == ObjectPropertyType.TypePath)
                    ms.WriteArkClassname(className, s);
                else
                    throw new Exception("Unknown type of ObjectProperty.");
            } else
            {
                throw new Exception($"Unknown ObjectProperty length, {size}. Cannot write.");
            }
        }
    }

    public enum ObjectPropertyType
    {
        TypeID = 0,
        TypePath = 1
    }
}
