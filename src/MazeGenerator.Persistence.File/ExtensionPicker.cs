using System.Collections.Generic;
using System.Linq;

namespace MazeGenerator.Persistence.File
{
    public class ExtensionPicker
    {
        private readonly Dictionary<string, string> typeMap;

        public ExtensionPicker()
        {
            this.typeMap = new Dictionary<string, string>
            {
                { "image", "jpeg" }
            };
        }

        public string GetExtensionByType(string type)
        {
            string extension = null;
            if (this.typeMap.TryGetValue(type, out extension))
            {
                return extension;
            }

            return type;
        }

        public string GetTypeByExtension(string extension)
        {
            foreach (KeyValuePair<string, string> pair in typeMap)
            {
                if (pair.Value == extension)
                {
                    return pair.Key;
                }
            }

            return null;
        }
    }
}