using System;
using System.Collections.Generic;
using System.Linq;

namespace NormaCSBinder
{
    /// <summary>
    /// NormaCS Document basic reflection
    /// </summary>
    public class Document
    {
        /// <summary>
        /// Document constructor
        /// </summary>
        /// <param name="origName">Standard name in original file</param>
        /// <param name="doc">NormaCSAPI.Document object</param>
        public Document(string origName, NormaCSAPI.Document doc)
        {
            this.DWGName = origName;
            this.FoundName = doc.Designation;
            this.IsActual = doc.get_IsActual();
            this.URL = doc.URL;
            
            HashSet<NormaCSAPI.Document> replaces = findReplacements(doc);
            if (replaces.Count > 0)
                this.Replaced = Document.convertNormaCSDocList(this.DWGName, replaces);
        }

        public string DWGName { get; set; } // Standard name in original file
        public string FoundName { get; set; } // Standard name in NormaCS Database
        public bool IsActual { get; set; } // Document actuality
        public string URL { get; set; } // URL to NormaCS Database
        public HashSet<Document> Replaced { get; set; } // Replaced documents list

        /// <summary>
        /// Replacements finder for the document
        /// </summary>
        /// <param name="doc">NormaCSAPI.Document object</param>
        /// <returns>Replacements list</returns>
        private HashSet<NormaCSAPI.Document> findReplacements(NormaCSAPI.Document doc)
        {
            HashSet<NormaCSAPI.Document> replacers = new HashSet<NormaCSAPI.Document>();
            NormaCSAPI.Replacements replacedBy = doc.ReplacedBy;

            while (replacedBy.Count > 0)
            {
                foreach (NormaCSAPI.Replacement repl in replacedBy)
                    replacers.Add(repl.get_Document());
                replacedBy = replacers.Last().ReplacedBy;
            }

            return replacers;
        }

        /// <summary>
        /// Converter for NormaCSAPI.Document object into Document
        /// </summary>
        /// <param name="origName">Standard name in original file</param>
        /// <param name="doc">NormaCSAPI.Document object</param>
        /// <returns>Converted Document object</returns>
        public static Document convertNormaCSDocToInnerDoc(string origName, NormaCSAPI.Document doc)
        {
            Document innerDoc = new Document(origName, doc);
            return innerDoc;
        }

        /// <summary>
        /// Converter for NormaCSAPI.Documents list into Document list
        /// </summary>
        /// <param name="origName">Standard name in original file</param>
        /// <param name="nDocs">NormaCSAPI.Document list</param>
        /// <returns>Converted Document list</returns>
        public static HashSet<Document> convertNormaCSDocList(string origName, IEnumerable<NormaCSAPI.Document> nDocs)
        {
            HashSet<Document> docs = new HashSet<Document>();
            foreach(NormaCSAPI.Document nDoc in nDocs)
                docs.Add(Document.convertNormaCSDocToInnerDoc(origName, nDoc));
            return docs;
        }

        /// <summary>
        /// String representer
        /// </summary>
        /// <returns>string represent of Document object</returns>
        public override string ToString()
        {            
            string Replacer = this.Replaced != null ? 
                "Replaced by " + this.Replaced.Last().FoundName : "Actual";
                
            return String.Format("{0} is {1}", this.FoundName, Replacer);
        }
    }
}
