using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Stx.HRM.Core;
using Stx.Shared.Extensions.Blazor;
using Stx.Shared.Extensions.Common;
using Stx.Shared.Common;
using Stx.Shared.Interfaces;
using Stx.Shared.Interfaces.HRM;
using Stx.Shared.Models.HRM;
using Stx.Shared.Status;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Stx.Hrm.Ats.Components.Job;

namespace Stx.HRM.Pages.Jobs
{
    public class CreateBase : ComponentBase
    {
        [Inject] public NavigationManager NavManager { get; set; }
        [Inject] ILogger<CreateBase> Logger { get; set; }
        [Inject] IJobOrderDataService PageDataService { get; set; }
        [Inject] IHrmGeneralDataService HrmGeneralDataService { get; set; }
        [CascadingParameter(Name = "AlertService")] public IAlertMsgService AlertMsgService { get; set; }

        public PageBaseInfo PageInfo { get; set; } = PageBaseInfo.GetPageInfo(0, PageType.Jobs, "Candidate Search");
        public HrJobOrder BaseEntity { get; set; } = new HrJobOrder();

        public List<ComboShort> CountryList { get; set; } = new List<ComboShort>();
        public List<ComboInt> CountryStateList { get; set; } = new List<ComboInt>(); 
        public List<ComboInt> JobIndustryList { get; set; } = new List<ComboInt>();
        public List<ComboInt> JobSpecialtyList { get; set; } = new List<ComboInt>();
        public List<ComboStr> CurrencyList { get; set; } = new List<ComboStr>();
        public List<ComboShort> PayCycleList { get; set; } = new List<ComboShort>();
        public List<ComboShort> EmploymentTypeList { get; set; } = new List<ComboShort>();
        public List<ComboShort> CareerLevelList { get; set; } = new List<ComboShort>();
        public List<ComboShort> EducationLevelList { get; set; } = new List<ComboShort>();
        public BindingList<HrReviewQuestion> ReviewQuestionList { get; set; } = new BindingList<HrReviewQuestion>();
        public bool IsAutoReject { get; set; }
        public string AutoRejectMailTemplate { get; set; }
        protected JobReviewQuestions JobReviewQuestionsCompRef;

        public CustomValidator CustomValidator { get; set; }
        public List<StepConfig> StepConfigs { get; set; } = new List<StepConfig>();
        public StepConfig CurrentPartialView { get; set; } = new StepConfig();
        public string PrevButtonStyle;
        public string NextButtonStyle;

        private string actn;
        private int JobId;
        EntryState entryState = EntryState.New;
        protected override async Task OnInitializedAsync()
        {
            try
            {
                AlertMsgService.Reset();
                AlertMsgService.ReportPageLoading(true);

                NavManager.TryGetQueryString<string>("actn", out actn);
                NavManager.TryGetQueryString<int>("id", out JobId);

                await InitializePageData();

                if (actn.InIgnoreCase("edit", "clone") && JobId > 0)
                {
                    entryState = EntryState.Update;
                    BaseEntity = await PageDataService.GetRecordByID(JobId);
                    if(BaseEntity == null)
                    {
                        entryState = EntryState.New;
                        BaseEntity = new HrJobOrder();
                        AlertMsgService.ReportMessage("The record is not available to edit.", MsgType.Warning, MsgRole.Alert);
                    }
                    else if (actn.InIgnoreCase("clone"))
                    {
                        BaseEntity.JobOrderID = -1;
                        BaseEntity.Title = $"Copy of {BaseEntity.Title}";
                    }
                }
                else
                {
                    BaseEntity = new HrJobOrder();
                    DateTime now = DateTime.UtcNow;
                    BaseEntity.DateStart = now.Date;
                    BaseEntity.DateEnd= now.Date.AddMonths(1);
                }
            }
            catch (Exception ex)
            {
                AlertMsgService.ReportMessage(ex.GetInnerExcpMsg(), MsgType.Error, MsgRole.Alert);
            }

            AlertMsgService.ReportPageLoading(false);
        }

        private async Task InitializePageData()
        {
            try
            {
                //CountryList = new List<SelectListItem>();
                //CountryList.AddRange(new SelectListItem[] { new SelectListItem("Sri Lanka", "1"), new SelectListItem("Singapore", "2"), new SelectListItem("India", "3"), new SelectListItem("USA", "4") });
                //CountryStateList = new List<SelectListItem>();
                //CountryStateList.AddRange(new SelectListItem[] {
                //    new SelectListItem("1", "State 1" ),
                //    new SelectListItem("1", "State 2"),
                //    new SelectListItem( "1", "State 3" ),
                //    new SelectListItem( "2", "State x22" ),
                //    new SelectListItem( "2", "State x33")
                //});

                StepConfigs.AddRange(new StepConfig[] 
                {
                    new StepConfig(){ID=1, StepStyle="text-success", StepCode="job_details", StepName="Job Details", StepDesc="" },
                    new StepConfig(){ID=2, StepStyle="", StepCode="job_option", StepName="Options", StepDesc="" },
                    new StepConfig(){ID=3, StepStyle="", StepCode="interview_plan", StepName="Interview Plan", StepDesc="" },
                    new StepConfig(){ID=4, StepStyle="", StepCode="hiring_team", StepName="Hiring Team", StepDesc="" },
                });

                CountryList = await HrmGeneralDataService.GetCountryList();
                CountryStateList = await HrmGeneralDataService.GetCountryCitiesList(0);
                JobIndustryList = await HrmGeneralDataService.GetJobIndustryList();
                JobSpecialtyList = await HrmGeneralDataService.GetJobCategoryList();
                CurrencyList = await HrmGeneralDataService.GetCurrencyList();
                PayCycleList = await HrmGeneralDataService.GetPayCycleList();
                EmploymentTypeList = await HrmGeneralDataService.GetEmploymentTypeList();
                CareerLevelList = await HrmGeneralDataService.GetCareerLevelList();
                EducationLevelList = await HrmGeneralDataService.GetEducationLevelList();

                CurrentPartialView = StepConfigs.FirstOrDefault();
            }
            catch (Exception ex)
            {
                AlertMsgService.ReportMessage(ex.GetInnerExcpMsg(), MsgType.Error, MsgRole.Alert);
            }
        }

        protected async Task HandleValidSubmitAsync()
        {
            try
            {
                AlertMsgService.Reset();
                AlertMsgService.ReportPageLoading(true);

                await SubmitFormData();

                AlertMsgService.ReportPageLoading(false);
            }
            catch (Exception ex)
            {
                AlertMsgService.ReportMessage(ex.GetInnerExcpMsg(), MsgType.Error, MsgRole.Alert);
            }
        }


        private async Task<bool> SubmitFormData()
        {
            bool isReadyToStepin = false;

            if (CurrentPartialView.StepCode.Compare("job_details"))
            {
                isReadyToStepin = await SubmitJobDetails();
            }
            else if (CurrentPartialView.StepCode.Compare("job_option"))
            {
                isReadyToStepin = true;
            }
            else if (CurrentPartialView.StepCode.Compare("interview_plan"))
            {
                isReadyToStepin = await SubmitReviewQuestions();
            }
            else if (CurrentPartialView.StepCode.Compare("hiring_team"))
            {
                //
            }
            else
            {
                return false;
            }

            if (isReadyToStepin)
            {
                AlertMsgService.Notify("The job details has been updated.", MsgType.Success);
            }

            return isReadyToStepin;
        }

        protected async Task<bool> SubmitJobDetails()
        {
            if (string.IsNullOrWhiteSpace(BaseEntity.Title) || string.IsNullOrWhiteSpace(BaseEntity.Title))
            {
                AlertMsgService.ReportMessage("Incomplete data. Please fill all required fields.", MsgType.Warning, MsgRole.Alert);
                return false;
            }

            var rec = await PageDataService.UpdateRecord(BaseEntity);

            if (rec != null)
            {
                //NavManager.NavigateTo(PageInfo.ListRecPageAdrs);
                AlertMsgService.ReportMessage($"The job '{BaseEntity.Title}' has been {(rec.JobOrderID > 0 ? "updated" : "created")}.", MsgType.Success, MsgRole.Alert);
                return true;
            }
            return false;
        }

        protected async Task<bool> SubmitReviewQuestions()
        {
            try
            {
                AlertMsgService.Reset();
                if (BaseEntity.JobOrderID <= 0)
                {
                    AlertMsgService.ReportMessage("Incomplete job data. Please review the job details first.", MsgType.Warning, MsgRole.Alert);
                    return false;
                }

                AlertMsgService.ReportPageLoading(true);
                var recs = await PageDataService.UpdateReviewQuestions(ReviewQuestionList.ToList());

                if (recs != null)
                {
                    ReviewQuestionList.Clear();
                    recs.ForEach(x=> ReviewQuestionList.Add(x));
                }

                List<ParmStr> autorej = new List<ParmStr>();
                autorej.Add(new ParmStr("IsReqAutoRejectEmail", IsAutoReject.ToString()));
                autorej.Add(new ParmStr("AutoRejectEmailTemplate", BaseEntity.AutoRejectEmailTemplate));
                var qry = await PageDataService.UpdateQuery(BaseEntity.JobOrderID, autorej);                
                    
                JobReviewQuestionsCompRef.RefreshMe();
                await NavigateNextPrevious(StepConfigs.OrderBy(x => x.ID).FirstOrDefault());
            }
            catch (Exception ex)
            {
                AlertMsgService.ReportMessage(ex.GetInnerExcpMsg(), MsgType.Error, MsgRole.Alert);
                return false;
            }

            AlertMsgService.ReportPageLoading(false);
            return true;
        }


        protected async Task HandleInvalidSubmitAsync()
        {
            //await SubmitEntry(false);
        }

        protected async Task NavigateToStep(StepConfig step)
        {
            AlertMsgService.Reset();
            AlertMsgService.ReportPageLoading(true);

            CurrentPartialView = step;

            AlertMsgService.ReportPageLoading(false);
        }

        protected async Task NavigateNextPrevious(string step)
        {
            if (step.Compare("<NEXT>"))
            {
                await NavigateNextPrevious(StepConfigs.FirstOrDefault(x => x.ID > CurrentPartialView.ID));
            }
            else if (step.Compare("<PREV>"))
            {
                await NavigateNextPrevious(StepConfigs.Where(x => x.ID < CurrentPartialView.ID).OrderByDescending(x => x.ID).FirstOrDefault());
            }
        }

        protected async Task NavigateNextPrevious(StepConfig step)
        {
            try
            {
                if (step == null) return;

                bool isNavPrevious = CurrentPartialView.ID > step.ID ? true : false;
                if (!ValidateNavigation(CurrentPartialView, isNavPrevious)) return;

                AlertMsgService.Reset();
                AlertMsgService.ReportPageLoading(true);

                bool isReadyToStepin = false;
                if (!isNavPrevious)
                {
                    await SubmitFormData();
                }

                AlertMsgService.ReportPageLoading(false);
                if (!isNavPrevious && !isReadyToStepin) return;
                CurrentPartialView = step;

                try
                {
                    StepConfigs.ForEach(x => x.StepStyle = "");
                    StepConfigs.Where(x => x == step).FirstOrDefault().StepStyle = "text-success";

                    if (StepConfigs.Max(x => x.ID) == CurrentPartialView.ID)
                        NextButtonStyle = "disabled";
                    if (StepConfigs.Min(x => x.ID) == CurrentPartialView.ID)
                        PrevButtonStyle = "disabled";
                }
                catch
                { }

                AlertMsgService.ReportPageLoading(false);
                StateHasChanged();
            }
            catch (Exception ex)
            {
                AlertMsgService.Notify("A navigation error occurred. Please try again.", MsgType.Error);
            }
        }

        private bool ValidateNavigation(StepConfig stepConfig, bool isNavPrevious, bool isValidateAll=false)
        {
            return true;
            CustomValidator.ClearErrors();

            var errors = new Dictionary<string, string>();
            if (isValidateAll || stepConfig.StepCode == "job_details")
            {
                if (string.IsNullOrEmpty(BaseEntity.Title))
                    errors.Add(nameof(BaseEntity.Title), "Job title field is required.");
                if (!BaseEntity.JobIndustry.HasValue)
                    errors.Add(nameof(BaseEntity.JobIndustry), "Job industry field is required.");
                if (JobSpecialtyList.Count > 0 && !BaseEntity.JobSpecialty.HasValue)
                    errors.Add(nameof(BaseEntity.JobSpecialty), "Job specialty field is required.");
                if (BaseEntity.Country <= 0)
                    errors.Add(nameof(BaseEntity.Country), "Country field is required.");
                if (string.IsNullOrEmpty(BaseEntity.Location))
                    errors.Add(nameof(BaseEntity.Location), "Job location field is required.");
                if (string.IsNullOrEmpty(BaseEntity.Description))
                    errors.Add(nameof(BaseEntity.Description), "Job description field is required.");
                if (BaseEntity.Salary > 0 && BaseEntity.SalaryPayCycle <= 0)
                    errors.Add(nameof(BaseEntity.SalaryPayCycle), "Pay cycle field is required.");
                if (BaseEntity.EmploymentType <= 0)
                    errors.Add(nameof(BaseEntity.EmploymentType), "Employment type field is required.");
                if (BaseEntity.DateEnd < BaseEntity.DateStart)
                    errors.Add(nameof(BaseEntity.DateEnd), "Invalid date range.");
                if (!BaseEntity.DateEnd.HasValue || BaseEntity.DateEnd.Value.Date < DateTime.Now.Date)
                    errors.Add(nameof(BaseEntity.DateEnd), "Job date end is invalid.");
            }
            if (isValidateAll || stepConfig.StepCode == "job_option")
            {
                if (string.IsNullOrEmpty(BaseEntity.ApplyMethod))
                    errors.Add(nameof(BaseEntity.ApplyMethod), "Please select an application receive mode.");
                if (string.IsNullOrEmpty(BaseEntity.ApplyMethodValue))
                    errors.Add(nameof(BaseEntity.ApplyMethodValue), "Email or web address is required.");
            }

            if (errors.Count > 0)
            {
                CustomValidator.DisplayErrors(errors);
                if (!isNavPrevious)
                {
                    AlertMsgService.Notify("Please correct all the errors before continuing to the next phase.", MsgType.Warning);
                    return false;
                }
            }
            return true;
        }

    }


    public class StepConfig
    {
        public int ID { get; set; }
        public string StepStyle { get; set; }
        public string StepCode { get; set; }
        public string StepName { get; set; }
        public string StepDesc { get; set; }
    }
}
