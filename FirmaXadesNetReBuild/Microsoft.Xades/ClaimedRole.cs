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

using System.Xml;

namespace Microsoft.Xades
{
	/// <summary>
	/// This class contains a roles claimed by the signer but not it is not a
	/// certified role
	/// </summary>
	public class ClaimedRole
	{
		#region Private variables
		private XmlElement anyXmlElement;
		private string innerText;
		#endregion

		#region Public properties
		/// <summary>
		/// The generic XML element that represents a claimed role
		/// </summary>
		public XmlElement AnyXmlElement
		{
			get
			{
				return this.anyXmlElement;
			}
			set
			{
				this.anyXmlElement = value;
			}
		}

		public string InnerText
		{
			get
			{
				return this.innerText;
			}

			set
			{
				this.innerText = value;
			}
		}
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor
		/// </summary>
		public ClaimedRole()
		{
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

			if (this.anyXmlElement != null)
			{
				retVal = true;
			}

            if (!string.IsNullOrEmpty(this.innerText))
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
			this.anyXmlElement = xmlElement;
            this.innerText = xmlElement.InnerText;
		}

		/// <summary>
		/// Returns the XML representation of the this object
		/// </summary>
		/// <returns>XML element containing the state of this object</returns>
		public XmlElement GetXml()
		{
			XmlDocument creationXmlDocument;
			XmlElement retVal;

			creationXmlDocument = new XmlDocument();
			retVal = creationXmlDocument.CreateElement(XadesSignedXml.XmlXadesPrefix, "ClaimedRole", XadesSignedXml.XadesNamespaceUri);

			if (!string.IsNullOrEmpty(this.innerText))
			{
				retVal.InnerText = this.innerText;
			}

			if (this.anyXmlElement != null)
			{
				retVal.AppendChild(creationXmlDocument.ImportNode(this.anyXmlElement, true));
			}

			return retVal;
		}
		#endregion
	}
}
