using System;
using System.Collections.Generic;
using System.Linq;

namespace NormaCSBinder
{
    /// <summary>
    /// Main class to check documents
    /// </summary>
    public class NormaCS
    {
        /// <summary>
        /// NormaCS Constructor
        /// </summary>
        /// <param name="standards">standards list to check</param>
        public NormaCS(HashSet<Standard> standards) 
        {
            this.Standards = standards;
            this.Documents = new HashSet<Document>();           
        }

        public HashSet<Document> Documents { get; set; } // Found documents
        public HashSet<Standard> Standards { get; set; } // Standards to check

        /// <summary>
        /// Check list of Standards against NormaCS Database
        /// </summary>
        public void checkStandards()
        {
            foreach (Standard standard in this.Standards)
                this.Documents.UnionWith(standard.Check());
        }
    }
}
