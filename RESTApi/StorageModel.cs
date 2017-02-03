using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTApi
{
    public class StorageModel
    {
        public List<string> Mood { get; set; }

        public DateTime DateTime => DateTime.UtcNow;
    }

    public class EmotionResultDisplay
    {
        public string EmotionString
        {
            get;
            set;
        }
        public float Score
        {
            get;
            set;
        }

        public int OriginalIndex
        {
            get;
            set;
        }
    }
}
