

using System.Transactions;

namespace App.Contracts.Pagination
{
    public class PaginationDTO
    {
        public int Page { get; set; }
        private int recordsPerPage { get; set; }
        private readonly int recordsPerPageMax = 50;

        public int RecordsPerPage
        {
            get
            {
                return recordsPerPage; ;
            }
            set
            {
                if (value > recordsPerPageMax)
                {
                    recordsPerPage = recordsPerPageMax;
                }
                else
                {
                    recordsPerPage = value;
                }
            }
        }

    }




}
