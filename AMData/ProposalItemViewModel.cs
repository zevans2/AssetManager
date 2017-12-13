using System;
using System.Collections.Generic;
using System.Web.Mvc;


namespace AMData
{

    internal enum RequestMode
    {
        Add = 1, 
        Delete = 2
    }

    
    public class ProposalItemViewModel
    {
        public ProposalItemViewModel()
        {
            Items = new List<ProposalItem>();
            SearchEntity = new ProposalItem();
            Entity = new ProposalItem();
            Init();
        }

        public IEnumerable<SelectListItem> Proposals { get; set; }
        public int SelectProposalId { get; set; }
        public string ProposalType { get; set; }


        public string EventCommand { get; set; }
        public List<ProposalItem> Items { get; set; }
        public ProposalItem SearchEntity { get; set; }
        public ProposalItem Entity { get; set; }
        public bool IsValid { get; set; }
        public string Mode { get; set; }
        public List<KeyValuePair<string, string>> ValidationErrors { get; set; }
        public string EventArgument { get; set; }
        public bool IsDetailAreaVisible { get; set; }
        public bool IsListAreaVisible { get; set; }
        public bool IsSearchAreaVisible { get; set; }
        public bool IsGymFloorVisible { get; set; }

        //Public Function to make private methods available application
        public void HandleRequest()
        {
            switch (EventCommand.ToLower())
            {
                case "list":
                case "search":
                    Get();
                    break;

                case "save":
                    Save();
                    if (IsValid)
                    {
                        Get();
                    }
                    ResetSearch();
                    break;

                case "edit":
                    IsValid = true;
                    Edit();
                    break;

                case "delete":
                    ResetSearch();
                    Delete();
                    break;

                case "cancel":
                    ListMode();
                    ResetSearch();
                    Get();
                    break;

                case "resetsearch":
                    ResetSearch();
                    Get();
                    break;

                case "add":
                    Add();
                    break;

                default:
                    ResetSearch();
                    break;
            }
        }

        private void Add()
        {
            DateTime sub = DateTime.Now.Date;
            DateTime exp = sub.AddMonths(1).Date;
            IsValid = true;

            Entity = new ProposalItem
            {
                ProjectName = Entity.ProjectName,
                SubmitDateTime = sub.ToString("MM/dd/yyyy"),
                ExpDateTime = exp.ToString("MM/dd/yyyy"),
                Cost = 0.00.ToString("C"),
                Description = Entity.Description,
                Id = Entity.Id
            };

            AddMode();
        }

        private void AddMode()
        {
            IsListAreaVisible = false;
            IsSearchAreaVisible = false;
            IsDetailAreaVisible = true;

            Mode = "Add";
        }
        

        private void Save()
        {
            ProposalItemManager mgr = new ProposalItemManager();

            //RequestMode temp;
            //switch (temp)
            //{
            //    case RequestMode.Add:
            //        break;
            //    case RequestMode.Delete:
            //        break;
            //    default:
            //        throw new ArgumentOutOfRangeException();
            //}

            if (Mode == "Add")
            {
                //Add data to database here
                mgr.Insert(Entity);
            }
            else
            {
                mgr.Update(Entity);
            }

            ValidationErrors = mgr.ValidationErrors;
            if (ValidationErrors.Count > 0)
            {
                IsValid = false;
            }


            if (!IsValid) {

                if (Mode == "Add")
                {
                    AddMode();
                }
                else
                {
                    EditMode();
                }
            }
        }

        private void Init()
        {
            EventCommand = "List";
            EventArgument = string.Empty;
            ValidationErrors = new List<KeyValuePair<string, string>>();

            ListMode();
        }

        private void ListMode()
        {
            IsValid = true;

            IsListAreaVisible = true;
            IsSearchAreaVisible = true;
            IsDetailAreaVisible = false;

            Mode = "List";
        }
        
        private void EditMode()
        {
            IsListAreaVisible = false;
            IsSearchAreaVisible = false;
            IsDetailAreaVisible = true;

            Mode = "Edit";
        }

        private void Edit()
        {
            ProposalItemManager mgr = new ProposalItemManager();

            Entity = mgr.Get(Convert.ToInt32(EventArgument));
            
            EditMode();
        }

        private void Delete()
        {
            ProposalItemManager mgr = new ProposalItemManager();
            Entity = new ProposalItem();
            Entity.Id = Convert.ToInt32(EventArgument);

            mgr.Delete(Entity);

            Get();

            ListMode();
        }

        private void ResetSearch()
        {
            SearchEntity = new ProposalItem();
        }

        private void Get()
        {
            ProposalItemManager mgr = new ProposalItemManager();
            Items = mgr.Get(SearchEntity);
        }
        
    }
}
