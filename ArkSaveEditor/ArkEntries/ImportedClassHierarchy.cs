using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArkSaveEditor.ArkEntries
{
    public class ImportedClassHierarchyFile
    {
        public bool Metadata;
        public DateTime FileTimestamp;
        public ImportedClassHierarchyEntry ClassData;

        public FoundClassHierarchyEntry FindEntryByClassname(string name)
        {
            return ClassData.CheckForName(name, new List<ImportedClassHierarchyEntry>());
        }
    }

    public class ImportedClassHierarchyEntry
    {
        public string Name;
        public string DisplayName;
        public string Tooltip;
        public bool IsClassPlaceable;
        public ImportedClassHierarchyEntry[] Children;

        public FoundClassHierarchyEntry CheckForName(string name, List<ImportedClassHierarchyEntry> stack)
        {
            //Check if our name matches
            if (this.Name == name)
            {
                return new FoundClassHierarchyEntry
                {
                    stack = stack,
                    data = this
                };
            }

            //Loop through children
            foreach(var c in Children)
            {
                FoundClassHierarchyEntry entry = c.CheckForName(name, stack);
                if (entry != null)
                {
                    stack.Add(this);
                    return new FoundClassHierarchyEntry
                    {
                        stack = stack,
                        data = entry.data
                    };
                }
            }

            return null;
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public class FoundClassHierarchyEntry
    {
        public ImportedClassHierarchyEntry data;
        public List<ImportedClassHierarchyEntry> stack;

        public bool CheckIfIsSubClassOf(string name)
        {
            foreach(var s in stack)
            {
                if (s.Name == name)
                    return true;
            }
            return false;
        }
    }
}
