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

using System;
using System.Security.Cryptography.Xml;
using System.Xml;

namespace Microsoft.Xades
{
	/// <summary>
	/// This class includes the name of the server that has produced the
	/// referenced response (ResponderID element) and the time indication in
	/// the "ProducedAt" field of the referenced response (ProducedAt element).
	/// The optional URI attribute could serve to indicate where the OCSP
	/// response identified is archived.
	/// </summary>
	public class OCSPIdentifier
	{
		#region Private variables
		private string uriAttribute;
		private string responderID;
		private DateTime producedAt;
		#endregion

		#region Public properties
		/// <summary>
		/// The optional URI attribute could serve to indicate where the OCSP
		/// response is archived
		/// </summary>
		public string UriAttribute
		{
			get
			{
				return this.uriAttribute;
			}
			set
			{
				this.uriAttribute = value;
			}
		}

		/// <summary>
		/// The ID of the server that has produced the referenced response
		/// </summary>
		public string ResponderID
		{
			get
			{
				return this.responderID;
			}
			set
			{
				this.responderID = value;
			}
		}

		/// <summary>
		/// Time indication in the referenced response
		/// </summary>
		public DateTime ProducedAt
		{
			get
			{
				return this.producedAt;
			}
			set
			{
				this.producedAt = value;
			}
		}


        /// <summary>
        /// Identifier is by key
        /// </summary>
        public bool ByKey
        {
            get;
            set;
        }

		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor
		/// </summary>
		public OCSPIdentifier()
		{
			this.producedAt = DateTime.MinValue;
		}
		#endregion

		#region Public methods
		/// <summary>
		/// Check to see if something has changed in this instance and needs to be serialized
		/// </summary>
		/// <returns>Flag indicating if a member needs serialization</returns>
		public bool HasChanged()
		{
			bool retVal = false;

			if (!String.IsNullOrEmpty(this.uriAttribute))
			{
				retVal = true;
			}

			if (!String.IsNullOrEmpty(this.responderID))
			{
				retVal = true;
			}

			if (this.producedAt != DateTime.MinValue)
			{
				retVal = true;
			}

			return retVal;
		}

		/// <summary>
		/// Load state from an XML element
		/// </summary>
		/// <param name="xmlElement">XML element containing new state</param>
		public void LoadXml(System.Xml.XmlElement xmlElement)
		{
			XmlNamespaceManager xmlNamespaceManager;
			XmlNodeList xmlNodeList;
			
			if (xmlElement == null)
			{
				throw new ArgumentNullException("xmlElement");
			}
			if (xmlElement.HasAttribute("URI"))
			{
				this.uriAttribute = xmlElement.GetAttribute("URI");
			}

			xmlNamespaceManager = new XmlNamespaceManager(xmlElement.OwnerDocument.NameTable);
            xmlNamespaceManager.AddNamespace("xades", XadesSignedXml.XadesNamespaceUri);

			xmlNodeList = xmlElement.SelectNodes("xades:ResponderID", xmlNamespaceManager);
			if (xmlNodeList.Count != 0)
			{
				//this.responderID = xmlNodeList.Item(0).InnerText;
                XmlNode child = xmlNodeList.Item(0).ChildNodes.Item(0);

                ByKey = child.Name.Contains("ByKey");
                responderID = child.InnerText;
			}

			xmlNodeList = xmlElement.SelectNodes("xades:ProducedAt", xmlNamespaceManager);
			if (xmlNodeList.Count != 0)
			{
				this.producedAt = XmlConvert.ToDateTime(xmlNodeList.Item(0).InnerText, XmlDateTimeSerializationMode.Local);
			}
		}

		/// <summary>
		/// Returns the XML representation of the this object
		/// </summary>
		/// <returns>XML element containing the state of this object</returns>
		public XmlElement GetXml()
		{
			XmlDocument creationXmlDocument;
			XmlElement retVal;
			XmlElement bufferXmlElement;

			creationXmlDocument = new XmlDocument();
			retVal = creationXmlDocument.CreateElement(XadesSignedXml.XmlXadesPrefix, "OCSPIdentifier", XadesSignedXml.XadesNamespaceUri);
            retVal.SetAttribute("xmlns:ds", SignedXml.XmlDsigNamespaceUrl);

            if (!string.IsNullOrEmpty(uriAttribute))
            {
                retVal.SetAttribute("URI", this.uriAttribute);
            }

			if (!String.IsNullOrEmpty(this.responderID))
			{
				bufferXmlElement = creationXmlDocument.CreateElement(XadesSignedXml.XmlXadesPrefix, "ResponderID", XadesSignedXml.XadesNamespaceUri);
                bufferXmlElement.SetAttribute("xmlns:ds", SignedXml.XmlDsigNamespaceUrl);

                XmlElement bufferXmlElement2 = null;

                if (!ByKey && ResponderID.Contains(","))
                {
                    bufferXmlElement2 = creationXmlDocument.CreateElement(XadesSignedXml.XmlXadesPrefix, "ByName", XadesSignedXml.XadesNamespaceUri);
                }
                else
                {
                    bufferXmlElement2 = creationXmlDocument.CreateElement(XadesSignedXml.XmlXadesPrefix, "ByKey", XadesSignedXml.XadesNamespaceUri);
                }

                bufferXmlElement2.SetAttribute("xmlns:ds", SignedXml.XmlDsigNamespaceUrl);
                bufferXmlElement2.InnerText = this.ResponderID;
                
                bufferXmlElement.AppendChild(bufferXmlElement2);

				retVal.AppendChild(bufferXmlElement);
			}

			if (this.producedAt != DateTime.MinValue)
			{
				bufferXmlElement = creationXmlDocument.CreateElement(XadesSignedXml.XmlXadesPrefix, "ProducedAt", XadesSignedXml.XadesNamespaceUri);

                DateTime truncatedDateTime = this.producedAt.AddTicks(-(this.producedAt.Ticks % TimeSpan.TicksPerSecond));

                bufferXmlElement.InnerText = XmlConvert.ToString(truncatedDateTime, XmlDateTimeSerializationMode.Local);        

                bufferXmlElement.SetAttribute("xmlns:ds", SignedXml.XmlDsigNamespaceUrl);
				retVal.AppendChild(bufferXmlElement);
			}

			return retVal;
		}
		#endregion
	}
}
