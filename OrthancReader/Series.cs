using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrthancReader
{
    public class Series
    {
        public string ExpectedNumberOfInstances;
        public string ID;
        public string[] Instances;
        public bool IsStable;
        public string LastUpdate;
        public class MainDicomTagsSeries
        {
            public string BodyPartExamined;
            public string ContrastBolusAgent;
            public string Manufacturer;
            public string Modality;
            public string OperatorsName;
            public string PerformedProcedureStepDescription;
            public string ProtocolName;
            public string SeriesName;
            public string SeriesDate;
            public string SeriesDescription;
            public string SeriesInstanceUID;
            public string SeriesNumber;
            public string SeriesTime;
            public string StationName;
        }
        public MainDicomTagsSeries MainDicomTags;
        public string ParentStudy;
        public string Status;
        public string Type;
        //        {
        //   "ExpectedNumberOfInstances" : null,
        //   "ID" : "569f77a3-b5ec0d48-cea39272-9c96ad73-86bd7158",
        //   "Instances" : [ "8c0b31c8-47f440fe-3233bfea-543bb8d9-63e85c7a" ],
        //   "IsStable" : true,
        //   "LastUpdate" : "20190715T234110",
        //   "MainDicomTags" : {
        //      "BodyPartExamined" : "",
        //      "ContrastBolusAgent" : "",
        //      "Manufacturer" : "Philips",
        //      "Modality" : "MR",
        //      "OperatorsName" : "",
        //      "PerformedProcedureStepDescription" : "",
        //      "ProtocolName" : "DicomConfigSC_184057.703",
        //      "SeriesDate" : "20190715",
        //      "SeriesDescription" : "DicomConfigSC_184057.703",
        //      "SeriesInstanceUID" : "1.3.46.670589.11.71982.5.0.30772.2019071518405810023",
        //      "SeriesNumber" : "1",
        //      "SeriesTime" : "184057.703",
        //      "StationName" : ""
        //   },
        //   "ParentStudy" : "4567af2c-6552c417-662d1ebd-44629c9e-45734902",
        //   "Status" : "Unknown",
        //   "Type" : "Series"
        //}

    }
}
