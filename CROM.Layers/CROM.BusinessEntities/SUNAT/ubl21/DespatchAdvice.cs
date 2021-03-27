namespace CROM.BusinessEntities.SUNAT.ubl21
{
    using CROM.BusinessEntities.SUNAT.ubl21.aggregate;
    using CROM.BusinessEntities.SUNAT.ubl21.constans;
    using CROM.BusinessEntities.SUNAT.ubl21.extension;
    using CROM.BusinessEntities.SUNAT.ubl21.interfaces;
    using CROM.BusinessEntities.SUNAT.ubl21.structures;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;


    [Serializable]
    public class DespatchAdvice : IXmlSerializable, IEstructuraXml
    {
        public UblExtensions UblExtensions { get; set; }

        public string UblVersionId { get; set; }

        public string CustomizationId { get; set; }

        public string Id { get; set; }

        public DateTime IssueDate { get; set; }

        public string DespatchAdviceTypeCode { get; set; }

        public string Note { get; set; }

        public OrderReference OrderReference { get; set; }

        public InvoiceDocumentReference AdditionalDocumentReference { get; set; }

        public SignatureCac Signature { get; set; }

        public AccountingSupplierParty DespatchSupplierParty { get; set; }

        public AccountingSupplierParty DeliveryCustomerParty { get; set; }

        public AccountingSupplierParty SellerSupplierParty { get; set; }

        public Shipment Shipment { get; set; }

        public List<DespatchLine> DespatchLines { get; set; }

        public IFormatProvider Formato { get; set; }

        public DespatchAdvice()
        {
            UblExtensions = new UblExtensions();
            OrderReference = new OrderReference();
            AdditionalDocumentReference = new InvoiceDocumentReference();
            Signature = new SignatureCac();
            DespatchSupplierParty = new AccountingSupplierParty();
            DeliveryCustomerParty = new AccountingSupplierParty();
            SellerSupplierParty = new AccountingSupplierParty();
            Shipment = new Shipment();
            DespatchLines = new List<DespatchLine>();
            UblVersionId = string.Empty;
            CustomizationId = string.Empty;
            Formato = new System.Globalization.CultureInfo(Formatos.Cultura);
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            throw new NotImplementedException();
        }

        public void WriteXml(XmlWriter writer)
        {

            // Write the root element.
            writer.WriteStartElement("DespatchAdvice", EspacioNombres.xmlnsDespatchAdvice);

            writer.WriteAttributeString("xmlns", "cac", null,EspacioNombres.cac);
            writer.WriteAttributeString("xmlns", "cbc", null,EspacioNombres.cbc);
            writer.WriteAttributeString("xmlns", "ccts", null,EspacioNombres.ccts);
            writer.WriteAttributeString("xmlns", "ds", null,EspacioNombres.ds);
            writer.WriteAttributeString("xmlns", "ext", null,EspacioNombres.ext);
            writer.WriteAttributeString("xmlns", "qdt", null,EspacioNombres.qdt);
            writer.WriteAttributeString("xmlns", "sac", null,EspacioNombres.sac);
            writer.WriteAttributeString("xmlns", "udt", null,EspacioNombres.udt);
            writer.WriteAttributeString("xmlns", "xsi", null, EspacioNombres.xsi);

            //writer.WriteEndElement();

            #region UBLExtensions

            writer.WriteStartElement("ext","UBLExtensions", EspacioNombres.ext);

            #region UBLExtension

            writer.WriteStartElement("ext","UBlExtension", EspacioNombres.ext);

            #region ExtensionContent

            writer.WriteStartElement("ext", "ExtensionContent", EspacioNombres.ext);

            // En esta zona va el certificado digital.

            writer.WriteEndElement();

            #endregion ExtensionContent

            writer.WriteEndElement();

            #endregion UBLExtension

            writer.WriteEndElement();

            #endregion UBLExtensions

            writer.WriteElementString("UBLVersionID", EspacioNombres.cbc, UblVersionId);
            writer.WriteElementString("CustomizationID", EspacioNombres.cbc, CustomizationId);
            writer.WriteElementString("ID", EspacioNombres.cbc, Id);
            writer.WriteElementString("IssueDate", EspacioNombres.cbc, IssueDate.ToString(Formatos.FormatoFecha));
            writer.WriteElementString("IssueTime", EspacioNombres.cbc, IssueDate.ToString("HH:mm:ss"));
            writer.WriteElementString("DespatchAdviceTypeCode", EspacioNombres.cbc, DespatchAdviceTypeCode);

            if (!string.IsNullOrEmpty(Note))
                writer.WriteElementString("Note", EspacioNombres.cbc, Note);

            #region OrderReference

            if (!string.IsNullOrEmpty(OrderReference.Id))
            {
                writer.WriteStartElement("OrderReference", EspacioNombres.cac);
                {
                    writer.WriteElementString("ID", EspacioNombres.cbc, OrderReference.Id);

                    writer.WriteStartElement("OrderTypeCode", EspacioNombres.cbc);
                    {
                        writer.WriteAttributeString("name", OrderReference.OrderTypeCode.Name);
                        writer.WriteValue(OrderReference.OrderTypeCode.Value);
                    }
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }

            #endregion OrderReference

            #region AdditionalDocumentReference

            if (!string.IsNullOrEmpty(AdditionalDocumentReference.Id))
            {
                writer.WriteStartElement("AdditionalDocumentReference", EspacioNombres.cac);
                {
                    writer.WriteElementString("ID", EspacioNombres.cbc, AdditionalDocumentReference.Id);
                    writer.WriteElementString("DocumentTypeCode", EspacioNombres.cbc, AdditionalDocumentReference.DocumentTypeCode);
                }
                writer.WriteEndElement();
            }

            #endregion AdditionalDocumentReference

            #region Signature

            writer.WriteStartElement("Signature", EspacioNombres.cac);
            {
                writer.WriteElementString("ID", EspacioNombres.cbc, Signature.Id);

                #region SignatoryParty

                writer.WriteStartElement("SignatoryParty", EspacioNombres.cac);
                {
                    writer.WriteStartElement("PartyIdentification", EspacioNombres.cac);
                    writer.WriteElementString("ID", EspacioNombres.cbc, Signature.SignatoryParty.PartyIdentification.Id.Value);
                }
                writer.WriteEndElement();

                #region PartyName

                writer.WriteStartElement("PartyName", EspacioNombres.cac);
                {
                    writer.WriteElementString("Name", EspacioNombres.cbc, Signature.SignatoryParty.PartyName.Name);
                }
                writer.WriteEndElement();

                #endregion PartyName

                writer.WriteEndElement();

                #endregion SignatoryParty

                #region DigitalSignatureAttachment

                writer.WriteStartElement("DigitalSignatureAttachment", EspacioNombres.cac);
                {
                    writer.WriteStartElement("ExternalReference", EspacioNombres.cac);
                    {
                        writer.WriteElementString("URI", EspacioNombres.cbc, Signature.DigitalSignatureAttachment.ExternalReference.Uri.Trim());
                    }
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();

                #endregion DigitalSignatureAttachment
            }

            writer.WriteEndElement();

            #endregion Signature

            #region DespatchSupplierParty

            writer.WriteStartElement("DespatchSupplierParty", EspacioNombres.cac);
            {
                writer.WriteStartElement("CustomerAssignedAccountID", EspacioNombres.cbc);
                {
                    writer.WriteAttributeString("schemeID", DespatchSupplierParty.AdditionalAccountId);
                    writer.WriteValue(DespatchSupplierParty.CustomerAssignedAccountId);
                }
                writer.WriteEndElement();

                writer.WriteStartElement("Party", EspacioNombres.cac);
                {
                    writer.WriteStartElement("PartyLegalEntity", EspacioNombres.cac);
                    {
                        writer.WriteElementString("RegistrationName", EspacioNombres.cbc, DespatchSupplierParty.Party.PartyLegalEntity.RegistrationName);
                    }
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            writer.WriteEndElement();

            #endregion DespatchSupplierParty

            #region DeliveryCustomerParty

            writer.WriteStartElement("DeliveryCustomerParty", EspacioNombres.cac);
            {
                writer.WriteStartElement("CustomerAssignedAccountID", EspacioNombres.cbc);
                {
                    writer.WriteAttributeString("schemeID", DeliveryCustomerParty.AdditionalAccountId);
                    writer.WriteValue(DeliveryCustomerParty.CustomerAssignedAccountId);
                }
                writer.WriteEndElement();

                writer.WriteStartElement("Party", EspacioNombres.cac);
                {
                    writer.WriteStartElement("PartyLegalEntity", EspacioNombres.cac);
                    {
                        writer.WriteElementString("RegistrationName", EspacioNombres.cbc, DeliveryCustomerParty.Party.PartyLegalEntity.RegistrationName);
                    }
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            writer.WriteEndElement();

            #endregion DeliveryCustomerParty

            #region SellerSupplierParty

            if (!string.IsNullOrEmpty(SellerSupplierParty.AdditionalAccountId))
            {
                writer.WriteStartElement("SellerSupplierParty", EspacioNombres.cac);
                {
                    writer.WriteStartElement("CustomerAssignedAccountID", EspacioNombres.cbc);
                    {
                        writer.WriteAttributeString("schemeID", SellerSupplierParty.AdditionalAccountId);
                        writer.WriteValue(SellerSupplierParty.CustomerAssignedAccountId);
                    }
                    writer.WriteEndElement();

                    writer.WriteStartElement("Party", EspacioNombres.cac);
                    {
                        writer.WriteStartElement("PartyLegalEntity", EspacioNombres.cac);
                        {
                            writer.WriteElementString("RegistrationName", EspacioNombres.cbc, SellerSupplierParty.Party.PartyLegalEntity.RegistrationName);
                        }
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }

            #endregion SellerSupplierParty

            #region Shipment

            writer.WriteStartElement("Shipment", EspacioNombres.cac);
            {
                writer.WriteElementString("HandlingCode", EspacioNombres.cbc, Shipment.HandlingCode);
                writer.WriteElementString("Information", EspacioNombres.cbc, Shipment.Information);
                writer.WriteElementString("SplitConsignmentIndicator", EspacioNombres.cbc, Shipment.SplitConsignmentIndicator.ToString().ToLower());

                writer.WriteStartElement("GrossWeightMeasure", EspacioNombres.cbc);
                {
                    writer.WriteAttributeString("unitCode", Shipment.GrossWeightMeasure.UnitCode);
                    writer.WriteValue(Shipment.GrossWeightMeasure.Value.ToString(Formatos.FormatoNumerico, Formato));
                }
                writer.WriteEndElement();
                writer.WriteElementString("TotalTransportHandlingUnitQuantity", EspacioNombres.cbc, Shipment.TotalTransportHandlingUnitQuantity.ToString());

                #region ShipmentStages

                foreach (var shipmentStage in Shipment.ShipmentStages)
                {
                    writer.WriteElementString("ID", EspacioNombres.cbc, shipmentStage.Id.ToString());
                    writer.WriteElementString("TransportModeCode", EspacioNombres.cbc, shipmentStage.TransportModeCode);

                    writer.WriteStartElement("TransitPeriod", EspacioNombres.cac);
                    {
                        writer.WriteElementString("StartDate", EspacioNombres.cbc, shipmentStage.TransitPeriodStartPeriod.ToString(Formatos.FormatoFecha));
                    }
                    writer.WriteEndElement();

                    if (!string.IsNullOrEmpty(shipmentStage.CarrierParty.PartyIdentification.Id.Value))
                    {
                        writer.WriteStartElement("CarrierParty", EspacioNombres.cac);
                        {
                            writer.WriteStartElement("PartyIdentification", EspacioNombres.cac);
                            {
                                writer.WriteStartElement("ID", EspacioNombres.cbc);
                                {
                                    writer.WriteAttributeString("schemeID",
                                        shipmentStage.CarrierParty.PartyIdentification.Id.SchemeId);
                                    writer.WriteValue(shipmentStage.CarrierParty.PartyIdentification.Id.Value);
                                }
                                writer.WriteEndElement();
                            }
                            writer.WriteEndElement();
                            writer.WriteElementString("RegistrationName", EspacioNombres.cbc, shipmentStage.CarrierParty.PartyLegalEntity.RegistrationName);
                        }
                        writer.WriteEndElement();
                    }

                    writer.WriteStartElement("TransportMeans", EspacioNombres.cac);
                    {
                        writer.WriteStartElement("RoadTransport", EspacioNombres.cac);
                        {
                            writer.WriteElementString("LicensePlateID", EspacioNombres.cbc, shipmentStage.TransportMeans.LicensePlateId);
                        }
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();

                    writer.WriteStartElement("DriverPerson", EspacioNombres.cac);
                    {
                        writer.WriteStartElement("ID", EspacioNombres.cbc);
                        {
                            writer.WriteAttributeString("schemeID", shipmentStage.DriverPerson.Id.SchemeId);
                            writer.WriteValue(shipmentStage.DriverPerson.Id.Value);
                        }
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                }

                #endregion ShipmentStages

                #region DeliveryAddress

                writer.WriteStartElement("DeliveryAddress", EspacioNombres.cac);
                {
                    writer.WriteElementString("ID", EspacioNombres.cbc, Shipment.DeliveryAddress.Id);
                    writer.WriteElementString("StreetName", EspacioNombres.cbc, Shipment.DeliveryAddress.StreetName);
                }
                writer.WriteEndElement();

                #endregion DeliveryAddress

                #region TransportHandlingUnit

                writer.WriteStartElement("TransportHandlingUnit", EspacioNombres.cac);
                {
                    // Se repite la misma placa del primer vehiculo
                    writer.WriteElementString("ID", EspacioNombres.cbc, Shipment.ShipmentStages.First().TransportMeans.LicensePlateId);
                    foreach (var transportEquipment in Shipment.TransportHandlingUnit.TransportEquipments)
                    {
                        if (string.IsNullOrEmpty(transportEquipment.Id)) continue;
                        writer.WriteStartElement("TransportEquipment", EspacioNombres.cac);
                        {
                            writer.WriteElementString("ID", EspacioNombres.cbc, transportEquipment.Id);
                        }
                        writer.WriteEndElement();
                    }
                }
                writer.WriteEndElement();

                #endregion TransportHandlingUnit

                #region OriginAddress

                writer.WriteStartElement("OriginAddress", EspacioNombres.cac);
                {
                    writer.WriteElementString("ID", EspacioNombres.cbc, Shipment.OriginAddress.Id);
                    writer.WriteElementString("StreetName", EspacioNombres.cbc, Shipment.OriginAddress.StreetName);
                }
                writer.WriteEndElement();

                #endregion OriginAddress

                #region FirstArrivalPortLocation

                if (!string.IsNullOrEmpty(Shipment.FirstArrivalPortLocationId))
                {
                    writer.WriteStartElement("FirstArrivalPortLocation", EspacioNombres.cac);
                    {
                        writer.WriteElementString("ID", EspacioNombres.cbc, Shipment.FirstArrivalPortLocationId);
                    }
                    writer.WriteEndElement();
                }

                #endregion FirstArrivalPortLocation
            }
            writer.WriteEndElement();

            #endregion Shipment

            #region DespatchLine

            foreach (var despatchLine in DespatchLines)
            {
                writer.WriteStartElement("DespatchLine", EspacioNombres.cac);
                {
                    writer.WriteElementString("ID", EspacioNombres.cbc, despatchLine.Id.ToString());

                    writer.WriteStartElement("DeliveredQuantity", EspacioNombres.cbc);
                    {
                        writer.WriteAttributeString("unitCode", despatchLine.DeliveredQuantity.UnitCode);
                        writer.WriteValue(despatchLine.DeliveredQuantity.Value.ToString(Formatos.FormatoNumerico, Formato));
                    }
                    writer.WriteEndElement();

                    if (despatchLine.OrderLineReferenceId > 0)
                    {
                        writer.WriteStartElement("OrderLineReference", EspacioNombres.cac);
                        {
                            writer.WriteElementString("LineID", EspacioNombres.cbc, despatchLine.OrderLineReferenceId.ToString());
                        }
                        writer.WriteEndElement();
                    }

                    writer.WriteStartElement("Item", EspacioNombres.cac);
                    {
                        writer.WriteElementString("Description", EspacioNombres.cbc, despatchLine.Item.Description);

                        writer.WriteStartElement("SellersItemIdentification", EspacioNombres.cac);
                        {
                            writer.WriteElementString("ID", EspacioNombres.cbc, despatchLine.Item.SellersIdentificationId);
                        }
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }

            #endregion DespatchLine

            // Write the close tag for the root element.
            writer.WriteEndElement();

            // Write the XML to file and close the writer.
            writer.Flush();
            writer.Close();
        }
    }
}
