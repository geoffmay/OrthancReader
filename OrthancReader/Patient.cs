using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrthancReader
{
    public class Patient
    {

        //        {
        //   "ID" : "6d8b5f03-e9547775-08df23ed-c9c52115-27a30d9f",
        //   "IsStable" : true,
        //   "LastUpdate" : "20190715T234111",
        //   "MainDicomTags" : {
        //      "PatientBirthDate" : "18000101",
        //      "PatientID" : "1.3.46.670589.11.71982.5.0.30772.2019071518405779002",
        //      "PatientName" : "Dicom Test Data",
        //      "PatientSex" : "F"
        //   },
        //   "Studies" : [ "4567af2c-6552c417-662d1ebd-44629c9e-45734902" ],
        //   "Type" : "Patient"
        //}

        public string ID;
        public bool IsStable;
        public string LastUpdate;
        public class MainDicomTagsC
        {
            public string PatientBirthDate;
            public string PatientID;
            public string PatientName;
            public string PatientSex;
        }
        public MainDicomTagsC MainDicomTags;
        public string[] Studies;
        public string Type;
}
}
