using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrthancReader
{
    public class Instance
    {
        public string FileSize;
        public string FileUuid;
        public string ID;
        public int IndexInSeries;
        public class MainDicomTagsInstance
        {
            public string AcquisitionNumber;
            public string ImageComments;
            public string InstanceCreationDate;
            public string InstanceCreationTime;
            public string InstanceNumber;
            public string SOPInstanceUID;
        }
        public MainDicomTagsInstance MainDicomTags;
        public string ParentSeries;
        public string Type;

        //        {
        //   "FileSize" : 381278,
        //   "FileUuid" : "0010d59c-1d1a-4ace-bb7c-a548985bf2ef",
        //   "ID" : "8c0b31c8-47f440fe-3233bfea-543bb8d9-63e85c7a",
        //   "IndexInSeries" : -1,
        //   "MainDicomTags" : {
        //      "AcquisitionNumber" : "0",
        //      "ImageComments" : "",
        //      "InstanceCreationDate" : "20190715",
        //      "InstanceCreationTime" : "184059.219",
        //      "InstanceNumber" : "-1",
        //      "SOPInstanceUID" : "1.3.46.670589.11.71982.5.0.30772.2019071518405812024"
        //   },
        //   "ParentSeries" : "569f77a3-b5ec0d48-cea39272-9c96ad73-86bd7158",
        //   "Type" : "Instance"
        //}


    }
}
