using System;
using System.Collections.Generic;
using System.Linq;

namespace NormaCSBinder
{
    /// <summary>
    /// Static standard checker.
    /// Binder to NormaCS COM API
    /// </summary>
    public class Checker
    {
        private static NormaCSAPI.Application App = new NormaCSAPI.Application(); // NormaCS Application
        private static NormaCSAPI.Find Find = App.Find; // NormaCSAPI.Find - main search API
        
        /// <summary>
        /// Search for document in NormaCS Database
        /// </summary>
        /// <param name="index">Document Index</param>
        /// <param name="number">Document Number</param>
        /// <returns>Found documents</returns>
        public static HashSet<NormaCSAPI.Document> findDocument(string index, string number)
        {
            Find.set_Index(index);
            Find.set_Number(number);
            
            HashSet<NormaCSAPI.Document> nDocs = new HashSet<NormaCSAPI.Document>();
            Find.Execute();

            foreach (NormaCSAPI.Document nDoc in Find.Documents)
                nDocs.Add(nDoc);

            Find.Reset();

            return nDocs;
        }
    }
}
