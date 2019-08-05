using System;
using System.Collections.Generic;
using System.Text;
using ArkSaveEditor.Entities.LowLevel;
using ArkSaveEditor.Entities.LowLevel.DotArk;
using System.Linq;
using ArkSaveEditor.Entities.LowLevel.DotArk.ArkProperties;

namespace ArkSaveEditor.World
{
    /// <summary>
    /// High level gameobject that gives more useful functions needed for higher level access. Refrences directly to the source file.
    /// </summary>
    public class HighLevelArkGameObjectRef
    {
        /// <summary>
        /// The world this object belongs to.
        /// </summary>
        [Newtonsoft.Json.JsonIgnoreAttribute]
        public readonly ArkWorld world;

        public HighLevelArkGameObjectRef(ArkWorld world, DotArkGameObject source)
        {
            this.source = source;
            this.world = world;

            this.guid = source.guid;
            this.classname = source.classname;
            this.classnameString = source.classname.classname;
            this.isItem = source.isItem;
            this.altNames = source.names;
            this.location = source.locationData;
        }

        public HighLevelArkGameObjectRef()
        {

        }

        /// <summary>
        /// Legacy method.
        /// </summary>
        /// <param name="world"></param>
        /// <param name="index"></param>
        public HighLevelArkGameObjectRef(ArkWorld world, int index)
        {
            DotArkGameObject source = world.sources[index];
            this.source = source;
            this.world = world;

            this.guid = source.guid;
            this.classname = source.classname;
            this.classnameString = source.classname.classname;
            this.isItem = source.isItem;
            this.altNames = source.names;
            this.location = source.locationData;
        }

        private DotArkGameObject source;

        /// <summary>
        /// GUID for the object. Important to multiplayer. Don't change.
        /// </summary>
        public Guid guid;

        /// <summary>
        /// The standard classname of this object.
        /// </summary>
        public ArkClassName classname;

        /// <summary>
        /// A version of the classname in a standard string format.
        /// </summary>
        public string classnameString;

        /// <summary>
        /// Returns true if this is an inventory item.
        /// </summary>
        public bool isItem;

        /// <summary>
        /// Alternate names for this object.
        /// </summary>
        public List<ArkClassName> altNames;

        /// <summary>
        /// The location of this object. May be null.
        /// </summary>
        public DotArkLocationData location;

        /// <summary>
        /// Raw access to the properties.
        /// </summary>
        [Newtonsoft.Json.JsonIgnoreAttribute]
        public List<DotArkProperty> rawProperties;

        public DotArkProperty[] GetPropertiesByName(string name)
        {
            return source.props.Where(x => x.name.classname == name).ToArray();
        }

        public bool CheckIfValueExists(string name)
        {
            return GetPropertiesByName(name).Length >= 1;
        }

        public bool GetBooleanProperty(string name)
        {
            //Get the value. If it doesn't exist, return false because that is how items are saved.
            var p = GetPropertiesByName(name);
            if (p.Length == 0)
                return false;
            //Return if this is true or not.
            return (bool)((BoolProperty)p[0]).data;
        }

        public DotArkProperty GetSingleProperty(string name)
        {
            var arr = source.props.Where(x => x.name.classname == name).ToArray();
            //If there are less or more than 1, throw an exception
            if (arr.Length != 1)
                throw new Exception($"The number of properties with name {name} did not equal 1. Instead, there were {arr.Length} values.");
            return arr[0];
        }

        
        public uint GetUInt32Property(string name)
        {
            return (uint)GetSingleProperty(name).data;
        }

        public ushort GetUInt16Property(string name)
        {
            return (ushort)GetSingleProperty(name).data;
        }

        public int GetInt32Property(string name)
        {
            return (int)GetSingleProperty(name).data;
        }

        public HighLevelArkGameObjectRef GetGameObjectRef(string name)
        {
            var prop = (ObjectProperty)GetSingleProperty(name);
            if (prop.objectRefType != ObjectPropertyType.TypeID)
                throw new Exception("The ref provided by this property is not a GameObject!");
            return new HighLevelArkGameObjectRef(world, prop.gameObjectRef);
        }

        public float GetFloatProperty(string name)
        {
            return (float)GetSingleProperty(name).data;
        }

        public double GetDoubleProperty(string name)
        {
            return (double)GetSingleProperty(name).data;
        }

        public string GetStringProperty(string name)
        {
            return (string)GetSingleProperty(name).data;
        }

        public bool HasProperty(string name)
        {
            var arr = source.props.Where(x => x.name.classname == name).ToArray();
            return arr.Length != 0;
        }

        public UInt64 GetUInt64Property(string name)
        {
            return (UInt64)GetSingleProperty(name).data;
        }
    }
}
