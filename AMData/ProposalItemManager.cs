using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMData
{
    public class ProposalItemManager
    {

        public ProposalItemManager()
        {
            ValidationErrors = new List<KeyValuePair<string, string>>();
        }

        public List<KeyValuePair<string, string>> ValidationErrors { get; set; }

        public bool Validate(ProposalItem entity)
        {
            ValidationErrors.Clear();
            if (!string.IsNullOrEmpty(entity.ProjectName))
            {
                if (entity.ProjectName.ToLower() == entity.ProjectName)
                {
                    ValidationErrors.Add(new KeyValuePair<string, string>("ProductName", "Product Name must not be all lower case."));
                }
            }
            return (ValidationErrors.Count == 0);
        }

        public bool Insert(ProposalItem entity)
        {
            bool ret = false;

            ret = Validate(entity);
            if (ret)
            {
                //todo Create Insert Code Here

            }
            return ret;
        }

        public ProposalItem Get(int proposalId)
        {
            List<ProposalItem> list = new List<ProposalItem>();
            ProposalItem ret = new ProposalItem();

            //todo call your data access method here
            list = CreateMockData();

            ret = list.Find(p => p.Id == proposalId);

            return ret;
        }

        public bool Update(ProposalItem entity)
        {
            bool ret = false;

            ret = Validate(entity);
            if (ret)
            {
                //todo Create UPDATE code here
            }
            return ret; 
        }

        public bool Delete(ProposalItem entity)
        {
            //todo Create DELETE code here

            return true;
        }

        public List<ProposalItem> Get(ProposalItem entity)
        {
            List<ProposalItem> ret = new List<ProposalItem>();
            //TODO Add data access method Here
            
            ret = CreateMockData();

            if (!string.IsNullOrEmpty(entity.ProjectName))
            {
                ret = ret.FindAll(p => p.ProjectName.ToLower().StartsWith(entity.ProjectName));
            }
            
            return ret;
        }

        private List<ProposalItem> CreateMockData()
        {
            List<ProposalItem> ret = new List<ProposalItem>();

            ret.Add(new ProposalItem()
            {
                Id = 1,
                ProjectName = "HS Gym Refinish",
                SubmitDateTime = "09/12/2017",
                ExpDateTime = "05/01/2018",
                Cost = 14207.15.ToString("C"),
                Description = "Resurfacing High School Gym"
            });

            ret.Add(new ProposalItem()
            {
                Id = 2,
                ProjectName = "MS Gym Refinish",
                SubmitDateTime = "09/12/2017",
                ExpDateTime = "05/01/2018",
                Cost = 10105.12.ToString("C"),
                Description = "Resurfacing Middle School Gym"
            });

            ret.Add(new ProposalItem()
            {
                Id = 3,
                ProjectName = "Football Laundry",
                SubmitDateTime = "10/12/2017",
                ExpDateTime = "12/31/2017",
                Cost = 3150.27.ToString("C"),
                Description = "New Laundry System for Football Locker Room"
            });

            ret.Add(new ProposalItem()
            {
                Id = 4,
                ProjectName = "Floor Buffer",
                SubmitDateTime = "11/12/2017",
                ExpDateTime = "12/31/2017",
                Cost = 8999.00.ToString("C"),
                Description = "New Buffer for Elementary"
            });

            return ret; 
        }//End CreateMockData
    }//End AssetObjectManager
}//End AMData
