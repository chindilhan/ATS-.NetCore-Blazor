using Microsoft.AspNetCore.Components;
using Stx.Shared.Common;
using Stx.Shared.Interfaces;
using Stx.Shared.Interfaces.HRM;
using Stx.Shared.Models.HRM;
using System.ComponentModel;

namespace Stx.HRM.Components.Job
{
    public class JobReviewQuestionsBase : ComponentBase
    {
        [Inject] IJobOrderDataService PageDataService { get; set; }
        [Parameter] public HrJobOrder JobOrder { get; set; }


        private bool _IsAutoRejectApplicant;
        public bool IsAutoRejectApplicant
        {
            get { return this._IsAutoRejectApplicant; }
            set
            {
                this._IsAutoRejectApplicant = value;
                IsAutoRejectApplicantParmChanged.InvokeAsync(IsAutoRejectApplicant);
            }
        }

        private string _AutoRejectMailTemplate;
        public string AutoRejectMailTemplate
        {
            get { return this._AutoRejectMailTemplate; }
            set
            {
                this._AutoRejectMailTemplate = value;
                AutoRejectMailTemplateParmChanged.InvokeAsync(AutoRejectMailTemplate);
            }
        }
        [Parameter] public bool IsAutoRejectApplicantParm { get; set; }
        [Parameter] public string AutoRejectMailTemplateParm { get; set; }
        [Parameter] public EventCallback<bool> IsAutoRejectApplicantParmChanged { get; set; }
        [Parameter] public EventCallback<string> AutoRejectMailTemplateParmChanged { get; set; }

        [Parameter] public BindingList<HrReviewQuestion> ReviewQuestions { get; set; } = new BindingList<HrReviewQuestion>();
        [Parameter] public EventCallback<BindingList<HrReviewQuestion>> ReviewQuestionsChanged { get; set; }
        [CascadingParameter(Name = "AlertService")] protected IAlertMsgService AlertMsgService { get; set; }

        public HrReviewQuestion BaseEntity { get; set; } = new HrReviewQuestion();
        public List<ComboStr> FieldTypeList { get; set; } = new List<ComboStr>();
        public List<ComboStr> AnswerTypeList { get; set; } = new List<ComboStr>();
        public bool IsAddNewRecord { get; set; } = false;
        public string AutoScreeningFieldType { get; set; }
        public string CustomScreeningFieldType { get; set; }
        public string AutoRejectPnlStyle { get; set; }
        public bool IsAutoRejectDisabled { get; set; }


        protected override async Task OnInitializedAsync()
        {
            try
            {
                AutoRejectMailTemplate = AutoRejectMailTemplateParm;
                IsAutoRejectApplicant = IsAutoRejectApplicantParm;

                ReviewQuestions.Clear();
                ReviewQuestions.ListChanged += ReviewPropertyChanged;
                await InitializeData();
                //ReviewQuestions = await PageDataService.GetReviewQuestions(JobOrderID);
                
                var recs = await PageDataService.GetReviewQuestions(JobOrder.JobOrderID);
                recs.ForEach(x => x.SplitSrcDataToList());
                recs.ForEach(x => ReviewQuestions.Add(x));

                if(string.IsNullOrWhiteSpace(JobOrder.AutoRejectEmailTemplate))
                {
                    JobOrder.AutoRejectEmailTemplate =
                        $"Thank you for your interest in the {@JobOrder.Title} position at {@JobOrder.CorporateName}. " +
                        $"Unfortunately, {@JobOrder.CorporateName} did not select your application to move forward in the hiring process. " +
                        $"" +
                        $"Regards," +
                        $"{@JobOrder.CorporateName}";
                }
                //ReviewQuestions.eve

                //BaseEntityList.Add(new HrReviewQuestion() { ID = 8, IsAutoEvaluate = false, FieldType = "yn", Desc = "Is the location ok?", EvaluateCriteria = "yn", RequiredAnswer = "Y", EvaluateType = "R"});
                //BaseEntityList.Add(new HrReviewQuestion() { ID = 9, IsAutoEvaluate = false, FieldType = "list", Desc = "list: Select an answers", FieldSrcData="A;B;C;D;", EvaluateCriteria = "", RequiredAnswer = "1;4;", EvaluateType = "O"});
                //BaseEntityList.Add(new HrReviewQuestion() { ID = 10, IsAutoEvaluate = false, FieldType = "short_ans", Desc = "Short answer question", EvaluateCriteria = "", RequiredAnswer = "", EvaluateType = "O"});

                //BaseEntityList.Add(new HrReviewQuestion() { ID = 3, IsAutoEvaluate = true, FieldType = "phone", Desc = "Phone", EvaluateCriteria = "fill", RequiredAnswer = "", EvaluateType = "R"});
                //BaseEntityList.Add(new HrReviewQuestion() { ID = 4, IsAutoEvaluate = true, FieldType = "edu_level", Desc = "Your education level?", EvaluateCriteria = "min", RequiredAnswer = "2", EvaluateType = "O"});
                //BaseEntityList.Add(new HrReviewQuestion() { ID = 5, IsAutoEvaluate = true, FieldType = "exp_years", Desc = "How many years of exp?", EvaluateCriteria = "min", RequiredAnswer = "5", EvaluateType = "R"});

            }
            catch (Exception ex)
            {
                AlertMsgService.ReportMessage(ex.Message, MsgType.Error, MsgRole.Alert);
            }
        }

        public void RefreshMe()
        {
            StateHasChanged();
        }

        private void ReviewPropertyChanged(object sender, ListChangedEventArgs e)
        {
            ReviewQuestionsChanged.InvokeAsync(ReviewQuestions);
            try
            {
                if (ReviewQuestions.Any(x => x.EvaluateType == "R"))
                {
                    AutoRejectPnlStyle = "";
                    IsAutoRejectDisabled = false;
                }
                else
                {
                    AutoRejectPnlStyle = "disabled";
                    IsAutoRejectDisabled = true;
                }
                StateHasChanged();
            }
            catch 
            {
            }
        }

        protected async Task InitializeData()
        {
            FieldTypeList.AddRange(new ComboStr[] 
            {
                new ComboStr("yn", "Yes/No"),
                new ComboStr("paragraph", "Paragraph"),
                new ComboStr("short_ans", "Short answer"),
                new ComboStr("list", "Dropdown list"),
                new ComboStr("mcsa", "Single Choice"),
                //new ComboStr("mcma", "Multiple Choice"),
                //new ComboStr("number", "Number"),
                //new ComboStr("date", "Date"),
            });
            //AnswerTypeList.AddRange(new ComboStr[] { new ComboStr("text", "Free Text"), new ComboStr("yn", "Yes/No"), new ComboStr("num", "Number") });
        }

        protected async Task DeleteReviewQuestion(HrReviewQuestion hrReviewQuestion)
        {
            try
            {
                if (hrReviewQuestion.ID <= 0)
                {
                    ReviewQuestions.Remove(hrReviewQuestion);
                    AlertMsgService.Notify("The review question has been deleted.", MsgType.Success);
                }
                else
                {
                    var rec = await PageDataService.DeleteReviewQuestion(hrReviewQuestion.JobOrderID, hrReviewQuestion.ID);
                    if (rec)
                    {
                        ReviewQuestions.Remove(hrReviewQuestion);
                        AlertMsgService.Notify("The review question has been deleted.", MsgType.Success);
                    }
                    return;
                }
            }
            catch (Exception ex)
            {
                AlertMsgService.ReportMessage(ex.Message, MsgType.Error, MsgRole.Alert);
            }
        }

        protected async Task AddNewButtonClicked(string mode)
        {
            if(mode == "system")
            {
                if (string.IsNullOrWhiteSpace(AutoScreeningFieldType)) { return; }
                ReviewQuestions.Add(new HrReviewQuestion()
                {
                    JobOrderID = JobOrder.JobOrderID,
                    ID = 0,
                    IsAutoEvaluate = true,
                    FieldType = AutoScreeningFieldType,
                    Desc = "",
                    EvaluateCriteria = "",
                    RequiredAnswer = "Y",
                    EvaluateType = "R", 
                    FieldSrcDataList = new BindingList<ComboStr>()
                });
                StateHasChanged();
            }
            else if(mode == "custom")
            {
                if (string.IsNullOrWhiteSpace(CustomScreeningFieldType)) { return; }
                ReviewQuestions.Add(new HrReviewQuestion()
                {
                    JobOrderID = JobOrder.JobOrderID,
                    ID = 0,
                    IsAutoEvaluate = false,
                    FieldType = CustomScreeningFieldType,
                    Desc = "",
                    EvaluateCriteria = "",
                    RequiredAnswer = "",
                    EvaluateType = "O",
                    FieldSrcDataList = new BindingList<ComboStr>() { new ComboStr() }
                });
                StateHasChanged();
            }
        }
        protected async Task PrepareNewEntryPanel(string action)
        {          
            StateHasChanged();
        }
    }
}
