using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NormaCSBinder
{
    /// <summary>
    /// Standard base class
    /// </summary>
    public class Standard
    {
        /// <summary>
        /// Standard constructor
        /// </summary>
        /// <param name="index">Standard Index</param>
        /// <param name="number">Standard Number</param>
        public Standard(string index, string number)
        {
            this.Index = index;
            this.Number = number;
            this.HasNormaCSReference = false;
        }

        public string Index { get; set; } // Standard Index
        public string Number { get; set; } // Standard Number
        public bool HasNormaCSReference { get; set; } // Standard found in NormaCS Database
        public string OriginalName // Standard name in original document
        {
            get 
            {
                return this.Index + " " + this.Number;
            }
        }

        /// <summary>
        /// Check document against NormaCS Database
        /// </summary>
        /// <returns>Found documents</returns>
        public HashSet<Document> Check()
        {
            HashSet<NormaCSAPI.Document> nDocs = Checker.findDocument(this.Index, this.Number);
            HashSet<Document> docs = new HashSet<Document>();
            if (nDocs.Count > 0)
            {
                docs = Document.convertNormaCSDocList(OriginalName, nDocs);
                this.HasNormaCSReference = true;
            }
            return docs;
        }

        /// <summary>
        /// String representer
        /// </summary>
        /// <returns>String representation of Standard object</returns>
        public override string ToString()
        {
            return this.OriginalName;
        }
    }
}
