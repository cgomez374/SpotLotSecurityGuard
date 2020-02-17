using System;
using System.Collections.Generic;
using System.Text;

namespace FIrebaseTest2
{
    public class Citation
    {
        //VARIABLES
        private int fineAmount = 50;

        private long citationId = 1;

        private bool paidStatus = false;
        public int UserId { get; set; }

        public string Name { get; set; }

        public string VehicleInfo { get; set; }

        public string LisencePlate { get; set; }

        public int NumberOfCitations { get; set; }

        public long CitationId { get { return citationId; } set { citationId = value; } }
        public string ReasonForCitation { get; set; }

        public int FineAmount { get { return fineAmount; } }

        public bool PaidStatus { get { return paidStatus; } set { paidStatus = value; } }


    }
}
