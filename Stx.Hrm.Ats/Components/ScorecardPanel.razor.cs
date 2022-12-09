using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Stx.Shared.Common;
using Stx.Shared.Interfaces.HRM;
using Stx.Shared.Models.HRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stx.HRM.Components
{
    public class ScorecardPanelBase : ComponentBase
    {
        [Inject] ILogger<ScorecardPanelBase> Logger { get; set; }
        [Inject] IJobScorecardDataService JobScorecardDataService { get; set; }

        [Parameter]
        public EventCallback<ReturnObj> ComponentActionCallback { get; set; }

        [Parameter] public int JobOrderID { get; set; }
        [Parameter] public int JobCandidateID { get; set; }
        [Parameter] public int EvaluatorID { get; set; }
        [Parameter] public string Stage { get; set; }

        public List<HrJobCandidateScorecardDTO> Scorecard { get; set; } = new List<HrJobCandidateScorecardDTO>();
        public string Remarks { get; set; } = "";
        public HrJobCandidateScorecardDTO OverallRating { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                //Scorecard = await JobScorecardDataService.GetRecords(JobOrderID, JobCandidateID, EvaluatorID, Stage);

                //TEST ONLY
                Scorecard.Add(new HrJobCandidateScorecardDTO() { ID = 11, JobBmkID = 1, JobOrderID = JobOrderID, CandidateID = JobCandidateID, EvaluatorID = EvaluatorID, });
                Scorecard.Add(new HrJobCandidateScorecardDTO() { ID = 22, JobBmkID = 2, JobOrderID = JobOrderID, CandidateID = JobCandidateID, EvaluatorID = EvaluatorID, });
                Scorecard.Add(new HrJobCandidateScorecardDTO() { ID = 101, JobBmkID = 101, JobOrderID = JobOrderID, CandidateID = JobCandidateID, EvaluatorID = EvaluatorID, });
                Scorecard.Add(new HrJobCandidateScorecardDTO() { ID = 102, JobBmkID = 122, JobOrderID = JobOrderID, CandidateID = JobCandidateID, EvaluatorID = EvaluatorID, });

                Remarks = Scorecard.Where(x => x.JobBmkID == 1).Select(x => x.Value).FirstOrDefault() ?? "";
                OverallRating = Scorecard.Where(x => x.JobBmkID == 2).FirstOrDefault() ?? null;
            }
            catch (Exception ex)
            {

            }
        }

        protected async Task SubmitButtonClicked()
        {
            try
            {
                Scorecard = await JobScorecardDataService.UpdateRecord(Scorecard, Stx.Shared.Status.EntryState.Update, "");
                await ComponentActionCallback.InvokeAsync(new ReturnObj(true) { RetResult = Scorecard });
            }
            catch (Exception ex)
            {

            }
        }

        protected async Task CloseButtonClicked()
        {
            await ComponentActionCallback.InvokeAsync(new ReturnObj(false));
        }
        
        protected async Task ScorecardSelectionChanged(ParmInt parmInt)
        {
            var rec = Scorecard.Where(x => x.ID == parmInt.Value).FirstOrDefault();
            if(rec != null)
            {
                rec.Value = parmInt.Text;
            }
            else
            {
                //msg Record cant find
            }
        }
    }
}
