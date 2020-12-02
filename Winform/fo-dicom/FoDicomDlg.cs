using Dicom;
using Dicom.StructuredReport;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformExamples.fo_dicom
{
	public partial class FoDicomDlg : Form
	{
		public FoDicomDlg()
		{
			InitializeComponent();
		}

		private void FoDicomDlg_Load(object sender, EventArgs e)
		{

		}

		private void btnCreateSRDicom_Click(object sender, EventArgs e)
		{
			string deviceObserverUID = "1.1.1.1.1"; // TODO (121012)
			string studyInstanceUid = "1.1.1.1.1.1.1";
			string seriesInstanceUid = "1.1.1.1.1.1.1.2";
			string accessionNo = "298347982347598";
			int imageCount = 3;

			DateTime now = DateTime.Now;
			string dateTagValue = DateTime.Now.ToString("yyyyMMdd", CultureInfo.InvariantCulture);
			string timeTagValue  = DateTime.Now.ToString("HHmmss", CultureInfo.InvariantCulture);

			DicomDataset seqContent = new DicomDataset(); //Content of the sequence
			DicomDataset ds = new DicomDataset(); //Main dataset
			ds.Add(DicomTag.SpecificCharacterSet, "ISO_IR 100"); //Add some items

			ds.Add(DicomTag.PatientName, "Last^First^Middle=Last2^First2^Middle2=Last3^First3^Middle3");
			ds.Add(DicomTag.PatientID, "ID0001");
			ds.Add(DicomTag.PatientBirthDate, dateTagValue);

			ds.Add(DicomTag.PatientSex, "M");

			ds.Add(DicomTag.StudyDate, dateTagValue);
			ds.Add(DicomTag.StudyTime, timeTagValue);
			ds.Add(DicomTag.AccessionNumber, accessionNo);
			ds.Add(DicomTag.ReferringPhysicianName, "RefPhysicianName Kim");
			ds.Add(DicomTag.StudyDescription, "CHEST");
			ds.Add(DicomTag.StudyInstanceUID, studyInstanceUid);
			ds.Add(DicomTag.StudyID, "0");

			ds.Add(DicomTag.SeriesDate, dateTagValue);
			ds.Add(DicomTag.SeriesTime, timeTagValue);
			ds.Add(DicomTag.Modality, "SR");
			ds.Add(DicomTag.SeriesDescription, "Description");
			ds.Add(DicomTag.SeriesInstanceUID, seriesInstanceUid);
			ds.Add(DicomTag.SeriesNumber, "2");

			ds.Add(DicomTag.Manufacturer, "Manufacturer");
			ds.Add(DicomTag.InstitutionName, "Hospital Name");
			ds.Add(DicomTag.StationName, "Room 1");
			ds.Add(DicomTag.SoftwareVersions, "1.0.0.0");
			ds.Add(DicomTag.ContentDate, dateTagValue);
			ds.Add(DicomTag.ContentTime, timeTagValue);
			ds.Add(DicomTag.InstanceNumber, "1");

			ds.Add(DicomTag.NumberOfStudyRelatedInstances, imageCount);
			ds.Add(DicomTag.ValueType, DicomValueType.Container);

			DicomSequence conceptNameCodeSequence = new DicomSequence(DicomTag.ConceptNameCodeSequence, new DicomCodeItem("113701", "DCM", "X-Ray Radiation Dose Report", "01"));
			ds.Add(conceptNameCodeSequence);

			ds.Add(DicomTag.ContinuityOfContent, DicomContinuity.Separate);

			seqContent.Clear();
			seqContent.Add(DicomTag.AccessionNumber, accessionNo);
			seqContent.Add(DicomTag.StudyInstanceUID, studyInstanceUid);
			seqContent.Add(DicomTag.RequestedProcedureDescription, string.Empty);
			seqContent.Add(DicomTag.RequestedProcedureCodeSequence, new DicomDataset());
			seqContent.Add(DicomTag.RequestedProcedureID, string.Empty);
			seqContent.Add(DicomTag.PlacerOrderNumberImagingServiceRequest, string.Empty);
			seqContent.Add(DicomTag.FillerOrderNumberImagingServiceRequest, string.Empty);

			DicomSequence referenceRequestSequence = new DicomSequence(DicomTag.ReferencedRequestSequence, seqContent);
			ds.Add(referenceRequestSequence);

			ds.Add(DicomTag.PerformedProcedureCodeSequence, new DicomDataset());
			ds.Add(DicomTag.CompletionFlag, "COMPLETE");
			ds.Add(DicomTag.CompletionFlagDescription, "Completed on Study close");
			ds.Add(DicomTag.VerificationFlag, "UNVERIFIED");
			ds.Add(DicomTag.PreliminaryFlag, "FINAL");

			DicomDataset ContentTemplateSequenceDataset = new DicomDataset();
			ContentTemplateSequenceDataset.Add(DicomTag.MappingResource, "DCMR");
			ContentTemplateSequenceDataset.Add(DicomTag.TemplateIdentifier, "10001");
			DicomSequence contentTemplateSequence = new DicomSequence(DicomTag.ContentTemplateSequence, ContentTemplateSequenceDataset);
			ds.Add(contentTemplateSequence);

			seqContent.Clear();

			DicomStructuredReport sr = new DicomStructuredReport(ds);

			{
				DicomContentItem item = new DicomContentItem(
					GetDcmTypeCodeItem(121058, "Procedure reported"),
					DicomRelationship.HasConceptModifier,
					GetDcmTypeCodeItem(113704, "Projection X-Ray"));

				item.Add(new DicomContentItem(
					GetSrtTypeCodeItem("G-C0E8", "Has Intent"),
					DicomRelationship.HasConceptModifier,
					GetSrtTypeCodeItem("R-408C3", "Diagnostic Intent")));

				sr.Add(item);
			}

			sr.Add(new DicomContentItem(
				GetDcmTypeCodeItem(121005, "Observer Type"),
				DicomRelationship.HasObservationContext,
				GetDcmTypeCodeItem(121007, "Device")));

			sr.Add(new DicomContentItem(
				GetDcmTypeCodeItem(121012, "Device Observer UID"),
				DicomRelationship.HasObservationContext,
				DicomUID.Parse("2222222222222222"))); // TODO : set real value

			sr.Add(new DicomContentItem(
				GetDcmTypeCodeItem(121013, "Device Observer Name"),
				DicomRelationship.HasObservationContext,
				DicomValueType.Text,
				"22222222222222222")); // TODO : set real value

			sr.Add(new DicomContentItem(
				GetDcmTypeCodeItem(121014, "Device Observer Manufacturer"),
				DicomRelationship.HasObservationContext,
				DicomValueType.Text,
				"Rayence"));

			sr.Add(new DicomContentItem(
				GetDcmTypeCodeItem(121015, "Device Observer Model Name"),
				DicomRelationship.HasObservationContext,
				DicomValueType.Text,
				"XMARU SERIES")); // TODO : set real value

			sr.Add(new DicomContentItem(
				GetDcmTypeCodeItem(121016, "Device Observer Serial Number"),
				DicomRelationship.HasObservationContext,
				DicomValueType.Text,
				"Unknown")); // TODO : set real value

			sr.Add(new DicomContentItem(
				GetDcmTypeCodeItem(121017, "Device Observer Physical Location During Observation"),
				DicomRelationship.HasObservationContext,
				DicomValueType.Text,
				"Unknown")); // TODO : set real value

			sr.Add(new DicomContentItem(
				GetDcmTypeCodeItem(113876, "Device Role in Procedure"),
				DicomRelationship.HasObservationContext,
				GetDcmTypeCodeItem(121097, "Recording")));

			{
				DicomContentItem item = new DicomContentItem(
					GetDcmTypeCodeItem(113705, "Scope of Accumulation"),
					DicomRelationship.HasObservationContext,
					GetDcmTypeCodeItem(113014, "Study"));

				item.Add(new DicomContentItem(
					GetDcmTypeCodeItem(110180, "Study Instance UID"),
					DicomRelationship.HasProperties,
					DicomUID.Parse(studyInstanceUid)));

				sr.Add(item);
			}

			sr.Add(new DicomContentItem(
				GetDcmTypeCodeItem(113944, "X-Ray Mechanical Data Available"),
				DicomRelationship.Contains,
				GetSrtTypeCodeItem("R-00339", "No")));

			//-------------- TID 10002 ------------------
			{
				DicomContentItem containerItem = new DicomContentItem(
					GetDcmTypeCodeItem(113702, "Accumulated X-Ray Dose Data"),
					DicomRelationship.Contains,
					DicomContinuity.Separate);

				DicomSequence sequence = new DicomSequence(DicomTag.ContentTemplateSequence);

				sequence.Items.Add(new DicomDataset()
					.Add(DicomTag.MappingResource, "DCMR")
					.Add(DicomTag.TemplateIdentifier, "10002"));

				containerItem.Dataset.Add(sequence);

				containerItem.Add(new DicomContentItem(
					GetDcmTypeCodeItem(113764, "Acquisition Plane"),
					DicomRelationship.HasConceptModifier,
					GetDcmTypeCodeItem(113622, "Single Plane")));

				containerItem.Add(new DicomContentItem(
					GetDcmTypeCodeItem(113722, "Dose Area Product Total"),
					DicomRelationship.Contains,
					new DicomMeasuredValue(new Decimal(1.224), // TODO : set real value
					new DicomCodeItem("Gy.m2", "UCUM", "Gy.m2"))));

				containerItem.Add(new DicomContentItem(
					GetDcmTypeCodeItem(113725, "Dose (RP) Total"),
					DicomRelationship.Contains,
					new DicomMeasuredValue(new Decimal(0), // TODO : set real value
					new DicomCodeItem("Gy", "UCUM", "Gy"))));

				containerItem.Add(new DicomContentItem(
					GetDcmTypeCodeItem(113727, "Acquisition Dose Area Product Total"),
					DicomRelationship.Contains,
					new DicomMeasuredValue(new Decimal(1.224), // TODO : set real value
					new DicomCodeItem("Gy.m2", "UCUM", "Gy.m2"))));

				containerItem.Add(new DicomContentItem(
					GetDcmTypeCodeItem(113729, "Acquisition Dose (RP) Total"),
					DicomRelationship.Contains,
					new DicomMeasuredValue(new Decimal(0), // TODO : set real value
					new DicomCodeItem("Gy", "UCUM", "Gy"))));

				containerItem.Add(new DicomContentItem(
					GetDcmTypeCodeItem(113855, "Total Acquisition Time"),
					DicomRelationship.Contains,
					new DicomMeasuredValue(new Decimal(0.672), // TODO : set real value
					new DicomCodeItem("s", "UCUM", "s"))));

				containerItem.Add(new DicomContentItem(
					GetDcmTypeCodeItem(113731, "Total Number of Radiographic Frames"),
					DicomRelationship.Contains,
					new DicomMeasuredValue(new Decimal(imageCount),
					new DicomCodeItem("1", "UCUM", "no units"))));

				containerItem.Add(new DicomContentItem(
					GetDcmTypeCodeItem(113780, "Reference Point Definition"),
					DicomRelationship.Contains,
					DicomValueType.Text,
					"In Detector Plane"));

				DicomContentItem IrradiatingDevice = new DicomContentItem(
					GetDcmTypeCodeItem(113876, "Device Role in Procedure"),
					DicomRelationship.Contains,
					GetDcmTypeCodeItem(113859, "Irradiating Device"));
				{
					IrradiatingDevice.Add(new DicomContentItem(
						GetDcmTypeCodeItem(113877, "Device Name"),
						DicomRelationship.HasProperties,
						DicomValueType.Text,
						"DX3605801"));

					IrradiatingDevice.Add(new DicomContentItem(
						GetDcmTypeCodeItem(113878, "Device Manufacturer"),
						DicomRelationship.HasProperties,
						DicomValueType.Text,
						"Manufacturer"));

					IrradiatingDevice.Add(new DicomContentItem(
						GetDcmTypeCodeItem(113879, "Device Model Name"),
						DicomRelationship.HasProperties,
						DicomValueType.Text,
						"ManufacturerModelName"));

					IrradiatingDevice.Add(new DicomContentItem(
						GetDcmTypeCodeItem(113880, "Device Serial Number"),
						DicomRelationship.HasProperties,
						DicomValueType.Text,
						"Unknown"));

					IrradiatingDevice.Add(new DicomContentItem(
						GetDcmTypeCodeItem(121012, "Device Observer UID"),
						DicomRelationship.HasProperties,
						DicomUID.Parse(deviceObserverUID)));

				}

				containerItem.Add(IrradiatingDevice);

				sr.Add(containerItem);
			}

			//-------------- TID 10003 ------------------



			for (int i = 0; i < imageCount; i++)
			{
				DicomContentItem containerItem = new DicomContentItem(
					GetDcmTypeCodeItem(113706, "Irradiation Event X-Ray Data"),
					DicomRelationship.Contains,
					DicomContinuity.Separate);

				DicomSequence sequence = new DicomSequence(DicomTag.ContentTemplateSequence);

				sequence.Items.Add(new DicomDataset()
					.Add(DicomTag.MappingResource, "DCMR")
					.Add(DicomTag.TemplateIdentifier, "10003"));

				containerItem.Dataset.Add(sequence);

				containerItem.Add(new DicomContentItem(
					GetDcmTypeCodeItem(113764, "Acquisition Plane"),
					DicomRelationship.HasConceptModifier,
					GetDcmTypeCodeItem(113622, "Single Plane")));

				containerItem.Add(new DicomContentItem(
					GetDcmTypeCodeItem(113769, "Irradiation Event UID"),
					DicomRelationship.Contains,
					DicomUID.Parse($"{seriesInstanceUid}.{i}")));

				containerItem.Add(new DicomContentItem(
					GetDcmTypeCodeItem(111526, "DateTime Started"),
					DicomRelationship.Contains,
					DicomValueType.DateTime,
					DateTime.Now));

				containerItem.Add(new DicomContentItem(
					GetDcmTypeCodeItem(113721, "Irradiation Event Type"),
					DicomRelationship.Contains,
					GetDcmTypeCodeItem(113611, "Stationary Acquisition")));

				containerItem.Add(new DicomContentItem(
					GetDcmTypeCodeItem(125203, "Acquisition Protocol"),
					DicomRelationship.Contains,
					DicomValueType.Text,
					"1.1"));

				containerItem.Add(new DicomContentItem(
					GetDcmTypeCodeItem(123014, "Target Region"),
					DicomRelationship.Contains,
					GetSrtTypeCodeItem("Undefin", "ed")));

				containerItem.Add(new DicomContentItem(
					GetDcmTypeCodeItem(122130, "Dose Area Product"),
					DicomRelationship.Contains,
					new DicomMeasuredValue(new Decimal(0.25),
					new DicomCodeItem("Gy.m2", "UCUM", "Gy.m2"))));

				containerItem.Add(new DicomContentItem(
					GetDcmTypeCodeItem(113845, "Exposure Index"),
					DicomRelationship.Contains,
					new DicomMeasuredValue(new Decimal(500),
					new DicomCodeItem("1", "UCUM", "no units"))));

				containerItem.Add(new DicomContentItem(
					GetDcmTypeCodeItem(113846, "Target Exposure Index"),
					DicomRelationship.Contains,
					new DicomMeasuredValue(new Decimal(300),
					new DicomCodeItem("1", "UCUM", "no units"))));

				containerItem.Add(new DicomContentItem(
					GetDcmTypeCodeItem(113738, "Dose (RP)"),
					DicomRelationship.Contains,
					new DicomMeasuredValue(new Decimal(0),
					new DicomCodeItem("Gy", "UCUM", "Gy"))));

				containerItem.Add(new DicomContentItem(
					GetDcmTypeCodeItem(113780, "Reference Point Definition"),
					DicomRelationship.Contains,
					DicomValueType.Text,
					"In Detector Plane"));

				containerItem.Add(new DicomContentItem(
					GetDcmTypeCodeItem(113768, "Number of Pulses"),
					DicomRelationship.Contains,
					new DicomMeasuredValue(new Decimal(1),
					new DicomCodeItem("1", "UCUM", "no units"))));

				containerItem.Add(new DicomContentItem(
					GetDcmTypeCodeItem(113733, "KVP"),
					DicomRelationship.Contains,
					new DicomMeasuredValue(new Decimal(75),
					new DicomCodeItem("kV", "UCUM", "kV"))));

				containerItem.Add(new DicomContentItem(
					GetDcmTypeCodeItem(113736, "Exposure"),
					DicomRelationship.Contains,
					new DicomMeasuredValue(new Decimal(50),
					new DicomCodeItem("uA.s", "UCUM", "uA.s"))));

				DicomContentItem IrradiatingDevice = new DicomContentItem(
					GetDcmTypeCodeItem(113876, "Device Role in Procedure"),
					DicomRelationship.Contains,
					GetDcmTypeCodeItem(113859, "Irradiating Device"));
				{
					IrradiatingDevice.Add(new DicomContentItem(
						GetDcmTypeCodeItem(113877, "Device Name"),
						DicomRelationship.HasProperties,
						DicomValueType.Text,
						"DX3605801"));

					IrradiatingDevice.Add(new DicomContentItem(
						GetDcmTypeCodeItem(113878, "Device Manufacturer"),
						DicomRelationship.HasProperties,
						DicomValueType.Text,
						"Manufacturer"));

					IrradiatingDevice.Add(new DicomContentItem(
						GetDcmTypeCodeItem(113879, "Device Model Name"),
						DicomRelationship.HasProperties,
						DicomValueType.Text,
						"ManufacturerModelName"));

					IrradiatingDevice.Add(new DicomContentItem(
						GetDcmTypeCodeItem(113880, "Device Serial Number"),
						DicomRelationship.HasProperties,
						DicomValueType.Text,
						"Unknown"));

					IrradiatingDevice.Add(new DicomContentItem(
						GetDcmTypeCodeItem(121012, "Device Observer UID"),
						DicomRelationship.HasProperties,
						DicomUID.Parse(deviceObserverUID)));
				}

				containerItem.Add(IrradiatingDevice);
				sr.Add(containerItem);
			}

			sr.Add(new DicomContentItem(
				GetDcmTypeCodeItem(113854, "Source of Dose Information"),
				DicomRelationship.Contains,
				GetSrtTypeCodeItem("A-2C090", "Dosimeter")));

			DicomFile file = new DicomFile();

			file.FileMetaInfo.AddOrUpdate(DicomTag.MediaStorageSOPClassUID, DicomUID.Parse("1.2.840.10008.5.1.4.1.1.88.67"));
			file.FileMetaInfo.AddOrUpdate(DicomTag.MediaStorageSOPInstanceUID, DicomUID.Parse("1.2.840.10008.1.2.1"));
			file.FileMetaInfo.AddOrUpdate(DicomTag.ImplementationClassUID, "1.2.410.200067.141");
			file.FileMetaInfo.AddOrUpdate(DicomTag.SourceApplicationEntityTitle, "Rayence");

			file.Dataset.Add(ds);
			file.FileMetaInfo.TransferSyntax = DicomTransferSyntax.ImplicitVRLittleEndian;
			file.Save("SR.dcm");

			System.Diagnostics.Process.Start("SR.dcm");
		}

		private DicomCodeItem GetSrtTypeCodeItem(string codeValue, string codeMeaning)
		{
			return new DicomCodeItem(codeValue, "SRT", codeMeaning, "01");
		}

		private DicomCodeItem GetDcmTypeCodeItem(int codeValue, string codeMeaning)
		{
			return new DicomCodeItem(codeValue.ToString(), "DCM", codeMeaning, "01");
		}

		private DicomCodeItem GetCodeItem(int codeValue, string codeMeaning, string schemeDesigner, string schemeVersion)
		{
			return new DicomCodeItem(codeValue.ToString(), schemeDesigner, codeMeaning, schemeVersion);
		}
	}
}
