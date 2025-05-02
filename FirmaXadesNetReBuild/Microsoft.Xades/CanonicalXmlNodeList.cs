//
// XAdES Starter Kit for Microsoft .NET 3.5 (and above)
// 2010 Microsoft France
// Published under the CECILL-B Free Software license agreement.
// (http://www.cecill.info/licences/Licence_CeCILL-B_V1-en.txt)
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// WHETHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
// THE ENTIRE RISK OF USE OR RESULTS IN CONNECTION WITH THE USE OF THIS CODE 
// AND INFORMATION REMAINS WITH THE USER. 
//

namespace System.Security.Cryptography.Xml
{
    using System;
    using System.Xml;
    using System.IO;
    using System.Text;
    using System.Collections;

    internal class CanonicalXmlNodeList : XmlNodeList, IList
    {
        private ArrayList m_nodeArray;

        internal CanonicalXmlNodeList()
        {
            m_nodeArray = new ArrayList();
        }

        public override XmlNode Item(int index)
        {
            return (XmlNode)m_nodeArray[index];
        }

        public override IEnumerator GetEnumerator()
        {
            return m_nodeArray.GetEnumerator();
        }

        public override int Count
        {
            get { return m_nodeArray.Count; }
        }

        // IList methods
        public int Add(Object value)
        {
            if (!(value is XmlNode))
                throw new ArgumentException(SecurityResources.GetResourceString("Cryptography_Xml_IncorrectObjectType"), "node");
            return m_nodeArray.Add(value);
        }

        public void Clear()
        {
            m_nodeArray.Clear();
        }

        public bool Contains(Object value)
        {
            return m_nodeArray.Contains(value);
        }

        public int IndexOf(Object value)
        {
            return m_nodeArray.IndexOf(value);
        }

        public void Insert(int index, Object value)
        {
            if (!(value is XmlNode))
                throw new ArgumentException(SecurityResources.GetResourceString("Cryptography_Xml_IncorrectObjectType"), "value");
            m_nodeArray.Insert(index, value);
        }

        public void Remove(Object value)
        {
            m_nodeArray.Remove(value);
        }

        public void RemoveAt(int index)
        {
            m_nodeArray.RemoveAt(index);
        }

        public Boolean IsFixedSize
        {
            get { return m_nodeArray.IsFixedSize; }
        }

        public Boolean IsReadOnly
        {
            get { return m_nodeArray.IsReadOnly; }
        }

        Object IList.this[int index]
        {
            get { return m_nodeArray[index]; }
            set
            {
                if (!(value is XmlNode))
                    throw new ArgumentException(SecurityResources.GetResourceString("Cryptography_Xml_IncorrectObjectType"), "value");
                m_nodeArray[index] = value;
            }
        }

        public void CopyTo(Array array, int index)
        {
            m_nodeArray.CopyTo(array, index);
        }

        public Object SyncRoot
        {
            get { return m_nodeArray.SyncRoot; }
        }

        public bool IsSynchronized
        {
            get { return m_nodeArray.IsSynchronized; }
        }
    }
}
