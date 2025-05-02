// CertRefs.cs
//
// XAdES Starter Kit for Microsoft .NET 3.5 (and above)
// 2010 Microsoft France
//
// Originally published under the CECILL-B Free Software license agreement,
// modified by Dpto. de Nuevas Tecnologías de la Dirección General de Urbanismo del Ayto. de Cartagena
// and published under the GNU Lesser General Public License version 3.
// 
// This program is free software: you can redistribute it and/or modify
// it under the +terms of the GNU Lesser General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public License
// along with this program.  If not, see http://www.gnu.org/licenses/. 

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
