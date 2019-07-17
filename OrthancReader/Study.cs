using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrthancReader
{
    public class Study
    {

        public string ID;
        public bool IsStable;
        public string LastUpdate;
        public class MainDicomTagsStudy
        {
            public string AccessionNumber;
            public string InstitutionName;
            public string ReferringPhysicianName;
            public string RequestedProcedureDescription;
            public string RequestingPhysician;
            public string StudyDate;
            public string StudyID;
            public string StudyInstanceID;
            public string StudyTime;
        }
        public MainDicomTagsStudy MainDicomTags;
        public string ParentPatient;
        public Patient.MainDicomTagsC PatientMainDicomTags;
        public string[] Series;
        public string Type;

    }
}

        //        {
        //   "ID" : "8b3f5161-07c72bd5-e1b7c388-e2831da2-87bfb8c1",
        //   "IsStable" : false,
        //   "LastUpdate" : "20190716T235216",
        //   "MainDicomTags" : {
        //      "AccessionNumber" : "",
        //      "InstitutionName" : "VA Medical Center",
        //      "ReferringPhysicianName" : "",
        //      "RequestedProcedureDescription" : "",
        //      "RequestingPhysician" : "",
        //      "StudyDate" : "20190716",
        //      "StudyDescription" : "",
        //      "StudyID" : "600644311",
        //      "StudyInstanceUID" : "1.3.46.670589.11.71982.5.0.11348.2019071616383182002",
        //      "StudyTime" : "163831"
        //   },
        //   "ParentPatient" : "4aac1196-31707dd2-56ea28d4-7fb6cb40-a3e92f54",
        //   "PatientMainDicomTags" : {
        //      "PatientBirthDate" : "19810101",
        //      "PatientID" : "PHANTOMNETZ",
        //      "PatientName" : "PHANTOMNETZ",
        //      "PatientSex" : "O"
        //   },
        //   "Series" : [
        //      "38ba8c40-d740c06c-cd639296-00613d4b-fd3fdd92",
        //      "bf0b3d31-09240883-b13a7d4c-f01d6f65-44d52de9",
        //      "be59a27d-44401e2c-d8d6e353-96782bc6-f23534d4",
        //      "d3bcf43c-bd84dfc1-5ed78c95-a352a79c-372f6a66",
        //      "0ef5ff26-a4f51a42-fbf314ec-1640d5ea-ccc3c5f6",
        //      "1da45cb2-faf897ee-0de2ad78-8df8304d-dc84f540",
        //      "8e38eb3a-f2321828-b338f6e0-88f3dd91-3b18c917",
        //      "4a449306-e83970e0-4d9fed35-a5123b5c-2a447c58",
        //      "d45da828-2719bbc2-8f789948-876cdbf4-265b5823",
        //      "3ec19d09-bafd0871-0d23b840-d5ea9b73-99a07287",
        //      "baf7ff32-7ea57d72-f0f55039-d0d2fe04-d1128592",
        //      "9da4fcb9-6fcfe736-3d0495c3-da62ecee-44f3445e",
        //      "4fd5c8f2-34419e83-8207c484-c8feea00-ac2e8689",
        //      "02708f4e-27e065c8-ab66c0e6-ce6a77e0-429121bf",
        //      "4dfc0935-462b5c3a-7987967c-eaf54496-819329d8",
        //      "dc5b9534-b71ed573-bc434352-bcaa7a10-cbe62f6c",
        //      "da9728ce-3cab1bda-7ec0dbb9-03b8223a-2dfc167f",
        //      "e098db5b-058dbef7-810bac70-e277ffad-515cc841"
        //   ],
        //   "Type" : "Study"
        //}
