using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stx.HRM.Components.CorporateComp
{
    public class CorpSettingMenuBase : ComponentBase
    {
        public class SettMenu
        {
            public string Name { get; set; }
            public string ParmValue { get; set; }
        }

        [Parameter] public EventCallback<string> MenuButtonClickedCallback { get; set; }

        protected async Task MenuButtonClicked(string action)
        {
            CurrentSelectedMenu = action;
            await MenuButtonClickedCallback.InvokeAsync(action);
        }

        public List<SettMenu> CompSettMenus = new List<SettMenu>();
        public List<SettMenu> RecruitingMenus = new List<SettMenu>();
        public List<SettMenu> UserProfileMenus = new List<SettMenu>();

        public string CurrentSelectedMenu = "profile";
        private bool collapseNavMenu = false;

        private string NavMenuCssClass => collapseNavMenu ? "collapse" : null;

        private void ToggleNavMenu()
        {
            collapseNavMenu = !collapseNavMenu;
        }

        protected override async Task OnInitializedAsync()
        {
            CompSettMenus.AddRange(new SettMenu[]
            {
                new SettMenu(){Name="Company profile", ParmValue="profile"},
                new SettMenu(){Name="Departments", ParmValue="dept"},
                new SettMenu(){Name="Team members", ParmValue="team"},
                new SettMenu(){Name="Preferences", ParmValue="preference"},
                //new SettMenu(){Name="Billing information", ParmValue="billing"},
                //new SettMenu(){Name="Plan", ParmValue="plan"},
            });

            RecruitingMenus.AddRange(new SettMenu[]
             {
                new SettMenu(){Name="Workflow", ParmValue="workflow"},
                new SettMenu(){Name="Templates", ParmValue="templates"},
                new SettMenu(){Name="Interview tools", ParmValue="interview-tools"},
                //new SettMenu(){Name="Integrations", ParmValue="integrations"},
                //new SettMenu(){Name="Privacy", ParmValue="privacy"},
             });

            UserProfileMenus.AddRange(new SettMenu[]
             {
                new SettMenu(){Name="My Profile", ParmValue="user-profile"},
                new SettMenu(){Name="My Preferences", ParmValue="user-preference"},
             });
        }
    }
}
