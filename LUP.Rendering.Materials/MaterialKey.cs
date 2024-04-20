using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Rendering.Materials
{
    public class MaterialKey
    {
        public string Key { get; }

        public MaterialKey(string key)
        {
            Key = key;            
        }


        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }


        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
